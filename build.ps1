param(
	$version = (property version 0.0.0.0),
	[ValidateSet('Debug', 'Release')]
	[string]$Configuration = 'Release'
)

Set-Alias MSBuild (Resolve-MSBuild)
Set-Alias MakeAppx -Value ("C:\Program Files (x86)\Windows Kits\10\App Certification Kit\makeappx.exe")
Set-Alias SignTool -Value ("C:\Program Files (x86)\Windows Kits\10\bin\10.0.22000.0\x64\signtool.exe")

$app_name = "BaseMauiApp"

$build_dir          = "build"
$build_tools_dir    = "$build_dir\tools"
$build_database_dir = "$build_dir\database"
$tools_dir			= "tools"

$dist_dir           = "dist"
$dist_name          = "BaseMauiApp"
$dist_zip_file      = "$dist_dir\$dist_name-$version.zip"

$database_dbname	= "BaseMauiApp"

$BaseMauiApp_path			= ".\BaseMauiApp"

$certfilePath				= ".\BaseMauiApp\BaseMauiApp_TemporaryKey.pfx"
$password					= "Test"

task generate generate-static, generate-main

task clean {
	if (Test-Path $build_dir) {
		Remove-Item -Path $build_dir -Recurse -Force | Out-Null
	}
	if (Test-Path $dist_dir) {
		Remove-Item -Path $dist_dir -Recurse -Force | Out-Null
	}
}

task prepare {

    New-Item -Path $build_dir											-ItemType Directory -Force | Out-Null		
    New-Item -Path "$build_dir\BaseMauiApp"								-ItemType Directory -Force | Out-Null					
    New-Item -Path $build_tools_dir										-ItemType Directory -Force | Out-Null
    New-Item -Path "$build_tools_dir\Invoke-Build"						-ItemType Directory -Force | Out-Null
}

# **********************************************
# Generate Tasks
# **********************************************
task generate-main {

	Write-Output "Publishing Web App"

	EXEC { MakeAppx pack /d $build_dir\BaseMauiApp /p "$build_dir\BaseMauiAppPackage\TestDefaultAppPackage.msix" }

	EXEC { SignTool sign /f $certfilePath /p $password /fd SHA256 "$build_dir\BaseMauiAppPackage\TestDefaultAppPackage.msix" }
}

task generate-static prepare, {

	# Copy all the tools directory components into build
	Copy-Item "tools\invoke-build\" -Destination "$build_tools_dir" -Recurse -Force

	Write-Output "Building Visitor Log App"
	EXEC { dotnet build "$BaseMauiApp_path/BaseMauiApp.csproj" -f net7.0-windows10.0.19041.0 -c Release /p:InformationalVersion=$version /p:FileVersion=$version --output "$build_dir\BaseMauiApp\" /p:PackageCertificateKeyFile="$certfilePath" /p:PackageCertificatePassword="$password" }

}

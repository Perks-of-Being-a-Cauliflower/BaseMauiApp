# BaseMauiApp

Sample Application to help debug a MAUI blazor/ Radzen issue.

To replicate this issue you will need to install the application on a device with touch capabilities. The device I used is a Surface Pro 2. NOTE: You will need to sign the application with your own certificate. I have provided the powershell script to help publish and package the app. You will need to replace the variables in the "build.ps1" powershell script with the certificate path and password of your certificate. once these have been set you will then need to navigate to the solution directory in the Powershell terminal and then call ".\build.bat clean,generate". This will create a build directory in the solution folder with an msix file which you can use to install the application.

Once you have installed the app to cause the freezing you simply need to click quickly between the different grid pages. Remember to use the touch screen as using a mouse will not expose the issue.

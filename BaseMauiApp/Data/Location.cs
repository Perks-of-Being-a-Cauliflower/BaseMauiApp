using System.ComponentModel.DataAnnotations;
namespace BaseMauiApp.Data;
public enum Location
{
    [Display(Description = "WWW Forte Lounge")]
    WWWForteLounge,
    [Display(Description = "CCC Forte Lounge")]
    CCCForteLounge,
    [Display(Description = "WWW ATM")]
    WWWATM,
    [Display(Description = "CCC ATM")]
    CCCATM,
    [Display(Description = "CCC Gate")]
    CCCGate,
    Unknown
}




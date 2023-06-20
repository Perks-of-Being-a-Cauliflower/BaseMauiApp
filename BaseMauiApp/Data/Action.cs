using System.ComponentModel.DataAnnotations;
namespace BaseMauiApp.Data;
public enum Action
{
    [Display(Description = "Door Entry - Log")]
    DoorEntryLog,
    [Display(Description = "Logbook Member Log")]
    LogbookMemberLog,
    [Display(Description = "Logbook Guest Log")]
    LogbookGuestLog,
    Unknown
}
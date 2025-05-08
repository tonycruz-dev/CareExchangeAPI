using System.ComponentModel.DataAnnotations;

namespace CareExchangeAPI.Models.Enums;

public enum EmploymentType
{
    [Display(Name = "PAYE")]
    PAYE,
    [Display(Name = "Limited Company")]
    Umbrella
}

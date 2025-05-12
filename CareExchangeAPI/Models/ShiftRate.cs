using CareExchangeAPI.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CareExchangeAPI.Models;

public class ShiftRate
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    /// Foreign key to Shift
    public int? ShiftRateId { get; set; }


    public RateType RateType { get; set; } = RateType.Base;

    public decimal HourlyRate { get; set; }

    // Navigation property
    public Shift? Shift { get; set; } 
}



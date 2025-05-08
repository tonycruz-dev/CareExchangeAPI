using CareExchangeAPI.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace CareExchangeAPI.Models;

public class ShiftRate
{

    public int Id { get; set; }


    public int? ShiftId{ get; set; }


    public RateType RateType { get; set; } = RateType.Base;

    public decimal HourlyRate { get; set; }

    // Navigation property
    public Shift? Shift { get; set; } 
}



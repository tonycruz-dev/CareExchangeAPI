using CareExchangeAPI.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace CareExchangeAPI.Models;

public class CandidatePayout
{
    public int Id { get; set; }
    public int CPCandidateID { get; set; }
    public int CPShiftID { get; set; }
    [Range(0, double.MaxValue)]
    public decimal GrossAmount { get; set; }

    [Range(0, double.MaxValue)]
    public decimal PlatformFee { get; set; }

    [Range(0, double.MaxValue)]
    public decimal NetPayout { get; set; }

    [Required]
    public PayoutStatus PayoutStatus { get; set; } = PayoutStatus.Pending;

    public DateTime? PayoutDate { get; set; }

    [MaxLength(255)]
    public string? StripePayoutID { get; set; }

    // Navigation properties
    public virtual UserProfile Candidate { get; set; } = null!;
    public virtual Shift Shift { get; set; } = null!;
}
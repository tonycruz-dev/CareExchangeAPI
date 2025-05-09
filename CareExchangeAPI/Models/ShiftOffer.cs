using CareExchangeAPI.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace CareExchangeAPI.Models;

public class ShiftOffer
{
    public int Id { get; set; }
    public int ShiftOfferShiftID { get; set; }
    public int ShiftOfferCandidateID { get; set; }

    [Required]
    public ShiftOfferStatus OfferStatus { get; set; } = ShiftOfferStatus.Pending;

    public DateTime OfferedAt { get; set; } = DateTime.UtcNow;

    public DateTime? RespondedAt { get; set; }

    // Navigation properties
    public virtual Shift Shift { get; set; } = null!;
    public virtual UserProfile Candidate { get; set; } = null!;
}
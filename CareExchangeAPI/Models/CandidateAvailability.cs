using System.ComponentModel.DataAnnotations;

namespace CareExchangeAPI.Models;

public class CandidateAvailability
{
    public int Id { get; set; }

    public int? CndAviCandidateID { get; set; }

    [Required]
    public DateTime Date { get; set; }

    public bool DayAvailable { get; set; } = false;

    public bool NightAvailable { get; set; } = false;

    // Navigation property
    public virtual UserProfile Candidate { get; set; } = null!;
}
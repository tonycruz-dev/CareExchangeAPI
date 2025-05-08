using System.ComponentModel.DataAnnotations;

namespace CareExchangeAPI.Models;

public class Timesheet
{
    
    public int Id { get; set; }

   
    public int? TimesheetShiftId { get; set; }

   
    public int? TimesheetUserPrifileId { get; set; }

    
    public int? TimesheetClientID { get; set; }

    public bool SubmittedByCandidate { get; set; } = false;

    public bool ApprovedByClient { get; set; } = false;

    public bool Rejected { get; set; } = false;

    [MaxLength(100)]
    public string? SignedOffBy { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow.ToLocalTime();

    // Navigation properties
    public virtual Shift Shift { get; set; } = null!;
    public virtual UserProfile Candidate { get; set; } = null!;
    public virtual CareHomeClient Client { get; set; } = null!;
}
using System.ComponentModel.DataAnnotations.Schema;

namespace CareExchangeAPI.Models;

public class ShiftCancellation
{
    
    public int Id { get; set; }
    public int SCId { get; set; }

    public int RequestedByUserID { get; set; }

    public string? Reason { get; set; }

    public DateTime CancelledAt { get; set; } = DateTime.UtcNow;

    public bool Approved { get; set; } = false;

    public int? ApprovedBy { get; set; }

    // Navigation properties
    public virtual Shift Shift { get; set; } = null!;

    [ForeignKey(nameof(RequestedByUserID))]
    public virtual UserProfile? RequestedByUser { get; set; } = null!;

    [ForeignKey(nameof(ApprovedBy))]
    public virtual UserProfile? ApprovedByUser { get; set; }
}
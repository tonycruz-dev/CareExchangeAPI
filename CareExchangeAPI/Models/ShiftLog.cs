
namespace CareExchangeAPI.Models;

public class ShiftLog
{
    public int Id { get; set; }

    public int ShiftLogId { get; set; }

    public int ShiftLogUserID { get; set; }

    public string? OldStatus { get; set; }

    public string? NewStatus { get; set; }

    public string? ChangeReason { get; set; }

    public DateTime Timestamp { get; set; } = DateTime.UtcNow;

    // Navigation properties
    public virtual Shift Shift { get; set; } = null!;
    public virtual UserProfile ChangedByUser { get; set; } = null!;
}
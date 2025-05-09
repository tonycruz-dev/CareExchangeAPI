using CareExchangeAPI.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace CareExchangeAPI.Models;

public class Shift
{
    public int Id { get; set; }
    public int LocationID { get; set; }
    public int JobTypeID { get; set; }
    
    public ShiftStatus Status { get; set; }

    public DateTime? StartTime { get; set; }
    public DateTime? EndTime { get; set; }

    public int BreakMinutes { get; set; } = 0;
    public decimal HourlyRate { get; set; } = 15.00m;
    public string? Notes { get; set; }

    // Navigation properties
    public virtual CareHomeClientLocation Location { get; set; } = null!;
    public virtual JobType JobType { get; set; } = null!;

    public int? CreatedByClientUserID { get; set; }
    public virtual UserProfile? CreatedByClientUser { get; set; } = null!;

    public virtual ICollection<ShiftAssignment> ShiftAssignments { get; set; } = [];

    public virtual ICollection<ShiftRate> ShiftRates { get; set; } = [];
    public virtual ICollection<Timesheet> Timesheets { get; set; } = [];
}

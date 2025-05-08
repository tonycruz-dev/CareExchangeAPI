using System.ComponentModel.DataAnnotations;
using CareExchangeAPI.Models.Enums;

namespace CareExchangeAPI.Models;

public class UserProfile
{
    public int Id { get; set; }
    public required string ProfileUserID { get; set; }
    public required string FirstName { get; set; }
       
    public required string LastName { get; set; }

    public string PreferredName { get; set; } = string.Empty;
        
    [EmailAddress]
    public required string Email { get; set; }

    public required string Mobile { get; set; }

    public bool PhoneVisibleToClients { get; set; } = false;

    public string? ProfilePhoto { get; set; }

    public DateTime? LastLogin { get; set; }

    public UserStatus Status { get; set; } = UserStatus.Active;

    // Home Address
    public string? HomeAddress { get; set; }

    public string? HomeCity { get; set; }

    public string? HomePostCode { get; set; }

    // Working Address
    public string? WorkingAddress { get; set; }

    public string? WorkingCity { get; set; }

    public string? WorkingPostCode { get; set; }

    public EmploymentType? EmploymentType { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public DateTime? StartedAtCX { get; set; }

    [MaxLength(50)]
    public string? PayrollID { get; set; }

    // Navigation property
    // Explicit foreign key navigation
    public virtual User User { get; set; } = null!;
    public virtual ICollection<ShiftAssignment> ShiftAssignments { get; set; } = [];
    public virtual ICollection<Timesheet> Timesheets { get; set; } = [];
}

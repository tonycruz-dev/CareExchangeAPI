﻿using System.ComponentModel.DataAnnotations;
using CareExchangeAPI.Models.Enums;

namespace CareExchangeAPI.Models;

public class UserProfile
{
    public int Id { get; set; }
    public required string ProfileUserID { get; set; }
    public required string FirstName { get; set; }
       
    public required string LastName { get; set; }

    public string PreferredName { get; set; } = string.Empty;
    public UserType CurrentUserType { get; set; } = UserType.Candidate;

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
    public virtual ICollection<CandidateDocument> CandidateDocuments { get; set; } = [];
    public virtual ICollection<Shift> Shifts { get; set; } = [];
    public virtual ICollection<Notification> Notifications { get; set; } = [];

    public virtual ICollection<Message> SentMessages { get; set; } = [];
    public virtual ICollection<Message> ReceivedMessages { get; set; } = [];
    public virtual ICollection<CalendarEvent> CalendarEvents { get; set; } = [];
    public virtual ICollection<ShiftOffer> ShiftOffers { get; set; } = [];
    public virtual ICollection<CandidateAvailability> CandidateAvailabilities { get; set; } = [];
    public virtual ICollection<ShiftLog> ShiftLogsChanged { get; set; } = [];

    public virtual ICollection<ShiftRating> RatingsGiven { get; set; } = [];
    public virtual ICollection<ShiftRating> RatingsReceived { get; set; } = [];

    public virtual ICollection<ShiftCancellation> CancellationRequests { get; set; } = [];
    public virtual ICollection<ShiftCancellation> ApprovedCancellations { get; set; } = [];

    public virtual ICollection<CandidatePayout> CandidatePayouts { get; set; } = [];
}

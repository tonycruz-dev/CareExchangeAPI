using System.ComponentModel.DataAnnotations;

namespace CareExchangeAPI.Models.Enums;

public enum UserStatus
{
    [Display(Name = "Active")]
    Active,

    [Display(Name = "Inactive")]
    Inactive,

    [Display(Name = "Suspended")]
    Suspended
}

public enum CareHomeLocationStatus
{
    [Display(Name = "Active")]
    Active,

    [Display(Name = "Dormant")]
    Dormant
}
public enum ShiftStatus
{
    [Display(Name = "Unfilled")]
    Unfilled,

    [Display(Name = "Booked")]
    Booked,

    [Display(Name = "Cancelled")]
    Cancelled,

    [Display(Name = "In Progress")]
    InProgress,

    [Display(Name = "Awaiting Candidate")]
    AwaitingCandidate,

    [Display(Name = "Awaiting Client")]
    AwaitingClient,

    [Display(Name = "Rejected")]
    Rejected,

    [Display(Name = "Invoiced")]
    Invoiced,

    [Display(Name = "Completed")]
    Completed,

    [Display(Name = "Never Filled")]
    NeverFilled
}

public enum AssignmentStatus
{
    [Display(Name = "Accepted")]
    Accepted,

    [Display(Name = "Cancelled")]
    Cancelled,

    [Display(Name = "Completed")]
    Completed
}

public enum RateType
{
    [Display(Name = "Base")]
    Base,

    [Display(Name = "Night")]
    Night,

    [Display(Name = "Weekend")]
    Weekend,

    [Display(Name = "Holiday")]
    Holiday
}
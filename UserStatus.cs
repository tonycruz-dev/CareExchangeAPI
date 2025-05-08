using System.ComponentModel.DataAnnotations;

public enum UserStatus
{
    [Display(Name = "Active User")]
    Active,

    [Display(Name = "Inactive User")]
    Inactive,

    [Display(Name = "Suspended User")]
    Suspended
}

public enum CareHomeLocationStatus
{
    [Display(Name = "Active Location")]
    Active,

    [Display(Name = "Dormant Location")]
    Dormant
}

public enum ShiftStatus
{
    [Display(Name = "Unfilled Shift")]
    Unfilled,

    [Display(Name = "Booked Shift")]
    Booked,

    [Display(Name = "Cancelled Shift")]
    Cancelled,

    [Display(Name = "In Progress")]
    InProgress,

    [Display(Name = "Awaiting Candidate")]
    AwaitingCandidate,

    [Display(Name = "Awaiting Client")]
    AwaitingClient,

    [Display(Name = "Rejected Shift")]
    Rejected,

    [Display(Name = "Invoiced Shift")]
    Invoiced,

    [Display(Name = "Completed Shift")]
    Completed,

    [Display(Name = "Never Filled")]
    NeverFilled
}

public enum AssignmentStatus
{
    [Display(Name = "Accepted Assignment")]
    Accepted,

    [Display(Name = "Cancelled Assignment")]
    Cancelled,

    [Display(Name = "Completed Assignment")]
    Completed
}

public enum RateType
{
    [Display(Name = "Base Rate")]
    Base,

    [Display(Name = "Night Rate")]
    Night,

    [Display(Name = "Weekend Rate")]
    Weekend,

    [Display(Name = "Holiday Rate")]
    Holiday
}

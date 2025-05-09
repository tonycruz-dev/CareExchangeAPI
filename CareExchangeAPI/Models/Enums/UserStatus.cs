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

public enum CandidateDocumentStatus
{
    [Display(Name = "Uploaded")]
    Uploaded,

    [Display(Name = "Approved")]
    Approved,

    [Display(Name = "Rejected")]
    Rejected,

    [Display(Name = "Expired")]
    Expired,

    [Display(Name = "Expiring Soon")]
    ExpiringSoon
}

public enum RecipientType
{
    [Display(Name = "Candidate")]
    Candidate,

    [Display(Name = "Client User")]
    ClientUser,

    [Display(Name = "CX User")]
    CXUser
}
public enum NotificationType
{
    [Display(Name = "Message")]
    Message,

    [Display(Name = "Announcement")]
    Announcement,

    [Display(Name = "Shift Accepted")]
    ShiftAccepted,

    [Display(Name = "Shift Cancelled")]
    ShiftCancelled,

    [Display(Name = "Shift Updated")]
    ShiftUpdated,

    [Display(Name = "Timesheet Needs Approval")]
    TimesheetNeedsApproval,

    [Display(Name = "Shift Offer")]
    ShiftOffer,

    [Display(Name = "Shift Assigned")]
    ShiftAssigned,

    [Display(Name = "Submit Timesheet")]
    SubmitTimesheet,

    [Display(Name = "Timesheet Approved")]
    TimesheetApproved,

    [Display(Name = "Timesheet Rejected")]
    TimesheetRejected,

    [Display(Name = "Shift Paid")]
    ShiftPaid,

    [Display(Name = "Document Rejected")]
    DocumentRejected,

    [Display(Name = "Document Approved")]
    DocumentApproved,

    [Display(Name = "Document Requested")]
    DocumentRequested
}
public enum CalendarEventType
{
    [Display(Name = "Booked Shift")]
    BookedShift,

    [Display(Name = "Available")]
    Available,

    [Display(Name = "Unavailable")]
    Unavailable
}
namespace CareExchangeAPI.Models.Enums;

public enum UserStatus
{
    Active,
    Inactive,
    Suspended
}

public enum CareHomeLocationStatus
{
    Active,
    Dormant
}
public enum ShiftStatus
{
    Unfilled,
    Booked,
    Cancelled,
    InProgress,
    AwaitingCandidate,
    AwaitingClient,
    Rejected,
    Invoiced,
    Completed,
    NeverFilled
}
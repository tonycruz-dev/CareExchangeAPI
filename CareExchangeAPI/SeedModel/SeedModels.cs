namespace CareExchangeAPI.SeedModel;


public class Rootobject
{
    public Careexchange CareExchange { get; set; }
}

public class Careexchange
{
    //public Calendarevent[] CalendarEvents { get; set; }
    //public Candidateavailability[] CandidateAvailabilities { get; set; }
    //public Candidatedocument[] CandidateDocuments { get; set; }
    //public Candidatepayout[] CandidatePayouts { get; set; }
    public Carehomeclientlocation[] CareHomeClientLocations { get; set; }
    public Carehomeclient[] CareHomeClients { get; set; }
    public JobType[] JobTypes { get; set; }
    public Skill[] Skills { get; set; }
    //public Clientpayment[] ClientPayments { get; set; }
    //public Document[] Documents { get; set; }
    //public Message[] Messages { get; set; }
    //public Notification[] Notifications { get; set; }
    //public Shiftassignment[] ShiftAssignments { get; set; }
    //public Shiftcancellation[] ShiftCancellations { get; set; }
    //public Shiftlog[] ShiftLogs { get; set; }
    //public Shiftoffer[] ShiftOffers { get; set; }
    public Shiftrate[] ShiftRates { get; set; }
    //public Shiftrating[] ShiftRatings { get; set; }
    public Shift[] Shifts { get; set; }
    //public Timesheet[] Timesheets { get; set; }
    public Userprofile[] UserProfiles { get; set; }
    public User[] Users { get; set; }
}

public class Calendarevent
{
    public int Id { get; set; }
    public int CalendarUserId { get; set; }
    public int? CalendarShiftId { get; set; }
    public string EventDate { get; set; }
    public string EventType { get; set; }
}

public class Candidateavailability
{
    public int Id { get; set; }
    public int CndAviCandidateID { get; set; }
    public string Date { get; set; }
    public bool DayAvailable { get; set; }
    public bool NightAvailable { get; set; }
}

public class Candidatedocument
{
    public int Id { get; set; }
    public int CandidateDocID { get; set; }
    public int CanDocID { get; set; }
    public string Status { get; set; }
    public string ExpiryDate { get; set; }
    public DateTime UploadedAt { get; set; }
    public DateTime ReviewedAt { get; set; }
    public int ReviewedBy { get; set; }
    public string FilePath { get; set; }
    public bool IsRequired { get; set; }
}

public class Candidatepayout
{
    public int Id { get; set; }
    public int CPCandidateID { get; set; }
    public int CPShiftID { get; set; }
    public float GrossAmount { get; set; }
    public float PlatformFee { get; set; }
    public float NetPayout { get; set; }
    public string PayoutStatus { get; set; }
    public DateTime PayoutDate { get; set; }
    public string StripePayoutID { get; set; }
}

public class Carehomeclientlocation
{
    public int LocationID { get; set; }
    public int CareHomeClientID { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string PostCode { get; set; }
    public float Latitude { get; set; }
    public float Longitude { get; set; }
    public string DefaultStartTime { get; set; }
    public string DefaultEndTime { get; set; }
    public string Status { get; set; }
}

public class Carehomeclient
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string LegalEntity { get; set; }
    public string CompanyNumber { get; set; }
    public string Phone { get; set; }
    public DateTime CreatedAt { get; set; }
    public string CareHomeClientUserID { get; set; }
}

public class Clientpayment
{
    public int Id { get; set; }
    public int ClienPaytId { get; set; }
    public int CPShiftId { get; set; }
    public string InvoiceNumber { get; set; }
    public float AmountCharged { get; set; }
    public DateTime PaymentDate { get; set; }
    public string PaymentMethod { get; set; }
    public string StripeTransactionID { get; set; }
}

public class Document
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool Required { get; set; }
    public int? ExpiryDays { get; set; }
    public bool ClientVisible { get; set; }
    public bool CandidateVisible { get; set; }
}

public class Message
{
    public int Id { get; set; }
    public int SenderID { get; set; }
    public int ReceiverID { get; set; }
    public string Content { get; set; }
    public bool IsBroadcast { get; set; }
    public DateTime SentAt { get; set; }
}

public class Notification
{
    public int Id { get; set; }
    public int NotificationUserID { get; set; }
    public string RecipientType { get; set; }
    public string TypeOfNotification { get; set; }
    public string Title { get; set; }
    public string Message { get; set; }
    public bool IsRead { get; set; }
    public DateTime CreatedAt { get; set; }
}

public class Shiftassignment
{
    public int Id { get; set; }
    public int FromShiftId { get; set; }
    public int ProfileId { get; set; }
    public string Status { get; set; }
}

public class Shiftcancellation
{
    public int Id { get; set; }
    public int SCId { get; set; }
    public int RequestedByUserID { get; set; }
    public string Reason { get; set; }
    public DateTime CancelledAt { get; set; }
    public bool Approved { get; set; }
    public int ApprovedBy { get; set; }
}

public class Shiftlog
{
    public int Id { get; set; }
    public int ShiftLogId { get; set; }
    public int ShiftLogUserID { get; set; }
    public string OldStatus { get; set; }
    public string NewStatus { get; set; }
    public string ChangeReason { get; set; }
    public DateTime Timestamp { get; set; }
}

public class Shiftoffer
{
    public int Id { get; set; }
    public int ShiftOfferShiftID { get; set; }
    public int ShiftOfferCandidateID { get; set; }
    public string OfferStatus { get; set; }
    public DateTime OfferedAt { get; set; }
    public DateTime RespondedAt { get; set; }
}

public class Shiftrate
{
    public int Id { get; set; }
    public int ShiftId { get; set; }
    public string RateType { get; set; }
    public float HourlyRate { get; set; }
}

public class Shiftrating
{
    public int Id { get; set; }
    public int ShID { get; set; }
    public int SRRatedByUserID { get; set; }
    public int CareRatedUserID { get; set; }
    public string Role { get; set; }
    public int RatingValue { get; set; }
    public string Feedback { get; set; }
    public DateTime CreatedAt { get; set; }
}

public class Shift
{
    public int Id { get; set; }
    public int LocationID { get; set; }
    public int JobTypeID { get; set; }
    public string Status { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public int BreakMinutes { get; set; }
    public float HourlyRate { get; set; }
    public string Notes { get; set; }
    public int CreatedByClientUserID { get; set; }
}

public class Timesheet
{
    public int Id { get; set; }
    public int TimesheetShiftId { get; set; }
    public int TimesheetUserPrifileId { get; set; }
    public int TimesheetClientID { get; set; }
    public bool SubmittedByCandidate { get; set; }
    public bool ApprovedByClient { get; set; }
    public bool Rejected { get; set; }
    public string SignedOffBy { get; set; }
    public DateTime CreatedAt { get; set; }
}

public class Userprofile
{
    public int Id { get; set; }
    public string ProfileUserID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PreferredName { get; set; }
    public string CurrentUserType { get; set; }
    public string Email { get; set; }
    public string Mobile { get; set; }
    public bool PhoneVisibleToClients { get; set; }
    public object ProfilePhoto { get; set; }
    public DateTime LastLogin { get; set; }
    public string Status { get; set; }
    public string HomeAddress { get; set; }
    public string HomeCity { get; set; }
    public string HomePostCode { get; set; }
    public string WorkingAddress { get; set; }
    public string WorkingCity { get; set; }
    public string WorkingPostCode { get; set; }
    public string EmploymentType { get; set; }
    public string DateOfBirth { get; set; }
    public string StartedAtCX { get; set; }
    public string PayrollID { get; set; }
}

public class User
{
    public string Id { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string DisplayName { get; set; }
    public string CurrentUserType { get; set; }
    public bool LockoutEnabled { get; set; }
}

public class JobType
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;
}





public class Skill
{
    public int Id { get; set; }
    public string Name { get; set; }
}




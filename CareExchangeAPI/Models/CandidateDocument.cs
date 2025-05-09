using CareExchangeAPI.Models.Enums;

namespace CareExchangeAPI.Models;

public class CandidateDocument
{
    public int Id { get; set; }
    public int CandidateDocID { get; set; }
    public int CanDocID { get; set; }
    public CandidateDocumentStatus Status { get; set; } = CandidateDocumentStatus.Uploaded;

    public DateTime? ExpiryDate { get; set; }

    public DateTime UploadedAt { get; set; } = DateTime.UtcNow.ToLocalTime();

    public DateTime? ReviewedAt { get; set; }

    public int? ReviewedBy { get; set; }

    public string? RejectionReason { get; set; }

    public string? FilePath { get; set; }

    public bool IsRequired { get; set; } = true;

    // Navigation properties
    public virtual UserProfile Candidate { get; set; } = null!;
    public virtual Document Document { get; set; } = null!;
    public virtual UserProfile? Reviewer { get; set; }
}
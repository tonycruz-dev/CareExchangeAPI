using CareExchangeAPI.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace CareExchangeAPI.Models;

public class Notification
{
    public int Id { get; set; }

    [Required]
    public int NotificationUserID { get; set; }

    [Required]
    public RecipientType RecipientType { get; set; } = RecipientType.Candidate;

    [Required]
    public NotificationType TypeOfNotification { get; set; }

    [MaxLength(255)]
    public string? Title { get; set; }

    public string? Message { get; set; }

    public bool IsRead { get; set; } = false;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // Navigation property
    public virtual UserProfile User { get; set; } = null!;
}
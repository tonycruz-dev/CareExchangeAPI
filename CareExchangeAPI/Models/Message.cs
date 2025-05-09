using System.ComponentModel.DataAnnotations;

namespace CareExchangeAPI.Models;

public class Message
{
    
    public int Id { get; set; }

    public int? SenderID { get; set; }

    public int? ReceiverID { get; set; }

    public string? Content { get; set; }

    public bool IsBroadcast { get; set; } = false;

    public DateTime SentAt { get; set; } = DateTime.UtcNow.ToLocalTime();

    // Navigation properties
    public virtual UserProfile? Sender { get; set; }

    public virtual UserProfile? Receiver { get; set; }
}
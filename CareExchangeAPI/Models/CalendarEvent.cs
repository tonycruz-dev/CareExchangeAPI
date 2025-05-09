using CareExchangeAPI.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace CareExchangeAPI.Models;

public class CalendarEvent
{
    public int Id { get; set; }

    public int? CalendarUserId { get; set; }

    public int? CalendarShiftId { get; set; }

    [Required]
    public DateTime EventDate { get; set; }

    [Required]
    public CalendarEventType EventType { get; set; }

    // Navigation properties
    public virtual UserProfile? User { get; set; }

    public virtual Shift? Shift { get; set; }
}
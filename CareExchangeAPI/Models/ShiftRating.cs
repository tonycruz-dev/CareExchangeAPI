using CareExchangeAPI.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace CareExchangeAPI.Models;

public class ShiftRating
{
   
    public int Id { get; set; }


    public int? ShID { get; set; }


    public int? SRRatedByUserID { get; set; }


    public int? CareRatedUserID { get; set; }

    [Required]
    public RatingRole Role { get; set; }

    [Range(1, 5)]
    public int RatingValue { get; set; }

    public string? Feedback { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // Navigation properties
    public virtual Shift Shift { get; set; } = null!;
    public virtual UserProfile RatedByUser { get; set; } = null!;
    public virtual UserProfile RatedUser { get; set; } = null!;
}
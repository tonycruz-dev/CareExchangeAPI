using CareExchangeAPI.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CareExchangeAPI.Models;

public class CareHomeClientLocation
{
    [Key]
    public int LocationID { get; set; }

    [ForeignKey(nameof(CareHomeClient))]
    public int CareHomeClientID { get; set; }

    [MaxLength(255)]
    public string? Name { get; set; }

    public string? Address { get; set; }

    [MaxLength(100)]
    public string? City { get; set; }

    [MaxLength(20)]
    public string? PostCode { get; set; }

    public TimeSpan? DefaultStartTime { get; set; }

    public TimeSpan? DefaultEndTime { get; set; }

    public float? Latitude { get; set; }

    public float? Longitude { get; set; }

    public CareHomeLocationStatus Status { get; set; } = CareHomeLocationStatus.Active;

    // Navigation property
    public virtual CareHomeClient CareHomeClient { get; set; } = null!;
}
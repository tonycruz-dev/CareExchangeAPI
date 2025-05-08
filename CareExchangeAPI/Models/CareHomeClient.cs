using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CareExchangeAPI.Models;

public class CareHomeClient
{
    
    public int Id { get; set; }


    public string Name { get; set; } = string.Empty;

    public string? LegalEntity { get; set; }

    public string? CompanyNumber { get; set; }

    [EmailAddress]
    public string? Email { get; set; }

    [MaxLength(20)]
    public string? Phone { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow.ToLocalTime();

    // Navigation property
    public string CareHomeClientUserID { get; set; } = null!;

    public virtual User User { get; set; } = null!;
    public virtual ICollection<CareHomeClientLocation> Locations { get; set; } = [];
}
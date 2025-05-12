using CareExchangeAPI.Models.Enums;
using Microsoft.AspNetCore.Identity;

namespace CareExchangeAPI.Models;

public class User : IdentityUser
{
    public string? DisplayName { get; set; }
    public string? Bio { get; set; }
    public string? ImageUrl { get; set; }
    public string? Location { get; set; }
    public UserType CurrentUserType { get; set; } = UserType.Candidate;
    public ICollection<UserProfile> UserProfiles { get; set; } = [];
    public ICollection<CareHomeClient> CareHomeClients { get; set; } = [];
}

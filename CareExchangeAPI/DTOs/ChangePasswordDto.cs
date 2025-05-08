using System.ComponentModel.DataAnnotations;

namespace CareExchangeAPI.DTOs;

public class ChangePasswordDto
{
    [Required]
    public string CurrentPassword { get; set; } = "";

    [Required]
    public string NewPassword { get; set; } = "";
}
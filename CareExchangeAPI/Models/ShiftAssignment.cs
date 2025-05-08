using CareExchangeAPI.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace CareExchangeAPI.Models;

public class ShiftAssignment
{
    
    public int Id { get; set; }

   
    public int? FromShiftId { get; set; }


    public int? ProfileId { get; set; }

    [Required]
    public AssignmentStatus Status { get; set; }

    // Navigation properties
    public Shift? Shift { get; set; } = null!;
    public  UserProfile? UserProfile { get; set; } = null!;
}



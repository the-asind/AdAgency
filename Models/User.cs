using System.ComponentModel.DataAnnotations;

namespace AdAgency.Models;

public class User
{
    [Key]
    public int UserId { get; set; }
    public required string? Username { get; set; } // username a-z A-Z 0-9
    public required string? PasswordHash { get; set; } 
    public required string Role { get; set; } // "admin", "renter", "configurator" ONLY ONE OF THESE
    public int? RenterId { get; set; } // if the user is a renter
    public Renter? Renter { get; set; }

}
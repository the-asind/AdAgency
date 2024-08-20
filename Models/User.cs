using System.ComponentModel.DataAnnotations;

namespace AdAgency.Models;

public class User
{
    [Key]
    public int UserId { get; set; }
    public required string? Username { get; set; }
    public required string? PasswordHash { get; set; }
    public required string Role { get; set; }
    public int? RenterId { get; set; }
    public Renter? Renter { get; set; }
}
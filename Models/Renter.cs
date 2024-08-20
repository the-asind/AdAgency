using System.ComponentModel.DataAnnotations;

namespace AdAgency.Models;

public class Renter
{
    [Key]
    public int RenterId { get; set; }
    public required string Name { get; set; }
    public required string Status { get; set; }
    public required string LegalAddress { get; set; }
    public required string DirectorName { get; set; }
    public required string DirectorPhone { get; set; }
    public required string ContactPersonName { get; set; }
    public required string ContactPersonPhone { get; set; }
    public required string BankName { get; set; }
    public required string BankAccountNumber { get; set; }
    public required string Inn { get; set; }
}
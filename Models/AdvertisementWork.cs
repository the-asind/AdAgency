using System.ComponentModel.DataAnnotations;

namespace AdAgency.Models;

public class AdvertisementWork
{
    [Key]
    public int WorkId { get; set; }
    public int ContractId { get; set; }
    public required Contract Contract { get; set; }
    public string? WorkDescription { get; set; }
    public decimal WorkCost { get; set; }
}
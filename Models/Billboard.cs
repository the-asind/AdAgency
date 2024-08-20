using System.ComponentModel.DataAnnotations;

namespace AdAgency.Models;

public class Billboard
{
    [Key]
    public int BillboardId { get; set; }
    public required string RegistrationNumber { get; set; }
    public required string CityDistrict { get; set; }
    public required string Address { get; set; }
    public string? LocationDescription { get; set; }
    public decimal UsefulArea { get; set; }
}
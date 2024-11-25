using System.ComponentModel.DataAnnotations;

namespace AdAgency.Models;

public class Billboard
{
    [Key]
    public int BillboardId { get; set; }
    public required string RegistrationNumber { get; set; } // unique identifier like: AA-1234
    public required string CityDistrict { get; set; }
    public required string Address { get; set; } // street, house number
    public string? LocationDescription { get; set; } // useful for renters information
    public decimal UsefulArea { get; set; } // size of ad screen in square meters (m^2)

    public decimal RentAmountPerWeek { get; set; } // in RUB
}
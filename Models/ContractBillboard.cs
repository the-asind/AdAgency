using System.ComponentModel.DataAnnotations;

namespace AdAgency.Models;

public class ContractBillboard
{
    [Key]
    public int Id { get; set; }

    public int ContractId { get; set; }
    public Contract? Contract { get; set; }

    public int BillboardId { get; set; }
    public Billboard? Billboard { get; set; }

    public DateTime? RentStartDate { get; set; }
    public DateTime? RentEndDate { get; set; }
    public decimal RentAmount { get; set; } // in RUB
    public required string AdvertisementPhotoLink { get; set; } // link to the photo of the advertisement "https://example.com/photo.jpg"
}
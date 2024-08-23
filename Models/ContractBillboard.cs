using System.ComponentModel.DataAnnotations;

namespace AdAgency.Models;

public class ContractBillboard
{
    [Key]
    public int Id { get; set; }
    public int ContractId { get; set; }
    public required Contract Contract { get; set; }
    public int BillboardId { get; set; }
    public required Billboard Billboard { get; set; }
    [Timestamp] public byte[] RentStartDate { get; set; }
    [Timestamp] public byte[] RentEndDate { get; set; }
    public decimal RentAmount { get; set; }
    public required byte[] AdvertisementPhoto { get; set; }

    public static ContractBillboard CreateEmpty()
    {
        return new ContractBillboard
        {
            Contract = Contract.CreateEmpty(),
            Billboard = Billboard.CreateEmpty(),
            AdvertisementPhoto = []
        };
    }
}
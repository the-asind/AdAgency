using System.ComponentModel.DataAnnotations;

namespace AdAgency.Models;

public class Contract
{
    [Key] public int ContractId { get; set; }
    public string? ContractNumber { get; set; }
    [Timestamp] public byte[]? SigningDate { get; set; }
    public string? AgencyResponsible { get; set; }
    public decimal TotalAmount { get; set; }
    public string? PaymentType { get; set; }
    public string? AdditionalTerms { get; set; }

    public int RenterId { get; set; }
    public Renter Renter { get; set; }

    public ICollection<ContractBillboard> ContractBillboards { get; set; }
    public ICollection<AdvertisementWork> AdvertisementWorks { get; set; }

    public static Contract CreateEmpty()
    {
        return new Contract
        {
            ContractNumber = null,
            SigningDate = new byte[1],
            Renter = Renter.CreateEmpty()
        };
    }
}
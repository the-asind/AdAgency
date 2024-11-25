using System.ComponentModel.DataAnnotations;

namespace AdAgency.Models;

public class Contract
{
    [Key]
    public int ContractId { get; set; }

    public string? ContractNumber { get; set; } // unique identifier of the billboardNumber + ContractID (five digits): AA-1234-00001
    public DateTime SigningDate { get; set; }
    public string? AgencyResponsible { get; set; } // full name of the responsible person
    public decimal TotalAmount { get; set; } // in RUB
    public string? PaymentType { get; set; } // "Наличные", "Банковский перевод", "Постоплата" ONLY ONE OF THREE
    public string? AdditionalTerms { get; set; } // Always "Нет" or some additional information
    public required string Status { get; set; } // "Активен", "Закрыт", "Отменен" ONLY ONE OF THREE

    public int RenterId { get; set; }
    public Renter? Renter { get; set; }

    public ICollection<ContractBillboard>? ContractBillboards { get; set; }
    public ICollection<AdvertisementWork>? AdvertisementWorks { get; set; }
}
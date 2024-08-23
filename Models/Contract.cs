using System.ComponentModel.DataAnnotations;

namespace AdAgency.Models
{
    public class Contract
    {
        [Key]
        public int ContractId { get; set; }
        public string ContractNumber { get; set; }
        public DateTime SigningDate { get; set; }
        public string AgencyResponsible { get; set; }
        public decimal TotalAmount { get; set; }
        public string PaymentType { get; set; }
        public string AdditionalTerms { get; set; }

        public int RenterId { get; set; }
        public Renter Renter { get; set; }

        public ICollection<ContractBillboard> ContractBillboards { get; set; }
        public ICollection<AdvertisementWork> AdvertisementWorks { get; set; }

        public Contract()
        {
            ContractBillboards = new List<ContractBillboard>();
            AdvertisementWorks = new List<AdvertisementWork>();
        }

        public static Contract CreateEmpty()
        {
            return new Contract
            {
                ContractNumber = "",
                SigningDate = DateTime.Now,
                AgencyResponsible = "",
                TotalAmount = 0,
                PaymentType = "",
                AdditionalTerms = "",
                Renter = Renter.CreateEmpty(),
                ContractBillboards = new List<ContractBillboard>(),
                AdvertisementWorks = new List<AdvertisementWork>()
            };
        }
    }
}
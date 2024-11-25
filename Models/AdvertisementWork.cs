using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdAgency.Models;

public class AdvertisementWork
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Убедиться, что WorkId автоинкремент
    public int WorkId { get; set; }
    public int ContractId { get; set; } 
    public Contract? Contract { get; set; }
    public string? WorkDescription { get; set; } // description of the work: "Установка баннера", "Установка светового короба", "Установка билборда"
    public decimal WorkCost { get; set; } // in RUB ex. 10000
}
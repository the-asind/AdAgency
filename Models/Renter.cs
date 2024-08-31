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

    public string? Email { get; set; }
    
    public override string ToString()
    {
        return $"Название:  {Status} \"{Name}\"\n" +
               $"Юридический адрес: {LegalAddress}\n" +
               $"ФИО руководителя: {DirectorName}\n" +
               $"Телефон руководителя: {DirectorPhone}\n" +
               $"Ответственное лицо: {ContactPersonName}\n" +
               $"Телефон ответственного лица: {ContactPersonPhone}\n" +
               $"Банк арендатора: {BankName}\n" +
               $"Номер счета в банке: {BankAccountNumber}\n" +
               $"ИНН арендатора: {Inn}" +
               $"Электронная почта: {Email}";
    }
}


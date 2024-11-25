using System.ComponentModel.DataAnnotations;

namespace AdAgency.Models;

public class Renter
{
    [Key]
    public int RenterId { get; set; }

    public required string Name { get; set; } // name of the company ex. "Рога и копыта"
    public required string Status { get; set; } // "АО", "ООО", "ИП", "ГУП", "МУП" ONLY ONE OF THESE
    public required string LegalAddress { get; set; } // legal address of the company ex. "г. Москва, ул. Ленина, д. 1"
    public required string DirectorName { get; set; } // full name of the director ex. "Иванов Иван Иванович"
    public required string DirectorPhone { get; set; } // phone number of the director ex. "+79999999999"
    public required string ContactPersonName { get; set; } // full name of the contact person ex. "Петров Петр Петрович"
    public required string ContactPersonPhone { get; set; } // phone number of the contact person ex. "+79999999999"
    public required string BankName { get; set; } // name of the bank ex. "Сбербанк"
    public required string BankAccountNumber { get; set; } // account number of 20 digits ex. "11122333455556666666"
    public required string Inn { get; set; } // INN of the company of 12 digits ex. "987654321098"
    public string? Email { get; set; } // email of the company ex. "example@example.com"
    
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
               $"ИНН арендатора: {Inn}\n" +
               $"Электронная почта: {Email}";
    }
}


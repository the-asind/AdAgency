using System.ComponentModel.DataAnnotations;

namespace AdAgency.Models;

public class AuditLog
{
    [Key]
    public int LogId { get; set; }
    public int UserId { get; set; }
    public required User User { get; set; }
    public required string Action { get; set; }
    public required string TableName { get; set; }
    public int? RecordId { get; set; }
    public DateTime ActionTimestamp { get; set; } = DateTime.Now;

    public static object CreateEmpty()
    {
        return new AuditLog
        {
            UserId = 0,
            User = User.CreateEmpty(),
            Action = "",
            TableName = "",
            ActionTimestamp = DateTime.Now
        };
    }
}
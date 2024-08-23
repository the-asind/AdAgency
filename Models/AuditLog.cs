using System.ComponentModel.DataAnnotations;

namespace AdAgency.Models;

public class AuditLog
{
    [Key] public int LogId { get; set; }
    public int UserId { get; set; }
    public required User User { get; set; }
    public required string Action { get; set; }
    public required string TableName { get; set; }
    public int? RecordId { get; set; }
    [Timestamp] public byte[]? Version { get; set; }

    public static AuditLog CreateEmpty()
    {
        var timestamp = BitConverter.GetBytes(DateTime.UtcNow.Ticks);
        return new AuditLog
        {
            User = User.CreateEmpty(),
            Version = timestamp,
            Action = "",
            TableName = ""
        };
    }
}
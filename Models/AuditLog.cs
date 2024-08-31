using System.ComponentModel.DataAnnotations;

namespace AdAgency.Models;

public class AuditLog
{
    [Key] public int LogId { get; set; }
    public int UserId { get; set; }
    public User? User { get; set; }
    public required string Action { get; set; }
    public required string TableName { get; set; }
    public int? RecordId { get; set; }
    [Timestamp] public byte[]? Version { get; set; }
}
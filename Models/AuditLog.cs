using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdAgency.Models;

public class AuditLog
{
    [Key] public int LogId { get; set; }
    public int UserId { get; set; }
    public User? User { get; set; }
    public required string Action { get; set; }
    public required string TableName { get; set; }
    public int? RecordId { get; set; }
    public DateTime? Timestamp { get; set; }
}
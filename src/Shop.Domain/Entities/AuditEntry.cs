using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.Domain.Entities
{
    public class AuditEntry
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Type { get; set; } = string.Empty;
        public string TableName { get; set; } = string.Empty;
        public DateTime DateTime { get; set; }
        public string OldValues { get; set; } = string.Empty;
        public string NewValues { get; set; } = string.Empty;
        public string AffectedColumns { get; set; } = string.Empty;
        public int PrimaryKey { get; set; }

        [NotMapped]
        public object Entity { get; set; }
    }
}

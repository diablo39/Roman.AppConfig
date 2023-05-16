
// Path: src\api\src\Roman.AppConfig.Domain\Model\AuditLog.cs
namespace Roman.AppConfig.Domain.Model
{
    public class AuditLog : IEntity<Guid>
    {
        public Guid Id { get; }
        public Guid UserId { get; }
        public string Action { get; }
        public string EntityType { get; }
        public Guid EntityId { get; }
        public string EntityName { get; }
        public DateTimeOffset CreateDate { get; }

        public AuditLog(Guid id)
        {
            Id = id;
        }
    }
}

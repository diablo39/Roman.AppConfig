// Path: src\api\src\Roman.AppConfig.Domain\Model\AuditLog.cs

// Path: src\api\src\Roman.AppConfig.Domain\Model\Feature.cs

namespace Roman.AppConfig.Domain.Model.Features
{
    public class Feature : IEntity<Guid>
    {
        public Guid Id { get; }
        public Guid ApplicationId { get; }
        public string Name { get; }
        public string Description { get; }
        public string Type { get; }
        public string DefaultValue { get; }
        public DateTimeOffset CreateDate { get; }

        public Feature(Guid id)
        {
            Id = id;
        }
    }
}

// Path: src\api\src\Roman.AppConfig.Domain\Model\AuditLog.cs

// Path: src\api\src\Roman.AppConfig.Domain\Model\Feature.cs

// Path: src\api\src\Roman.AppConfig.Domain\Model\FeatureFlag.cs

// Path: src\api\src\Roman.AppConfig.Domain\Model\FeatureFlagHistory.cs

namespace Roman.AppConfig.Domain.Model.Features
{
    public class FeatureFlagHistory : IEntity<Guid>
    {
        public Guid Id { get; }
        public Guid FeatureFlagId { get; }
        public string Name { get; }
        public string Description { get; }
        public string Type { get; }
        public string Value { get; }

        public DateTimeOffset CreateDate { get; }

        public FeatureFlagHistory(Guid id)
        {
            Id = id;
        }
    }
}
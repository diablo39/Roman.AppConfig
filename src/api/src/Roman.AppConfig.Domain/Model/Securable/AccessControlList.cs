namespace Roman.AppConfig.Domain.Model.Securable
{
    public class AccessControlList : IEntity<Guid>
    {
        public Guid Id { get; }

        public Guid SecuredItemId { get; }

        public Guid UserId { get; }

        public string SecuredItemType { get; }

        public AccessLevels AccessLevel { get; }

        public DateTimeOffset CreateDate { get; }

        public AccessControlList(Guid id, Guid securedItemId, Guid userId, string securedItemType, AccessLevels accessLevel, DateTimeOffset createDate = default)
        {
            Id = id;
            SecuredItemId = securedItemId;
            UserId = userId;
            SecuredItemType = securedItemType;
            AccessLevel = accessLevel;
            CreateDate = createDate == default ? DateTime.UtcNow : createDate;
        }
    }
}
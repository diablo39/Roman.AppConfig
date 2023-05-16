namespace Roman.AppConfig.Domain.Model.Ownable
{
    public class Owner : IEntity<Guid>
    {
        public Guid Id { get; }

        public string Name { get; set; }

        public string UserId { get; }

        public DateTimeOffset CreateDate { get; }

        public Owner(Guid id, string name, string userId, DateTimeOffset createDate = default)
        {
            Id = id;
            Name = name;
            UserId = userId;
            CreateDate = createDate;
        }
    }
}
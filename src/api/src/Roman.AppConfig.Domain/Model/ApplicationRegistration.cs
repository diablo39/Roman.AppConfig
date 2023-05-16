using Roman.AppConfig.Domain.Model.Ownable;
using Roman.AppConfig.Domain.Model.Securable;

namespace Roman.AppConfig.Domain.Model
{
    public class ApplicationRegistration : IEntity<Guid>//, ISecuredItem, IOwnedItem
    {
        // Fields
        //private readonly HashSet<Owner> _owners = new();

        //private readonly HashSet<AccessControlList> _accessControlList = new();

        // Properties
        public string Name { get; set; }

        public string? Description { get; set; }

        //public IEnumerable<Owner> Owners => _owners;

        //public IEnumerable<AccessControlList> AccessControlList => _accessControlList;

        public Guid Id { get; }

        public DateTimeOffset CreateDate { get; }

        // Constructors
        public ApplicationRegistration(Guid id, string name, DateTimeOffset createDate = default)
        {
            Guard.IsNotDefault(id, nameof(id));
            Guard.IsNotNullOrEmpty(name, nameof(name));

            Id = id;
            Name = name;
            CreateDate = createDate == default ? DateTime.UtcNow : createDate;
        }

        // Methods

        //#region Owner

        //public void AddOwner(Owner owner)
        //{
        //    throw new NotImplementedException();
        //}

        //public void RemoveOwner(Guid ownerId)
        //{
        //    throw new NotImplementedException();
        //}

        //public bool IsOwner(Guid ownerId)
        //{
        //    throw new NotImplementedException();
        //}

        //#endregion Owner

        //#region AccessControlList

        //public bool HasAccess(AccessLevels accessLevel, Guid userId)
        //{
        //    throw new NotImplementedException();
        //}

        //public void AddAccess(AccessLevels accessLevel, Guid userId)
        //{
        //    throw new NotImplementedException();
        //}

        //public void RemoveAccess(AccessLevels accessLevel, Guid userId)
        //{
        //    throw new NotImplementedException();
        //}

        //#endregion AccessControlList
    }
}
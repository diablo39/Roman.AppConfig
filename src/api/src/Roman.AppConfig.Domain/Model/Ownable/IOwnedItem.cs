using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roman.AppConfig.Domain.Model.Ownable
{
    public interface IOwnedItem
    {
        IEnumerable<Owner> Owners { get; }

        void AddOwner(Owner owner);

        void RemoveOwner(Guid ownerId);

        bool IsOwner(Guid ownerId);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roman.AppConfig.Domain.Model.Securable
{
    internal interface ISecuredItem
    {
        IEnumerable<AccessControlList> AccessControlList { get; }

        bool HasAccess(AccessLevels accessLevel, Guid userId);

        void AddAccess(AccessLevels accessLevel, Guid userId);

        void RemoveAccess(AccessLevels accessLevel, Guid userId);
    }
}
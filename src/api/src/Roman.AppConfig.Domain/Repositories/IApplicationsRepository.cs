using Roman.AppConfig.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roman.AppConfig.Domain.Repositories
{
    internal interface IApplicationsRepository : IRepository<ApplicationRegistration>
    {
    }
}
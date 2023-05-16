using Microsoft.EntityFrameworkCore;
using Roman.AppConfig.Domain.Model;
using Roman.AppConfig.Domain.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roman.AppConfig.Infrastructure.UnitOfWork
{
    internal class QueryDataModel : IQueryDataModel
    {
        public IQueryable<ApplicationRegistration> Applications { get; set; } = new List<ApplicationRegistration>() { }.AsQueryable();
    }
}
using Microsoft.EntityFrameworkCore;
using Roman.AppConfig.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roman.AppConfig.Domain.UnitOfWork
{
    public interface IQueryDataModel
    {
        public IQueryable<ApplicationRegistration> Applications { get; set; }
    }
}
using Microsoft.Extensions.DependencyInjection;
using Roman.AppConfig.Domain.UnitOfWork;
using Roman.AppConfig.Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roman.AppConfig.Infrastructure
{
    public static class Registrations
    {
        public static IServiceCollection RegisterInfrastructureServices(this IServiceCollection services)
        {
            services.AddTransient<IQueryDataModel, QueryDataModel>();

            return services;
        }
    }
}
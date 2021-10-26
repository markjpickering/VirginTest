using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Virgin.Techtest.Core.Interfaces;
using Virgin.Techtest.Data.Interfaces;
using Virgin.Techtest.Data.Repositories;
using Virgin.Techtest.Domain.Mappers;
using Virgin.Techtest.Domain.Model;

namespace Virgin.Techtest.Mappers
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddTechTestMappers(this IServiceCollection services)
        {
            // If we had the time, we'd be more generic and add something which maps all implementations
            // of Imap
            services.AddScoped<IMap<Scenario, ScenarioEntity>, ScenarioToDomainMapper>();

            return services;
        }
    }
}

using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Virgin.Techtest.Data.Interfaces;
using Virgin.Techtest.Data.Repositories;
using Virgin.Techtest.Data.RepositoryReaders;
using Virgin.Techtest.Domain.Model;

namespace Virgin.Techtest.Data
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddTechTestDataLayer(this IServiceCollection services, string scenarioXmlFileName)
        {
            var path = scenarioXmlFileName;

            services.AddScoped<IScenarioRepository, ScenarioXmlRepository>();

            services.AddScoped<ScenarioRepositoryXmlFileReader>(); // There is probably a way to auto wireup concrete classes if need be
            services.AddScoped<IRepositoryXmlFileReader<Scenario>>(
                serviceProvider =>
                {
                    var scenarioRepos = serviceProvider.GetService<ScenarioRepositoryXmlFileReader>();
                    scenarioRepos.FullFilePathAndName = path;
                    return scenarioRepos as IRepositoryXmlFileReader<Scenario>;
                });           

            return services;
        }
    }
}

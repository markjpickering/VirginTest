using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Virgin.Techtest.Data.Interfaces;
using Virgin.Techtest.Domain.Model;

namespace Virgin.Techtest.Ui.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ScenarioController : ControllerBase
    {
        private readonly ILogger<ScenarioController> _logger;
        private readonly IScenarioRepository _repository;

        public ScenarioController(ILogger<ScenarioController> logger,
            IScenarioRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet]
        public IEnumerable<ScenarioEntity> Get()
        {
            var results = GetSummary();
            return results;
        }

        private List<ScenarioEntity> GetSummary()
        {
            var results = _repository.GetAll();

            ///TODO Refactoring required - see comments
            // This linq should not be in the controller
            // but should be elsewhere with tests,
            // but it's here because we are short on time

            // We might also have a seperate view model for the summary
            // rather than use the domain directly
            var summary = results.
                GroupBy(result => 
                            Tuple.Create(result.UserID, result.SampleDate, 
                                result.CreationDate, result.MarketID, result.NetworkLayerID))
                .Select(g => new ScenarioEntity(
                    g.First().ScenarioID,
                    string.Join(", ", 
                                g.Where(s => ! string.IsNullOrEmpty(s.Name))
                                .Select(s => s.Name).Distinct()),
                    g.First().Surname,
                    g.First().Forename,
                    g.First().UserID,
                    g.First().SampleDate,
                    g.First().CreationDate,
                    g.Select(s => s.NumMonths)
                        .Aggregate(0, (current, next) => current + next),
                    g.First().MarketID,
                    g.First().NetworkLayerID))
                .ToList();

            return summary;
        }
    }
}

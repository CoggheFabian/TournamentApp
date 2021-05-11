using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TournamentApp.Model;
using TournamentApp.Repositories.Interfaces.TournamentRepositories;

namespace TournamentApp.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ITournamentRepository _repository;

        //Testing out DI here
        public WeatherForecastController(ITournamentRepository repository)
        {
            this._repository = repository;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            //Again mock code, to see if it works. Im pushing this to main branc in order to show how it's done
            _repository.AddAsync(new Tournament
            {
                Date = DateTime.Now,
                Id = 0,
                Rounds = new List<Round>(),
                TournamentName = "Boe"
            });

            _repository.Save();
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = rng.Next(-20, 55),
                    Summary = Summaries[rng.Next(Summaries.Length)]
                })
                .ToArray();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TournamentApp.Model;
using TournamentApp.Repositories.Interfaces;
using TournamentApp.Services.MatchService;
using TournamentApp.Services.RoundService;
using TournamentApp.Services.UserService;
using TournamentApp.Services.UserTournamentService;
using TournamentApp.Shared.Dtos;

namespace TournamentApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly IUserTournamentService _service;
        private readonly IUserService _userRepository;
        private readonly IRoundService _roundService;
        private readonly IMatchService _matchService;

        //Testing out DI here
        public WeatherForecastController(IUserTournamentService repository, IUserService userRepository, IRoundService roundService, IMatchService matchService)
        {
            _service = repository;
            _userRepository = userRepository;
            _roundService = roundService;
            _matchService = matchService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_roundService.GetAllRoundFromATournament(17));
        }
    }
}
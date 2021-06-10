using System;
using System.Collections.Generic;
using System.Linq;
using TournamentApp.Model;
using TournamentApp.Repositories.Interfaces;
using TournamentApp.Services.Dtos;
using TournamentApp.Services.UserService;

namespace TournamentApp.Services.TournamentRoundService
{
    public class TournamentRoundService : ITournamentRoundService
    {
        private readonly ITournamentRepository _tournamentRepository;
        private readonly IUserService _userService;
        public TournamentRoundService(ITournamentRepository tournamentRepository, IUserService userService)
        {
            _tournamentRepository = tournamentRepository;
            _userService = userService;
        }

        public void CreateTournament(CreateTournamentDto createTournamentDto)
        {
            // Tournament tournament = _tournamentRepository.Add(new Tournament
            // {
            //     Date = createTournamentDto.TournamentDate,
            //     TournamentName = createTournamentDto.Name,
            //
            // }).First();
            // _tournamentRepository.Save();

            List<PlayerInTournamentDto>  playerInTournamentDtos= GetPlayersForTournament(createTournamentDto.Players).ToList();
            Console.WriteLine("boe");
            // Round firstRound = new Round
            // {
            //     Tournament = tournament,
            //     TournamentId = tournament.Id
            // };

        }

        //This could be in a other service
        public IEnumerable<PlayerInTournamentDto> GetPlayersForTournament(List<PlayerInTournamentDto> playerInTournamentDtos)
        {
            foreach (var playerInTournament in playerInTournamentDtos)
            {
                var user = _userService.FindUserById(playerInTournament.Id);
                yield return new PlayerInTournamentDto {Id = user.Id, UserName = user.Name};
            }
        }
    }
}
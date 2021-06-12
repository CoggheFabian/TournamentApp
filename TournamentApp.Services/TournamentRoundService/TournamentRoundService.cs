using System;
using System.Collections.Generic;
using Combinatorics.Collections;
using TournamentApp.Repositories.Interfaces;
using TournamentApp.Services.UserService;
using TournamentApp.Shared.Dtos;

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

            var playerInTournamentDtos = GetPlayersForTournament(createTournamentDto.Players);
            Combinations<PlayerInTournamentDto> combinationsPlayers = new Combinations<PlayerInTournamentDto>(playerInTournamentDtos, 2);

            var matches = GenerateMatchesBasedOnPlayerCombination(combinationsPlayers);

            // Round firstRound = new Round
            // {
            //     Tournament = tournament,
            //     TournamentId = tournament.Id
            // };

        }

        private List<PlayerInMatchDto> GenerateMatchesBasedOnPlayerCombination(Combinations<PlayerInTournamentDto> playersCombination)
        {
            throw new NotImplementedException();
        }

        //This could be in a other service
        public IEnumerable<PlayerInTournamentDto> GetPlayersForTournament(List<PlayerInTournamentDto> playerInTournamentDtos)
        {
            foreach (var playerInTournament in playerInTournamentDtos)
            {
                var user = _userService.FindUserById(playerInTournament.Id); //Change this with 1 Db call thats gets all the users, instead of 5 * a single user.
                yield return new PlayerInTournamentDto {Id = user.Id, UserName = user.Name};
            }
        }
    }
}
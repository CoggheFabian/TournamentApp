using System;
using System.Collections.Generic;
using System.Linq;
using Combinatorics.Collections;
using TournamentApp.Model;
using TournamentApp.Repositories.Interfaces;
using TournamentApp.Services.UserService;
using TournamentApp.Shared.Dtos;

namespace TournamentApp.Services.TournamentRoundService
{
    public class TournamentRoundService : ITournamentRoundService
    {
        private readonly ITournamentRepository _tournamentRepository;
        private readonly IUserService _userService;
        private readonly IMatchRepository _matchRepository;
        public TournamentRoundService(ITournamentRepository tournamentRepository, IUserService userService, IMatchRepository matchRepository)
        {
            _tournamentRepository = tournamentRepository;
            _userService = userService;
            _matchRepository = matchRepository;
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

            _matchRepository.BulkInsertMatches(matches.ToList());

            // Round firstRound = new Round
            // {
            //     Tournament = tournament,
            //     TournamentId = tournament.Id
            // };

        }

        private IEnumerable<Match> GenerateMatchesBasedOnPlayerCombination(Combinations<PlayerInTournamentDto> playersCombination)
        {
            Console.WriteLine("boe");
            foreach (var playerInMatch in playersCombination)
            {
                yield return new Match
                {
                    Player1Id = playerInMatch[0].Id,
                    Player2Id = playerInMatch[1].Id,
                    ScorePlayer1 = 0,
                    ScorePlayer2 = 0,
                    IsMatchPlayed = false,
                    RoundId = 0
                };
            }
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
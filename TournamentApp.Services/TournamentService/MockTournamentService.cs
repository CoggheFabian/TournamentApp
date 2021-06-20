using System;
using System.Collections.Generic;
using System.Linq;
using TournamentApp.Model;
using TournamentApp.Repositories.Implementation.TournamentRepo;
using TournamentApp.Repositories.Interfaces;
using TournamentApp.Shared.Dtos;

namespace TournamentApp.Services.TournamentService
{
    public class MockTournamentService : ITournamentService
    {
        private readonly ITournamentRepository _tournamentRepository;

        public MockTournamentService()
        {
            _tournamentRepository = new MockTournamentRepo();
        }

        public CreatedTournamentDto AddTournament(CreateTournamentDto createTournamentDto)
        {
            var tournament = _tournamentRepository.Add(new Tournament
            {
                Date = createTournamentDto.TournamentDate,
                Id = 3,
                TournamentName = createTournamentDto.Name
            }).First();

            return new CreatedTournamentDto {Name = tournament.TournamentName, TournamentDate = DateTime.Now};
        }
    }
}
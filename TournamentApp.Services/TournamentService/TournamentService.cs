using System.Linq;
using TournamentApp.Model;
using TournamentApp.Repositories.Interfaces;
using TournamentApp.Shared.Dtos;

namespace TournamentApp.Services.TournamentService
{
    public class TournamentService : ITournamentService
    {
        private readonly ITournamentRepository _repository;
        public TournamentService(ITournamentRepository repository)
        {
            _repository = repository;
        }


        public CreatedTournamentDto AddTournament(CreateTournamentDto createTournamentDto)
        {
            Tournament tournament = _repository.Add(new Tournament {Date = createTournamentDto.TournamentDate, TournamentName = createTournamentDto.Name,}).First();
            _repository.Save();
            return new CreatedTournamentDto {Id = tournament.Id, Name = tournament.TournamentName, TournamentDate = tournament.Date};
        }
    }
}
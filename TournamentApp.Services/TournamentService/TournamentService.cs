using TournamentApp.Repositories.Interfaces;
using TournamentApp.Shared.Dtos;

namespace TournamentApp.Services.TournamentService
{
    public class TournamentService : ITournamentService
    {
        private ITournamentRepository _repository;
        public TournamentService(ITournamentRepository repository)
        {
            _repository = repository;
        }
        public CreateTournamentDto AddTournament(CreateTournamentDto dto)
        {

            //Todo validate the request && Make this method complete
            throw new System.NotImplementedException();
        }

    }
}
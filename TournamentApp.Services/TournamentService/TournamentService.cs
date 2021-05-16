using TournamentApp.Repositories.Interfaces;
using TournamentApp.Services.Dtos;

namespace TournamentApp.Services.TournamentService
{
    public class TournamentService : ITournamentService
    {
        private ITournamentRepository _repository;
        public TournamentService(ITournamentRepository repository)
        {
            _repository = repository;
        }
        public BaseTournamentDto AddTournament(CreateTournamentDto dto)
        {

            //Todo validate the request && Make this method complete
            throw new System.NotImplementedException();
        }
    }
}
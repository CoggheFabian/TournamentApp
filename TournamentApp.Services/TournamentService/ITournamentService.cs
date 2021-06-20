using TournamentApp.Shared.Dtos;

namespace TournamentApp.Services.TournamentService
{
    public interface ITournamentService
    {
        CreatedTournamentDto AddTournament(CreateTournamentDto createTournamentDto);
    }
}
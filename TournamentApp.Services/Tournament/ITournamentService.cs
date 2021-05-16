using TournamentApp.Services.Dtos;

namespace TournamentApp.Services.Tournament
{
    public interface ITournamentService
    {
        BaseTournamentDto AddTournament(CreateTournamentDto dto);
    }
}
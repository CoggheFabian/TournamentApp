using TournamentApp.Services.Dtos;

namespace TournamentApp.Services.TournamentService
{
    public interface ITournamentService
    {
        CreateTournamentDto AddTournament(CreateTournamentDto dto);
    }
}
using TournamentApp.Shared.Dtos;

namespace TournamentApp.Services.TournamentRoundService
{
    public interface ITournamentRoundService
    {
        CreatedTournamentDto CreateTournamentWithMainRounds(CreateQuizDto createQuizDto);
    }
}
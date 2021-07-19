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
        private readonly IQuizRepository _quizRepository;

        public MockTournamentService()
        {
            _quizRepository = new MockQuizRepo();
        }

        public CreatedTournamentDto AddTournament(CreateQuizDto createQuizDto)
        {
            var tournament = _quizRepository.Add(new Quiz
            {
                Date = createQuizDto.TournamentDate,
                Id = 3,
                QuizName = createQuizDto.Name
            }).First();

            return new CreatedTournamentDto {Name = tournament.QuizName, TournamentDate = DateTime.Now};
        }
    }
}
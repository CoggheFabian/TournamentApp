using System;
using System.Collections.Generic;
using System.Linq;
using TournamentApp.Model;
using TournamentApp.Repositories.Interfaces;
using TournamentApp.Shared.Dtos;

namespace TournamentApp.Repositories.Implementation.RoundRepo
{
    public class MockRoundRepository : IRoundRepository
    {
        private readonly List<QuizRound> _rounds;

        public MockRoundRepository()
        {
            _rounds = new List<QuizRound>
            {
                new() {Id = 1, Quiz = new Quiz {Id = 1, Date = DateTime.Now, QuizName = "boe"}, QuizId = 1,},
                new() {Id = 2, Quiz = new Quiz {Id = 1, Date = DateTime.Now, QuizName = "boe"}, QuizId = 1,}
            };

        }

        public IQueryable<QuizRound> Get(int id)
        {
            return _rounds.Where(x => x.Id == id).AsQueryable();
        }

        public IQueryable<QuizRound> Add(QuizRound entity)
        {
            _rounds.Add(entity);
            return Get(entity.Id);
        }

        public IQueryable<QuizRound> Delete(int id)
        {
            var round = Get(id);
            _rounds.Remove(Get(id).First());
            return round;
        }

        public IQueryable<QuizRound> Update(int id, QuizRound entity)
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<QuizRound> GetAll()
        {
            return _rounds.AsQueryable();
        }

        public void Save()
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<QuizRound> MakeMainRoundForTournament(CreatedTournamentDto createdTournamentDto)
        {
            return Add(new QuizRound
            {
                QuizId = createdTournamentDto.Id
            });
        }

        public IQueryable<QuizRound> GetAllRoundFromATournament(int tournamentId)
        {
            return _rounds.Where(round => round.QuizId == tournamentId).AsQueryable();
        }
    }
}
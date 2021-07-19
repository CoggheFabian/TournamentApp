using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using TournamentApp.Model;
using TournamentApp.Repositories.Interfaces;
using TournamentApp.Shared.Dtos;

namespace TournamentApp.Repositories.Implementation.RoundRepo
{
    public class RoundRepository : CrudRepository<QuizRound>, IRoundRepository
    {
        private readonly TournamentDbContext _context;

        public RoundRepository(TournamentDbContext context) : base(context)
        {
            _context = context;
        }


        public IQueryable<QuizRound> MakeMainRoundForTournament(CreatedQuizDto createdQuizDto)
        {
            return Add(new QuizRound
            {
                Id = createdQuizDto.Id
            });
        }


        public IQueryable<QuizRound> GetAllRoundFromATournament(int tournamentId)
        {
            return GetAll().Where(round => round.QuizId == tournamentId);
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using TournamentApp.Model;
using TournamentApp.Repositories.Interfaces;
using TournamentApp.Shared.Dtos;

namespace TournamentApp.Repositories.Implementation.RoundRepo
{
    public class RoundRepository : CrudRepository<Round>, IRoundRepository
    {
        private readonly TournamentDbContext _context;

        public RoundRepository(TournamentDbContext context) : base(context)
        {
            _context = context;
        }


        public IQueryable<Round> MakeMainRoundForTournament(CreatedTournamentDto createdTournamentDto)
        {
            return Add(new Round
            {
                Id = createdTournamentDto.Id
            });
        }


        public IQueryable<Round> GetAllRoundFromATournament(int tournamentId)
        {
            return GetAll().Where(round => round.TournamentId == tournamentId);
        }

    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TournamentApp.Model;
using TournamentApp.Repositories.Interfaces;
using TournamentApp.Shared.Dtos;

namespace TournamentApp.Repositories.Implementation.UserTournamentRepo
{
    public class UserTournamentRepository : IUserTournamentRepository
    {
        private TournamentDbContext _context;

        public UserTournamentRepository(TournamentDbContext context)
        {
            _context = context;
        }

        public IQueryable<TournamentWithUserDto> GetAUserWithHisTournaments(int userId)
        {
            return  _context.Matches.Distinct()
                .Join(_context.Rounds, match => match.RoundId, round => round.Id, (match, round) => new {match, round})
                .Join(_context.Tournaments, @t => @t.round.TournamentId, tournaments => tournaments.Id,
                    (@t, tournaments) => new {@t, tournaments})
                .Where(@t => @t.@t.match.Player1Id == userId || @t.@t.match.Player2Id == userId)
                .Select(arg => new TournamentWithUserDto()
                {
                   TournamentId = arg.tournaments.Id,
                    TournamentName = arg.tournaments.TournamentName
                });
        }
    }

}


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

        public  IEnumerable<IGrouping<>> GetAUserWithHisTournaments(int userId)
        {

            return (from match in _context.Matches
                    join c in _context.Rounds on match.RoundId equals c.Id
                    join tournament in _context.Tournaments on c.TournamentId equals tournament.Id
                    where match.Player1Id == userId || match.Player2Id == userId
                    select new {TournamentId = tournament.Id, tournament.TournamentName}).AsEnumerable()
                .GroupBy(arg => arg.TournamentId);

        }
    }

}


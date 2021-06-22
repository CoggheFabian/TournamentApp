using System.Collections.Generic;
using EFCore.BulkExtensions;
using TournamentApp.Model;
using TournamentApp.Repositories.Interfaces;

namespace TournamentApp.Repositories.Implementation.MatchRepo
{
    public class MatchRepository : CrudRepository<Match>, IMatchRepository
    {
        private readonly TournamentDbContext _context;

        public MatchRepository(TournamentDbContext context) : base(context)
        {
            _context = context;
        }

        public void BulkInsertMatches(List<Match> matches)
        {
           _context.BulkInsert(matches);
        }


    }
}
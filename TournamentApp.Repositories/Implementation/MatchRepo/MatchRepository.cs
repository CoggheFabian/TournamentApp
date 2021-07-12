using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks.Sources;
using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
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
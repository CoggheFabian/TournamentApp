using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TournamentApp.Model;
using TournamentApp.Repositories.Interfaces;
using TournamentApp.Shared.Dtos;

namespace TournamentApp.Repositories.Implementation.UserRepo
{
    public class UserRepository : CrudRepository<User>, IUserRepository
    {
        private readonly TournamentDbContext _context;
        public UserRepository(TournamentDbContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<User> GetUsersByEmail(string email)
        {
            return _context.Users.Where(user => user.Email == email).AsQueryable();
        }

        public IEnumerable<User> GetPlayersForTournament(List<int> playersIds)
        {
            return GetAll().ToList().Where(user => playersIds.Contains(user.Id));
        }

        public IEnumerable<Leaderboard> GetLeaderBord()
        {
            return _context.Leaderboards.AsEnumerable();
        }


    }
}
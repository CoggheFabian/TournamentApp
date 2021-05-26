using System;
using System.Collections.Generic;
using System.Linq;
using TournamentApp.Model;
using TournamentApp.Repositories.Interfaces;

namespace TournamentApp.Repositories.Implementation
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

    }
}
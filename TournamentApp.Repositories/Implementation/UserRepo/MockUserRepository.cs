using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using TournamentApp.Model;
using TournamentApp.Repositories.Interfaces;
using TournamentApp.Shared.Dtos;

namespace TournamentApp.Repositories.Implementation.UserRepo
{
    public class MockUserRepository : IUserRepository
    {
        private readonly List<User> _users;

        public MockUserRepository()
        {
            _users = new List<User>();
        }
        public IQueryable<User> Get(int id)
        {
            return _users.Where(user => user.Id == id).AsQueryable();
        }

        public IQueryable<User> Add(User entity)
        {
            _users.Add(entity);
            return entity.ToQueryable();
        }

        public IQueryable<User> Delete(int id)
        {
            var user = Get(id);
            _users.Remove(user.First());
            return user;

        }

        public IQueryable<User> Update(int id, User entity)
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<User> GetAll()
        {
            return _users.AsQueryable(); //Could also copy the array, to make sure they dont edit the data;
        }

        public void Save()
        {
            //A save does nothing with mock data.
            throw new System.NotImplementedException();
        }

        public IQueryable<User> GetUsersByEmail(string email)
        {
            return _users.Where(user => user.Email == email).AsQueryable();
        }

        public IEnumerable<User> GetPlayersForTournament(List<int> playersIds)
        {
            throw new System.NotImplementedException();
        }
    }
}
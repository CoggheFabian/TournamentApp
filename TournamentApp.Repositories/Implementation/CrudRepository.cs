using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using TournamentApp.Model;
using TournamentApp.Repositories.Interfaces;

namespace TournamentApp.Repositories.Implementation
{
    public class CrudRepository<T> : ICrudRepository<T> where T : EntityBase
    {
        private readonly TournamentDbContext _context;

        protected CrudRepository(TournamentDbContext context)
        {
            _context = context;
        }


        public IQueryable<T> Get(int id)
        {
            return _context.Set<T>().FirstOrDefault(e => e.Id == id).ToQueryable();
        }

        public IQueryable<T> Add(T entity)
        {
            _context.Set<T>().Add(entity);
            return entity.ToQueryable();
        }

        public IQueryable<T> Delete(int id)
        {
            var entityToDelete = _context.Set<T>().FirstOrDefault(e => e.Id == id);
            if (entityToDelete != null) _context.Set<EntityBase>().Remove(entityToDelete);
            return entityToDelete.ToQueryable();
        }

        public IQueryable<T> Update(int id, T entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>().AsEnumerable() as IQueryable<T>;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
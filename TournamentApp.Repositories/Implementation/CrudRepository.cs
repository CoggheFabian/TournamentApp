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


        public EntityBase GetAsync(int id)
        {
            return _context.Set<T>().FirstOrDefault(e => e.Id == id);
        }

        public void AddAsync(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void DeleteAsync(int id)
        {
            var entityToDelete = _context.Set<T>().FirstOrDefault(e => e.Id == id);
            if (entityToDelete != null)
            {
                _context.Set<EntityBase>().Remove(entityToDelete);
            }
        }

        public void UpdateAsync(int id, T entity)
        {
            _context.Set<T>().FirstOrDefault(e => e.Id == entity.Id);
        }

        public EntityEntry<EntityBase> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public void Save()
        {
            _context.SaveChangesAsync();
        }
    }
}
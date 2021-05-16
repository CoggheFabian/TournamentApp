using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using TournamentApp.Model;

namespace TournamentApp.Repositories.Interfaces
{
    public interface ICrudRepository <T> where T : EntityBase
    {
        IQueryable<T> Get(int id);
        IQueryable<EntityEntry<T>> Add(T entity);
        IQueryable<T> Delete(int id);
        IQueryable<T> Update(int id, T entity);
        IQueryable<T> GetAll();
        void Save();
    }
}
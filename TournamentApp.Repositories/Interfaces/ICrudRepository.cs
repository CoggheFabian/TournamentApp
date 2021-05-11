using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using TournamentApp.Model;

namespace TournamentApp.Repositories.Interfaces
{
    public interface ICrudRepository <T> where T : EntityBase
    {
        EntityBase GetAsync(int id);
        void AddAsync(T entity);
        void DeleteAsync(int id);
        void UpdateAsync(int id, T entity);
        EntityEntry<EntityBase> GetAll();
        void Save();
    }
}
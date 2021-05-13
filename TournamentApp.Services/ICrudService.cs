using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using TournamentApp.Model;
using TournamentApp.Services.Dtos;

namespace TournamentApp.Services
{
    public interface ICrudService<ET, ST> where ET : EntityBase where ST : DtoBase
    {
        Task<ST>  GetAsync(int id);
        Task AddAsync(ET entity);
        Task DeleteAsync(int id);
        Task UpdateAsync(int id, ET entity);
        List<ST> GetAll();
        Task Save();
    }
}
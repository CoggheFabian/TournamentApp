using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TournamentApp.Repositories
{
    public static class ObjectExtensionMethods
    {
        public static IQueryable<T> ToQueryable<T>(this T instance)
        {
            return new List<T> { instance }.AsQueryable();
        }
    }
}
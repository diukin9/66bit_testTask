using PlayerCatalog.Data.Models;
using PlayerCatalog.Data.Models.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlayerCatalog.Data.Abstraction
{
    public interface ITeamRepository<T> where T : Team
    {
        Task<T> FindOrCreate(string query, Language language);
        Task<List<T>> All();
        void Add(T model, Language language);
    }
}

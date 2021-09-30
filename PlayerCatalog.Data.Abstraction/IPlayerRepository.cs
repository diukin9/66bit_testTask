using PlayerCatalog.Data.Models;
using PlayerCatalog.Data.Models.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlayerCatalog.Data.Abstraction
{
    public interface IPlayerRepository<T> where T : Player
    {
        Task<T> FindById(int id);
        Task<List<T>> All();
        void Update(T model);
        void Add(T model, Language language);
    }
}

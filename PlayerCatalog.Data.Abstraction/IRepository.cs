using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlayerCatalog.Data.Abstraction
{
    public interface IRepository<T>
    {
        Task<T> FindById(int id);
        Task<List<T>> All();
        void Update(T model);
        void Add(T model);
    }
}
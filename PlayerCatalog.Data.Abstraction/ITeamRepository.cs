using PlayerCatalog.Data.Models;
using System.Threading.Tasks;

namespace PlayerCatalog.Data.Abstraction
{
    public interface ITeamRepository : IRepository<Team>
    {
        Task<Team> FindOrCreate(string query);
    }
}

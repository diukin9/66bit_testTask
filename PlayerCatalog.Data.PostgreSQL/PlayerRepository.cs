using Microsoft.EntityFrameworkCore;
using PlayerCatalog.Data.Abstraction;
using PlayerCatalog.Data.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlayerCatalog.Data.PostgreSQL
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly DataContext _context;

        public PlayerRepository(DataContext context)
        {
            _context = context;
        }

        public async void Add(Player model)
        {
            await _context.Players.AddAsync(model);
            _context.SaveChanges();
        }

        public async Task<List<Player>> All() 
            => await _context.Players.Include(x => x.Team).ToListAsync();

        public async Task<Player> FindById(int id)
        {
            return await _context.Players.Include(x => x.Team)
                .Where(y => y.Id == id)
                .FirstOrDefaultAsync();
        }

        public void Update(Player model)
        {
            _context.Players.Update(model);
            _context.SaveChanges();
        }
    }
}

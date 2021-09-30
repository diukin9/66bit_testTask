using Microsoft.EntityFrameworkCore;
using PlayerCatalog.Data.Abstraction;
using PlayerCatalog.Data.Models;
using PlayerCatalog.Data.Models.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlayerCatalog.Data.PostgreSQL
{
    public class PlayerRepository : IPlayerRepository<Player>
    {
        private readonly DataContext _context;

        public PlayerRepository(DataContext context)
        {
            _context = context;
        }

        public async void Add(Player model, Language language)
        {
            var localization = new PlayerLocalization()
            {
                Name = model.Name,
                Surname = model.Surname,
                Language = language
            };
            model.Localization = new List<PlayerLocalization>() { localization };
            await _context.Players.AddAsync(model);
            _context.SaveChanges();
        }

        public async Task<List<Player>> All()
        {
            var players = await _context.Players
                .Include(x => x.Team).ThenInclude(x => x.Localization)
                .Include(x => x.Localization)
                .ToListAsync();
            return players;
        }

        public async Task<Player> FindById(int id)
        {
            var player = await _context.Players
                .Include(x => x.Localization)
                .Include(x => x.Team)
                .FirstOrDefaultAsync(y => y.Id == id);
            return player;
        }

        public void Update(Player model)
        {
            _context.Players.Update(model);
            _context.SaveChanges();
        }
    }
}

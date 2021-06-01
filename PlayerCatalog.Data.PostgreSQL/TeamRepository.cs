using Microsoft.EntityFrameworkCore;
using PlayerCatalog.Data.Abstraction;
using PlayerCatalog.Data.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlayerCatalog.Data.PostgreSQL
{
    public class TeamRepository : ITeamRepository
    {
        private readonly DataContext _context;

        public TeamRepository(DataContext context)
        {
            _context = context;
        }

        public async void Add(Team model)
        {
            await _context.Teams.AddAsync(model);
            _context.SaveChanges();
        }

        public async Task<List<Team>> All() 
            => await _context.Teams.ToListAsync();

        public async Task<Team> FindById(int id)
        {
            return await _context.Teams.Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }

        public void Update(Team model)
        {
            _context.Teams.Update(model);
            _context.SaveChanges();
        }

        public async Task<Team> FindOrCreate(string query)
        {
            var team = await _context.Teams
                .Where(x => x.Name.ToLower() == query.ToLower())
                .FirstOrDefaultAsync();
            return team ?? new Team(query);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using PlayerCatalog.Data.Abstraction;
using PlayerCatalog.Data.Models;
using PlayerCatalog.Data.Models.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlayerCatalog.Data.PostgreSQL
{
    public class TeamRepository : ITeamRepository<Team>
    {
        private readonly DataContext _context;

        public TeamRepository(DataContext context)
        {
            _context = context;
        }

        public async void Add(Team model, Language language)
        {
            var localization = new TeamLocalization()
            {
                Language = language,
                Name = model.Name
            };
            model.Localization = new List<TeamLocalization>() { localization };
            await _context.Teams.AddAsync(model);
            _context.SaveChanges();
        }

        public async Task<List<Team>> All()
        {
            var teams = await _context.Teams
                .Include(x => x.Localization)
                .ToListAsync();
            return teams;
        }

        public async Task<Team> FindOrCreate(string query, Language language)
        {
            var team = await _context.Teams
                .FirstOrDefaultAsync(x => x.Name.ToLower() == query.ToLower());
            if (team == null)
            {
                team = new Team(query);
                this.Add(team, language);
            }
            return team;
        }
    }
}

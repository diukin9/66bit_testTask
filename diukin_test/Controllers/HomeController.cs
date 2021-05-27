using diukin_test.Data;
using diukin_test.Models;
using diukin_test.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace diukin_test.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataContext _context;

        public HomeController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> Index() 
        {
            return View(new PlayerViewModel()
            {
                AllTeams = await _context.Teams.Select(x => x.Name).ToListAsync()
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(PlayerViewModel model)
        {
            var splitDate = model.Birthdate.Split("-")
                .Select(x => int.Parse(x))
                .ToArray();
            var date = new DateTime(splitDate[0], splitDate[1], splitDate[2]);
            if (date.CompareTo(DateTime.Now) > 0)
                ModelState.AddModelError("", "Такой футболист еще не родился :)");
            if (!ModelState.IsValid) return View(model);
            var team = await GetTeam(model.Team);
            await _context.Players.AddAsync(new Player()
            {
                Id = Guid.NewGuid().ToString(),
                Name = model.Name,
                Surname = model.Surname,
                Team = team,
                Gender = model.Gender,
                Nation = model.Nation,
                Birthdate = date
            });
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<ActionResult> List() 
            => View(await _context.Players.Include(x => x.Team).ToListAsync());

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var player = await _context.Players.Include(x => x.Team)
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
            if (player == null) 
                return RedirectToAction("List");
            return View(new PlayerViewModel()
            {
                Id = id,
                Name = player.Name,
                Surname = player.Surname,
                Gender = player.Gender,
                Nation = player.Nation,
                Birthdate = player.Birthdate.ToString("yyyy-MM-dd"),
                Team = player.Team.Name,
                AllTeams = await _context.Teams.Select(x => x.Name).ToListAsync()
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(PlayerViewModel model)
        {
            var splitDate = model.Birthdate.Split("-")
                .Select(x => int.Parse(x))
                .ToArray();
            var date = new DateTime(splitDate[0], splitDate[1], splitDate[2]);
            if (date.CompareTo(DateTime.Now) > 0)
                ModelState.AddModelError("", "Такой футболист еще не родился :)");
            if (!ModelState.IsValid) 
                return View(model);
            var team = await GetTeam(model.Team);
            var player = await _context.Players.Include(x => x.Team)
                .Where(x => x.Id == model.Id)
                .FirstOrDefaultAsync();
            if (player == null) 
                return RedirectToAction("List");
            player.Name = model.Name;
            player.Surname = model.Surname;
            player.Team = team;
            player.Gender = model.Gender;
            player.Nation = model.Nation;
            player.Birthdate = date;
            _context.Players.Update(player);
            await _context.SaveChangesAsync();
            return RedirectToAction("List");
        }

        [NonAction]
        private async Task<Team> GetTeam(string teamName)
        {
            var team = await _context.Teams
                .Where(x => x.Name.ToLower() == teamName.ToLower())
                .FirstOrDefaultAsync();
            if (team == null)
            {
                team = new Models.Team()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = teamName
                };
                await _context.Teams.AddAsync(team);
                await _context.SaveChangesAsync();
            }
            return team;
        }
    }
}

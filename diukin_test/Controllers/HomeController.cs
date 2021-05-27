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
        public async Task<ActionResult> Index() => View(new PlayerViewModel() 
        { 
            AllTeams = await _context.Teams.Select(x => x.Name).ToListAsync() 
        });

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(PlayerViewModel model)
        {
            var date = model.Birthdate.Split("-")
                .Select(x => int.Parse(x)).ToArray();
            IsValid(date, model.Name, model.Surname, model.Team);
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
                Birthdate = new DateTime(date[0], date[1], date[2])
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
            if (player == null) return RedirectToAction("List");
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
            var date = model.Birthdate.Split("-")
                .Select(x => int.Parse(x)).ToArray();
            IsValid(date, model.Name, model.Surname, model.Team);
            if (!ModelState.IsValid) return View(model);
            var team = await GetTeam(model.Team);
            var player = await _context.Players.Include(x => x.Team)
                .Where(x => x.Id == model.Id).FirstOrDefaultAsync();
            if (player == null) return RedirectToAction("List");
            player.Name = model.Name;
            player.Surname = model.Surname;
            player.Team = team;
            player.Gender = model.Gender;
            player.Nation = model.Nation;
            player.Birthdate = new DateTime(date[0], date[1], date[2]);
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

        [NonAction]
        private void IsValid(int[] birthdate, params string[] strings)
        {
            foreach (var item in strings)
            {
                if (item.Length < 1)
                {
                    ModelState.AddModelError(string.Empty, 
                        "Необходимо заполнить все поля!");
                    break;
                }
            }
            var date = new DateTime(birthdate[0], birthdate[1], birthdate[2]);
            if (date.CompareTo(DateTime.Now) > 0)
                ModelState.AddModelError(string.Empty, 
                    "Такой футболист еще не родился :)");
        }
    }
}

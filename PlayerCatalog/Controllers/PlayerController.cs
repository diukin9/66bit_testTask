using Microsoft.AspNetCore.Mvc;
using PlayerCatalog.Data.Models;
using PlayerCatalog.Data.PostgreSQL;
using PlayerCatalog.Hubs;
using PlayerCatalog.ViewModels;
using System.Threading.Tasks;

namespace PlayerCatalog.Controllers
{
    public class PlayerController : Controller
    {
        private readonly DataContext _context;
        private readonly TeamRepository _teamContext;
        private readonly PlayerRepository _playerContext;
        private readonly SendFromHub _hubContext;

        public PlayerController(DataContext context, TeamRepository teamContext, 
            PlayerRepository playerContext, SendFromHub hubContext)
        {
            _playerContext = playerContext;
            _teamContext = teamContext;
            _hubContext = hubContext;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> AddPlayer()
        {
            return View(new PlayerViewModel()
            {
                AllTeams = await _teamContext.All()
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddPlayer(PlayerViewModel model)
        {
            if (!ModelState.IsValid) 
                return View(model);
            var team = await _teamContext.FindOrCreate(model.Team);
            var player = new Player(model.Name, model.Surname, model.Gender,
                team, model.Nation, model.Birthdate);
            _playerContext.Add(player);
            _hubContext.SendToList(player);
            return RedirectToAction("PlayerList");
        }

        [HttpGet]
        public async Task<ActionResult> PlayerList()
            => View(await _playerContext.All());

        [HttpGet]
        public async Task<IActionResult> EditPlayer(int id)
        {
            var player = await _playerContext.FindById(id);
            if (player == null)
                return RedirectToAction("PlayerList");
            var allTeams = await _teamContext.All();
            var model = new PlayerViewModel(id, player.Name, player.Surname,
                player.Gender, player.Team?.Name, player.Nation, 
                player.Birthdate, allTeams);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPlayer(PlayerViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var player = await _playerContext.FindById(model.Id);
            if (player == null)
                return RedirectToAction("PlayerList");
            player.Name = model.Name;
            player.Surname = model.Surname;
            player.Team = await _teamContext.FindOrCreate(model.Team);
            player.Gender = model.Gender;
            player.Nation = model.Nation;
            player.Birthdate = model.Birthdate;
            _playerContext.Update(player);
            return RedirectToAction("PlayerList");
        }
    }
}

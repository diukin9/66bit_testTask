using AutoMapper;
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
        private readonly TeamRepository _teamContext;
        private readonly PlayerRepository _playerContext;
        private readonly SendFromHub _hubContext;
        private readonly IMapper _mapper;

        public PlayerController(TeamRepository teamContext, IMapper mapper,
            PlayerRepository playerContext, SendFromHub hubContext)
        {
            _playerContext = playerContext;
            _teamContext = teamContext;
            _hubContext = hubContext;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> AddPlayer()
        {
            var model = new PlayerViewModel()
            {
                AllTeams = await _teamContext.All()
            };
            return View(nameof(AddPlayer), model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddPlayer(PlayerViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var player = _mapper.Map<Player>(model);
            player.Team = await _teamContext.FindOrCreate(model.Team);
            _playerContext.Add(player);
            _hubContext.SendToList(player);
            return RedirectToAction(nameof(PlayerList));
        }

        [HttpGet]
        public async Task<ActionResult> PlayerList()
        {
            var players = await _playerContext.All();
            return View(nameof(PlayerList), players);
        }

        [HttpGet]
        public async Task<IActionResult> EditPlayer(int id)
        {
            var player = await _playerContext.FindById(id);
            if (player == null)
            {
                return RedirectToAction("PlayerList");
            }
            var model = _mapper.Map<PlayerViewModel>(player);
            model.AllTeams = await _teamContext.All();
            return View(nameof(EditPlayer), model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPlayer(PlayerViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var player = await _playerContext.FindById(model.Id);
            if (player == null)
            {
                return RedirectToAction("PlayerList");
            }
            player.Name = model.Name;
            player.Surname = model.Surname;
            player.Team = await _teamContext.FindOrCreate(model.Team);
            player.Gender = model.Gender;
            player.Nation = model.Nation;
            player.Birthdate = model.Birthdate;
            _playerContext.Update(player);
            return RedirectToAction(nameof(PlayerList));
        }
    }
}

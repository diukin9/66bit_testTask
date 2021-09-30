using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlayerCatalog.Data.Models;
using PlayerCatalog.Data.Models.Enums;
using PlayerCatalog.Data.PostgreSQL;
using PlayerCatalog.Hubs;
using PlayerCatalog.ViewModels;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace PlayerCatalog.Controllers
{
    public class PlayerController : Controller
    {
        private readonly TeamRepository _teamContext;
        private readonly PlayerRepository _playerContext;
        private readonly SendFromHub _hubContext;
        private readonly IMapper _mapper;
        private readonly Language _language;

        public PlayerController(TeamRepository teamContext, IMapper mapper,
            PlayerRepository playerContext, SendFromHub hubContext)
        {
            _playerContext = playerContext;
            _teamContext = teamContext;
            _hubContext = hubContext;
            _mapper = mapper;
            _language = CultureInfo.CurrentCulture.Name switch
            {
                "en" => Language.English,
                "de" => Language.German,
                _ => Language.Russian
            };
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
            player.Team = await _teamContext.FindOrCreate(model.Team, _language);
            _playerContext.Add(player, _language);
            _hubContext.SendToList(player);
            return RedirectToAction(nameof(PlayerList));
        }

        [HttpGet]
        public async Task<ActionResult> PlayerList()
        {
            var players = await _playerContext.All();
            var model = players
                .Where(x => x.Localization.Any(y => y.Language == _language)
                    && x.Team.Localization.Any(y => y.Language == _language))
                .Select(x => new PlayerInfo(x, _language))
                .ToList();
            return View(nameof(PlayerList), model);
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
            model.Team = player.Team?.Name ?? string.Empty;
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
            player.Team = await _teamContext.FindOrCreate(model.Team, _language);
            player.Gender = model.Gender;
            player.Nation = model.Nation;
            player.Birthdate = model.Birthdate;
            _playerContext.Update(player);
            return RedirectToAction(nameof(PlayerList));
        }
    }
}

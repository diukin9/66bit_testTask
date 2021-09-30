using PlayerCatalog.Data.Models;
using PlayerCatalog.Data.Models.Enums;
using System;
using System.Linq;

namespace PlayerCatalog.ViewModels
{
    public class PlayerInfo
    {
        public int Id { get; set; }
        public string Team { get; set; }
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public Nation Nation { get; set; }
        public string Surname { get; set; }
        public DateTime Birthdate { get; set; }

        public PlayerInfo()
        {

        }

        public PlayerInfo(Player player, Language language)
        {
            var localizedPlayer = player.Localization
                .FirstOrDefault(y => y.Language == language);
            var localizedTeam = player.Team.Localization
                .FirstOrDefault(y => y.Language == language);

            Birthdate = player.Birthdate;
            Gender = player.Gender;
            Id = player.Id;
            Nation = player.Nation;
            Name = localizedPlayer?.Name ?? player.Name;
            Surname = localizedPlayer?.Surname ?? player.Surname;
            Team = localizedTeam?.Name ?? player.Team.Name;
        }
    }
}

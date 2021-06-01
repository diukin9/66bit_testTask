using System;
using Microsoft.AspNetCore.SignalR;
using PlayerCatalog.Data.Models;

namespace PlayerCatalog.Hubs
{
    public class SendFromHub
    {
        private readonly IHubContext<PlayerHub> _hubContext;

        public SendFromHub(IHubContext<PlayerHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async void SendToList(Player player)
        {
            var name = player.Name;
            var surname = player.Surname;
            var id = player.Id.ToString();
            var team = player.Team?.Name ?? "Нет команды";
            var nation = player.Nation == 0 ? "Россия" :
                (int) player.Nation == 1 ? "США" : "Италия";
            var birthdate = player.Birthdate.ToString("dd.MM.yyyy");
            var gender = player.Gender == 0 ? "Мужской" : "Женский";
            await _hubContext.Clients.All.SendAsync("putToList", name, 
                surname, gender, team, nation, birthdate, id);
        }
    }
}

﻿using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.SignalR;
using System.Linq;
using System.Threading.Tasks;

namespace diukin_test.Hubs
{
    public class PlayerHub : Hub
    {
        public async Task sendToList(string name, string surname,
            string gender, string team, string nation, string birthdate)
        {
            var date = birthdate.Split("-");
            birthdate = $"{date[2]}.{date[1]}.{date[0]}";
            await Clients.All.SendAsync("putToList", name, surname, gender, team, nation, birthdate);
        }
    }
}

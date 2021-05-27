using diukin_test.Models;
using System.Collections.Generic;

namespace diukin_test.ViewModels
{
    public class PlayerViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public Gender Gender { get; set; }
        public string Team { get; set; }
        public List<string> AllTeams { get; set; }
        public string Nation { get; set; }
        public string Birthdate { get; set; }
    }
}

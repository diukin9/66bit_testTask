using PlayerCatalog.Data.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace PlayerCatalog.Data.Models
{
    public class Player
    {
        [Key]
        public int Id { get; set; }
        public Team Team { get; set; }
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public Nation Nation { get; set; }
        public string Surname { get; set; }
        public DateTime Birthdate { get; set; }

        public Player()
        {

        }

        public Player(string name, string surname, Gender gender, 
            Team team, Nation nation, DateTime birthdate)
        {
            this.Name = name;
            this.Team = team;
            this.Gender = gender;
            this.Nation = nation;
            this.Surname = surname;
            this.Birthdate = birthdate;
        }
    }
}

using PlayerCatalog.Data.Models;
using PlayerCatalog.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PlayerCatalog.ViewModels
{
    public class PlayerViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "Некорректное имя!")]
        public string Name { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "Некорректная фамилия!")]
        public string Surname { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "Некорректная команда!")]
        public string Team { get; set; }
        [Required]
        public Gender Gender { get; set; }
        public List<Team> AllTeams { get; set; }
        [Required]
        public Nation Nation { get; set; }
        [Required]
        public DateTime Birthdate { get; set; }

        public PlayerViewModel()
        {

        }

        public PlayerViewModel(int id, string name, string surname, Gender gender, 
            string team, Nation nation, DateTime birthdate, List<Team> allTeams)
        {
            this.Id = id;
            this.Name = name;
            this.Team = team;
            this.Gender = gender;
            this.Nation = nation;
            this.Surname = surname;
            this.AllTeams = allTeams;
            this.Birthdate = birthdate;
        }
    }
}

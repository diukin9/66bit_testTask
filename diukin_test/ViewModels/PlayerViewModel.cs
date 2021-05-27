using diukin_test.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace diukin_test.ViewModels
{
    public class PlayerViewModel
    {
        public string Id { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Некорректное имя!")]
        public string Name { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Некорректная фамилия!")]
        public string Surname { get; set; }
        public Gender Gender { get; set; }
        public string Team { get; set; }
        public List<string> AllTeams { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Некорректная национальность!")]
        public string Nation { get; set; }
        public string Birthdate { get; set; }
    }
}

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
    }
}

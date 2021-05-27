using System;
using System.ComponentModel.DataAnnotations;

namespace diukin_test.Models
{
    public class Player
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public Gender Gender { get; set; }
        public Team Team { get; set; }
        public string Nation { get; set; }
        public DateTime Birthdate { get; set; }
    }
}

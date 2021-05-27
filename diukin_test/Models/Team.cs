using System.ComponentModel.DataAnnotations;

namespace diukin_test.Models
{
    public class Team
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
    }
}

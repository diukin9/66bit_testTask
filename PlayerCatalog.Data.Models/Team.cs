using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PlayerCatalog.Data.Models
{
    public class Team
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<TeamLocalization> Localization { get; set; }

        public Team()
        {

        }

        public Team(string name)
        {
            this.Name = name;
        }
    }
}

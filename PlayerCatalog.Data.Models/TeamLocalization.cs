using PlayerCatalog.Data.Models.Enums;

namespace PlayerCatalog.Data.Models
{
    public class TeamLocalization
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Language Language { get; set; }
    }
}

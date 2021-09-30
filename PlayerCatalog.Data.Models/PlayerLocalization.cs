using PlayerCatalog.Data.Models.Enums;

namespace PlayerCatalog.Data.Models
{
    public class PlayerLocalization
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public Language Language { get; set; }
    }
}

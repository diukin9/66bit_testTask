using AutoMapper;
using PlayerCatalog.Data.Models;
using PlayerCatalog.ViewModels;

namespace PlayerCatalog.MappingProfiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            this.PlayerMappingProfile();
        }

        private void PlayerMappingProfile()
        {
            CreateMap<PlayerViewModel, Player>()
                .ForMember(x => x.Name, y => y.MapFrom(src => src.Name))
                .ForMember(x => x.Surname, y => y.MapFrom(src => src.Surname))
                .ForMember(x => x.Gender, y => y.MapFrom(src => src.Gender))
                .ForMember(x => x.Nation, y => y.MapFrom(src => src.Nation))
                .ForMember(x => x.Birthdate, y => y.MapFrom(src => src.Birthdate));

            CreateMap<Player, PlayerViewModel>()
                .ForMember(x => x.Id, y => y.MapFrom(src => src.Id))
                .ForMember(x => x.Name, y => y.MapFrom(src => src.Name))
                .ForMember(x => x.Surname, y => y.MapFrom(src => src.Surname))
                .ForMember(x => x.Gender, y => y.MapFrom(src => src.Gender))
                .ForMember(x => x.Team, y => y.MapFrom(src => src.Team == null ? string.Empty : src.Team.Name))
                .ForMember(x => x.Nation, y => y.MapFrom(src => src.Nation))
                .ForMember(x => x.Birthdate, y => y.MapFrom(src => src.Birthdate));
        }
    }
}

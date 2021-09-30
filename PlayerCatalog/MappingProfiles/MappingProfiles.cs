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
            CreateMap<Player, PlayerViewModel>()
                .ForMember(x => x.Name, y => y.MapFrom(src => src.Name))
                .ForMember(x => x.Surname, y => y.MapFrom(src => src.Surname))
                .ForMember(x => x.Gender, y => y.MapFrom(src => src.Gender))
                .ForMember(x => x.Nation, y => y.MapFrom(src => src.Nation))
                .ForMember(x => x.Birthdate, y => y.MapFrom(src => src.Birthdate))
                .ForMember(x => x.AllTeams, y => y.Ignore())
                .ForMember(x => x.Id, y => y.Ignore())
                .ForMember(x => x.Team, y => y.Ignore());

            CreateMap<PlayerViewModel, Player>()
                .ForMember(x => x.Id, y => y.MapFrom(src => src.Id))
                .ForMember(x => x.Name, y => y.MapFrom(src => src.Name))
                .ForMember(x => x.Surname, y => y.MapFrom(src => src.Surname))
                .ForMember(x => x.Gender, y => y.MapFrom(src => src.Gender))
                .ForMember(x => x.Nation, y => y.MapFrom(src => src.Nation))
                .ForMember(x => x.Birthdate, y => y.MapFrom(src => src.Birthdate))
                .ForMember(x => x.Team, y => y.Ignore());
        }
    }
}

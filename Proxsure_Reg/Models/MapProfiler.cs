using AutoMapper;
using Proxsure_Reg.Models.ViewModels;

namespace Proxsure_Reg.Models {
    public class MapProfiler : Profile {
        public MapProfiler () {
            CreateMap<RegistrationViewModel, ApplicationUser> ().ForMember (dest => dest.UserName, map => map.MapFrom (src => src.Username)).ReverseMap();
        }
    }
}
using AutoMapper;
using Proxsure_API.Models.SuscriptionModels;

namespace Proxsure_API.Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Suscription, SuscriptionDTO>().ReverseMap();
        }
    }
}
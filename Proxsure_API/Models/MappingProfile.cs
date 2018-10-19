using AutoMapper;
using Proxsure_API.Models.Suscriptions;

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
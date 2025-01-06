using AutoMapper;
using MagicVilla_Api_Udemy.Models;
using MagicVilla_Api_Udemy.Models.DTO;

namespace MagicVilla_Api_Udemy
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<VillaModel, VillaDTO>();
            CreateMap<VillaDTO, VillaModel>();

            CreateMap<VillaModel, VillaCreateDTO>().ReverseMap();
            CreateMap<VillaModel, VillaUpdateDTO>().ReverseMap();

            // This is auto mapping for villa number
            CreateMap<VillaNumber, VillaNumberDTO>().ReverseMap(); ;
            CreateMap<VillaNumber, VillaNumberCreateDTO>().ReverseMap();
            CreateMap<VillaNumber, VillaNumberUpdateDTO>().ReverseMap();
        }
    }
}

using AutoMapper;
using Cental.DtoLayer.BannerDtos;
using Cental.DtoLayer.BrandDtos;
using Cental.EntityLayer.Entities;

namespace Cental.WebUI.Mappings
{
    public class BrandMapping:Profile
    {
        public BrandMapping()
        {
            CreateMap<Brand, ResultBrandDto>().ReverseMap();
            CreateMap<Brand, CreateBrandDto>().ReverseMap();
            CreateMap<Brand, UpdateBrandDto>().ReverseMap();
            
        }
    }
}

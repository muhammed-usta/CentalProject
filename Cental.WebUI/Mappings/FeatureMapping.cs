using AutoMapper;
using Cental.DtoLayer.BrandDtos;
using Cental.DtoLayer.FeatureDtos;
using Cental.EntityLayer.Entities;
using NuGet.Protocol.Plugins;

namespace Cental.WebUI.Mappings
{
    public class FeatureMapping:Profile
    {
        public FeatureMapping()
        {
            CreateMap<Feature, ResultFeatureDto>().ReverseMap();
            CreateMap<Feature, CreateFeatureDto>().ReverseMap();
            CreateMap<Feature, UpdateFeatureDto>().ReverseMap();
        }
    }
}

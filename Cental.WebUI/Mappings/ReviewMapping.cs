using AutoMapper;
using Cental.DtoLayer.ReviewDtos;
using Cental.EntityLayer.Entities;

namespace Cental.WebUI.Mappings
{
    public class ReviewMapping:Profile
    {
        public ReviewMapping()
        {
            CreateMap<Review, CreateReviewDto>().ReverseMap();
            CreateMap<Review, UpdateReviewDto>().ReverseMap();
            CreateMap<Review, ResultReviewDto>().ReverseMap();
        }
    }
}

using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.SocialMediaDtos;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.ViewComponents.Default
{
    public class _DefaultFooterSocialComponent(ISocialMediaService _socialMediaService,IMapper _mapper):ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var values = _socialMediaService.TGetAll();
            var socials = _mapper.Map<List<ResultSocialMediaDto>>(values);
            return View(socials);
        }
    }
}

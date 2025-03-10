using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.ContactDtos;
using Cental.DtoLayer.FeatureDtos;
using Cental.DtoLayer.SocialMediaDtos;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.ViewComponents.Contact
{
    public class _ContactSocialPartialComponent(ISocialMediaService _socialMediaService, IMapper _mapper):ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var values = _socialMediaService.TGetAll();
            var socialMedias = _mapper.Map<List<ResultSocialMediaDto>>(values);
            return View(socialMedias);
        }
    }
}

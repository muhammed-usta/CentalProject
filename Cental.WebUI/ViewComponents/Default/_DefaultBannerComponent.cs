using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.BannerDtos;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.ViewComponents.Default
{
    public class _DefaultBannerComponent(IBannerService _bannerService,IMapper _mapper):ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var values = _bannerService.TGetAll();
            var banners=_mapper.Map<List<ResultBannerDto>>(values);
              return View(banners);
        }
    }
}

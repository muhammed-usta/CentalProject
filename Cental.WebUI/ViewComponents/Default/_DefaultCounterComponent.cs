using Cental.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.ViewComponents.Default
{
    public class _DefaultCounterComponent(ICounterService _counterService):ViewComponent
    {
         public IViewComponentResult Invoke()
        {
            ViewBag.GetUserCount = _counterService.TGetUserCount();
            ViewBag.GetCarCount = _counterService.TGetCarCount();
            ViewBag.GetReviewCount = _counterService.TGetReviewCount();
            ViewBag.GetBookingCount = _counterService.TGetBookingCount();
            return View();
        }
    }
}

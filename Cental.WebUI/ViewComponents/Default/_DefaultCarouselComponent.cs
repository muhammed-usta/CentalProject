using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.Enums;
using Cental.EntityLayer.Entities;
using Cental.WebUI.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Cental.WebUI.ViewComponents.Default
{
    public class _DefaultCarouselComponent(ICarService _carService):ViewComponent
    {
      
        public IViewComponentResult Invoke()
        {
            var carList = _carService.TGetCarsWithBrands();

            ViewBag.CarTypes = carList.Select(car => new SelectListItem
            {
                Value = car.CarId.ToString(),
                Text = $"{car.Brand.BrandName} {car.ModelName} {car.Year} {car.Transmission} {car.Price + "TL"} "
            }).ToList();


            ViewBag.Cities = EnumHelper.GetEnumSelectList<Cities>();
            return View();
        }
    }
}

using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.CarDtos;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.ViewComponents.Default
{
    public class _DefaultCategoriesComponent(ICarService _carService,IMapper _mapper):ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var values = _carService.TGetAll().OrderByDescending(x=>x.CarId).Take(6).ToList();
            var cars = _mapper.Map<List<ResultCarDto>>(values);
            return View(cars);  
        }
    }
}

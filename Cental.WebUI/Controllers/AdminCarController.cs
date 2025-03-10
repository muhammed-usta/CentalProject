using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.BusinessLayer.Concrete;
using Cental.DtoLayer.CarDtos;
using Cental.DtoLayer.Enums;
using Cental.EntityLayer.Entities;
using Cental.WebUI.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Cental.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminCarController(ICarService _carService, IMapper _mapper, IBrandService _brandService, IImageService _imageService) : Controller
    {
        private void GetValuesInDropDown()
        {

            ViewBag.gasTypes = GetEnumValues.GetEnums<GasTypes>();
            ViewBag.gearTypes = GetEnumValues.GetEnums<GearTypes>();
            ViewBag.transmissions = GetEnumValues.GetEnums<Transmissions>();
            ViewBag.brands = (from x in _brandService.TGetAll()
                              select new SelectListItem
                              {
                                  Text = x.BrandName,
                                  Value = x.BrandId.ToString()
                              }).ToList();

        }
        public IActionResult Index()
        {
            var values = _carService.TGetAll();
            return View(values);
        }

        public IActionResult CreateCar()
        {
            GetValuesInDropDown();
            return View(new CreateCarDto());
        }

        [HttpPost]
        public async Task<IActionResult> CreateCar(CreateCarDto model)
        {
            GetValuesInDropDown();
            if (model.ImageFile != null)
            {
                try
                {
                    model.ImageUrl = await _imageService.SaveImageAsync(model.ImageFile);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, "Error while updating the image: " + ex.Message);
                    return View(model);
                }
            }
            var newCar = _mapper.Map<Car>(model);
            _carService.TCreate(newCar);
            return RedirectToAction("Index");
        }

        public IActionResult UpdateCar(int id)
        {
            GetValuesInDropDown();
            var car = _carService.TGetById(id);
            var updatedto = _mapper.Map<UpdateCarDto>(car);
            return View(updatedto);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCar(UpdateCarDto model)
        {
            GetValuesInDropDown();
            if (model.ImageFile != null)
            {
                try
                {
                    model.ImageUrl = await _imageService.SaveImageAsync(model.ImageFile);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, "Error while updating the image: " + ex.Message);
                    return View(model);
                }
            }
            var car = _mapper.Map<Car>(model);
            _carService.TUpdate(car);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteCar(int id)
        {
            _carService.TDelete(id);
            return RedirectToAction("Index");
        }

    }
}

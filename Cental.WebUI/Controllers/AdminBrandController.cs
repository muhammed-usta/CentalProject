using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.BrandDtos;
using Cental.EntityLayer.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PagedList.Core;

namespace Cental.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminBrandController(IBrandService _brandService,IMapper _mapper) : Controller
    {
       
        public IActionResult Index(int page = 1, int pageSize = 3)
        {
            var brandList = _brandService.TGetAll();
            var brands = _mapper.Map<List<ResultBrandDto>>(brandList);
            var query=brands.AsQueryable();
            var values = new PagedList<ResultBrandDto>(query, page, pageSize);
            return View(values);

            
        }

        public IActionResult DeleteBrand(int id)
        {
            _brandService.TDelete(id);
            return RedirectToAction("Index"); 

        }

        public IActionResult CreateBrand()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateBrand(CreateBrandDto model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var brand=_mapper.Map<Brand>(model);
            _brandService.TCreate(brand);
            return RedirectToAction("Index");
        }

        public IActionResult UpdateBrand(int id)
        {
            var brand=_brandService.TGetById(id);
            var updatedto=_mapper.Map<UpdateBrandDto>(brand);
            return View(updatedto);
        }

        [HttpPost]
        public IActionResult UpdateBrand(UpdateBrandDto model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var brand= _mapper.Map<Brand>(model);
            _brandService.TUpdate(brand);
            return RedirectToAction("Index");
        }
    }
}

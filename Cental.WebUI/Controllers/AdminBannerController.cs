using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.BusinessLayer.Concrete;
using Cental.DtoLayer.BannerDtos;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Controllers

{
    [Authorize(Roles = "Admin")]
    public class AdminBannerController(IBannerService _bannerService, IMapper _mapper, IImageService _imageService) : Controller
    {

        public IActionResult Index()
        {
            var values = _bannerService.TGetAll();

            var banners = _mapper.Map<List<ResultBannerDto>>(values);
            return View(banners);
        }

        public IActionResult CreateBanner()
        {
            return View(new CreateBannerDto());
        }

        [HttpPost]
        public async Task<IActionResult> CreateBanner(CreateBannerDto model)
        {
            if (model.ImageFile != null)
            {
                try
                {
                    model.ImageUrl = await _imageService.SaveImageAsync(model.ImageFile);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, "Error while updating the first image: " + ex.Message);
                    return View(model);
                }
            }

            var banner = _mapper.Map<Banner>(model);
            _bannerService.TCreate(banner);
            return RedirectToAction("Index");
        }
        public IActionResult UpdateBanner(int id)
        {
            var banner = _bannerService.TGetById(id);
            var updateDto = _mapper.Map<UpdateBannerDto>(banner);
            return View(updateDto);

        }

        [HttpPost]
        public async Task<IActionResult> UpdateBanner(UpdateBannerDto model)
        {
            if (model.ImageFile != null)
            {
                try
                {
                    model.ImageUrl = await _imageService.SaveImageAsync(model.ImageFile);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, "Error while updating the first image: " + ex.Message);
                    return View(model);
                }
            }
            var banner = _mapper.Map<Banner>(model);
            _bannerService.TUpdate(banner);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteBanner(int id)
        {

            _bannerService.TDelete(id);
            return RedirectToAction("Index");

        }


    }
}

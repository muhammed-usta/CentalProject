using Cental.BusinessLayer.Abstract;
using Cental.BusinessLayer.Concrete;
using Cental.DtoLayer.AboutDtos;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminAboutController(IAboutService _aboutService, IImageService _imageService) : Controller
    {


        public IActionResult Index()
        {

            var values = _aboutService.TGetAll();

            var result = values.Select(about => new ResultAboutDto
            {
                AboutId = about.AboutId,
                Mission = about.Mission,
                Vision = about.Vision,
            }).ToList();

            return View(result);
        }

        [HttpGet]
        public IActionResult CreateAbout()
        {
            return View(new CreateAboutDto());
        }

        [HttpPost]
        public async Task<IActionResult> CreateAbout(CreateAboutDto model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }


            if (model.ImageFile != null)
            {
                try
                {
                    model.ImageUrl1 = await _imageService.SaveImageAsync(model.ImageFile);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, "Error while updating the first image: " + ex.Message);
                    return View(model);
                }
            }


            if (model.ImageFile2 != null)
            {
                try
                {
                    model.ImageUrl2 = await _imageService.SaveImageAsync(model.ImageFile2);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, "Error while updating the second image: " + ex.Message);
                    return View(model);
                }
            }

            if (model.ImageFile3 != null)
            {
                try
                {
                    model.ProfilePicture = await _imageService.SaveImageAsync(model.ImageFile3);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, "Error while updating the profile image image: " + ex.Message);
                    return View(model);
                }
            }

            var about = new About
            {
                Description1 = model.Description1,
                Description2 = model.Description2,
                ImageUrl1 = model.ImageUrl1,
                ImageUrl2 = model.ImageUrl2,
                Item1 = model.Item1,
                Item2 = model.Item2,
                Item3 = model.Item3,
                Item4 = model.Item4,
                JobTitle = model.JobTitle,
                Mission = model.Mission,
                NameSurname = model.NameSurname,
                ProfilePicture = model.ProfilePicture,
                StartYear = model.StartYear,
                Vision = model.Vision
            };

         
            _aboutService.TCreate(about);

            return RedirectToAction("Index");
        }

        public IActionResult DeleteAbout(int id)
        {
            _aboutService.TDelete(id);

            return RedirectToAction("Index");
        }

        public IActionResult UpdateAbout(int id)
        {

            var model = _aboutService.TGetById(id);
            var about = new UpdateAboutDto
            {
                AboutId = model.AboutId,
                Description1 = model.Description1,
                Description2 = model.Description2,
                ImageUrl1 = model.ImageUrl1,
                ImageUrl2 = model.ImageUrl2,
                Item1 = model.Item1,
                Item2 = model.Item2,
                Item3 = model.Item3,
                Item4 = model.Item4,
                JobTitle = model.JobTitle,
                Mission = model.Mission,
                NameSurname = model.NameSurname,
                ProfilePicture = model.ProfilePicture,
                StartYear = model.StartYear,
                Vision = model.Vision
            };

            return View(about);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAbout(UpdateAboutDto model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }


            if (model.ImageFile != null)
            {
                try
                {
                    model.ImageUrl1 = await _imageService.SaveImageAsync(model.ImageFile);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, "Error while updating the first image: " + ex.Message);
                    return View(model);
                }
            }

     
            if (model.ImageFile2 != null)
            {
                try
                {
                    model.ImageUrl2 = await _imageService.SaveImageAsync(model.ImageFile2);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, "Error while updating the second image: " + ex.Message);
                    return View(model);
                }
            }
            if (model.ImageFile3 != null)
            {
                try
                {
                    model.ProfilePicture = await _imageService.SaveImageAsync(model.ImageFile3);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, "Error while updating the profile image image: " + ex.Message);
                    return View(model);
                }
            }

            var about = new About
            {
                AboutId = model.AboutId,
                Description1 = model.Description1,
                Description2 = model.Description2,
                ImageUrl1 = model.ImageUrl1,
                ImageUrl2 = model.ImageUrl2,
                Item1 = model.Item1,
                Item2 = model.Item2,
                Item3 = model.Item3,
                Item4 = model.Item4,
                JobTitle = model.JobTitle,
                Mission = model.Mission,
                NameSurname = model.NameSurname,
                ProfilePicture = model.ProfilePicture,
                StartYear = model.StartYear,
                Vision = model.Vision
            };

            _aboutService.TUpdate(about);
            return RedirectToAction("Index");
        }


    }
}

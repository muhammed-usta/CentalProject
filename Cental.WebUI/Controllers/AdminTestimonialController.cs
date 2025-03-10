using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.BusinessLayer.Concrete;
using Cental.DtoLayer.TestimonialDtos;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminTestimonialController (ITestimonialService _testimonialService,IMapper _mapper, IImageService _imageService) : Controller
    {
      
        public IActionResult Index()
        {
            var values=_testimonialService.TGetAll();
            var testimonials = _mapper.Map<List<ResultTestimonialDto>>(values);
            return View(testimonials);
        }

        public IActionResult CreateTestimonial()
        {
            return View(new CreateTestimonialDto());
        }

        [HttpPost]
        public async Task<IActionResult> CreateTestimonial(CreateTestimonialDto model)
        {


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

            var testimonial = _mapper.Map<Testimonial>(model);
            _testimonialService.TCreate(testimonial);   
            return RedirectToAction("Index");
        }

        public IActionResult UpdateTestimonial(int id)
        {
            var testimonial=_testimonialService.TGetById(id);
            var updatedto=_mapper.Map<UpdateTestimonialDto>(testimonial);
            return View(updatedto);
        }

        [HttpPost]

        public async Task<IActionResult> UpdateTestimonial(UpdateTestimonialDto model)
        {
          
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
            var testimonial = _mapper.Map<Testimonial>(model);
            _testimonialService.TUpdate(testimonial);
            return RedirectToAction("Index"); 
        }

        public IActionResult DeleteTestimonial(int id)
        {
            _testimonialService.TDelete(id);
            return RedirectToAction("Index");
        }
    }
}

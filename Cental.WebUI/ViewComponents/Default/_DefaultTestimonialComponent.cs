using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.TestimonialDtos;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.ViewComponents.Default
{
    public class _DefaultTestimonialComponent(ITestimonialService _testimonialService,IMapper _mapper):ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var values = _testimonialService.TGetAll();
            var testimonials = _mapper.Map<List<ResultTestimonialDto>>(values);
            return View(testimonials);
        }
    }
}

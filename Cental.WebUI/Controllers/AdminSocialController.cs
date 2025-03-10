using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.ContactDtos;
using Cental.DtoLayer.ServiceDtos;
using Cental.DtoLayer.SocialMediaDtos;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminSocialController (ISocialMediaService _socialMediaService, IMapper _mapper): Controller
    {
        public IActionResult Index()
        {
            var values=_socialMediaService.TGetAll();
            var socials=_mapper.Map<List<ResultSocialMediaDto>>(values);
            return View(socials);
        }

        public IActionResult CreateSocial()
        {
            return View();  
        }

        [HttpPost]
        public IActionResult CreateSocial(CreateSocialMediaDto model)
        {
            var social = _mapper.Map<SocialMedia>(model);
            _socialMediaService.TCreate(social);
            return RedirectToAction("Index");   
        }

        public IActionResult UpdateSocial(int id)
        {
            var social=_socialMediaService.TGetById(id);
            var updatedto = _mapper.Map<UpdateSocialMediaDto>(social);
            return View(updatedto);
        }

        [HttpPost]
        public IActionResult UpdateSocial(UpdateSocialMediaDto model)
        {
            var social=_mapper.Map<SocialMedia>(model);
           _socialMediaService.TUpdate(social);
            return RedirectToAction("Index");

        }

        public IActionResult DeleteSocial(int id)
        {
            _socialMediaService.TDelete(id);
            return RedirectToAction("Index");
        }
    }
}

using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.UserSocialDtos;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Areas.Manager.Controllers
{
    [Area("Manager")]
    [Authorize(Roles = "Manager")]
    public class MySocialController(IUserSocialservice _userSocialService, IMapper _mapper, UserManager<AppUser> _userManager) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = _userSocialService.TGetSocialsByUserID(user.Id);
     
            return View(values);
        }

        public IActionResult CreateSocial()
        {

            return View();

        }

        [HttpPost]
        public async Task<IActionResult> CreateSocial(CreateUserSocialDto model)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var newSocial = _mapper.Map<UserSocial>(model);
            newSocial.UserId = user.Id;
            _userSocialService.TCreate(newSocial);
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> UpdateSocial(int id)
        {
          
            var social = _userSocialService.TGetById(id);
            if (social == null)
            {
             
                return NotFound();
            }
       
            var updateDto = _mapper.Map<UpdateUserSocialDto>(social);
            return View(updateDto);
        }

        [HttpPost]

        public async Task<IActionResult> UpdateSocial(UpdateUserSocialDto model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (user == null)
            {
                return NotFound("Kullanıcı bulunamadı!");
            }

            var social = _mapper.Map<UserSocial>(model);
            social.UserId = user.Id; 

            _userSocialService.TUpdate(social);

            return RedirectToAction("Index");

        }


        public IActionResult DeleteSocial(int id)
        {
            _userSocialService.TDelete(id);
            return RedirectToAction("Index");


        }
    }


}

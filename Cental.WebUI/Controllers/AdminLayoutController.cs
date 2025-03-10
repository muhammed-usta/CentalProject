using Cental.DtoLayer.UserDtos;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminLayoutController(UserManager<AppUser> _userManager) : Controller
    {
        public async Task<IActionResult> Layout()
        {
            // Giriş yapan kullanıcıyı al
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            if (user != null)
            {
                // Kullanıcının fotoğrafını ve adını ViewBag'e gönder
                ViewBag.adminImage = user.ImageUrl;  // Kullanıcının fotoğraf URL'si
                ViewBag.adminName = user.FirstName + " " + user.LastName;  // Kullanıcının tam adı
            }

            return View();
        }
    }
}

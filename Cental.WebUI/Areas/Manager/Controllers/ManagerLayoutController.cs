using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Areas.Manager.Controllers
{
    [Area("Manager")]
    public class ManagerLayoutController (UserManager<AppUser> _userManager): Controller
    {
        public async Task< IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.nameSurname = string.Join(" ", user.FirstName, user.LastName);
            ViewBag.managerImage = user.ImageUrl;
            return View(user);
        }
    }
}

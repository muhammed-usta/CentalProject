using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Areas.User.Controllers
{
    [Authorize(Roles = "User")]
    [Area("User")]
    public class UserLayoutController(UserManager<AppUser> _userManager) : Controller
    {
        public async Task<IActionResult> InvokeAsync()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.nameSurname = string.Join(" ", user.FirstName, user.LastName);
            ViewBag.userImage = user.ImageUrl;
            return View(user);
        }
    }
}

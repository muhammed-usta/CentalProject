using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Areas.Manager.ViewComponents
{
    public class _ManagerLayoutNavbarComponent(UserManager<AppUser> _userManager) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.nameSurname = string.Join(" ", user.FirstName, user.LastName);
            ViewBag.managerImage = user.ImageUrl;
            return View(user);
        }
    }
}

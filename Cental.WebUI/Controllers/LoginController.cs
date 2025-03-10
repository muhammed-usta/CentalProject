using Cental.DtoLayer.UserDtos;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Controllers
{
    [AllowAnonymous]
    public class LoginController(SignInManager<AppUser> _signInManager, UserManager<AppUser> _userManager) : Controller
    {
        public async Task<IActionResult> Index()
        {
            await _signInManager.SignOutAsync();
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Index(UserLoginDto model, string? returnUrl)
        {

            var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);
            if (!result.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "The username or password is incorrect");
                return View(model);
            }

            if (returnUrl != null)
            {
                return Redirect(returnUrl);
            }

            var user = await _userManager.FindByNameAsync(model.UserName);
            var userRoles = await _userManager.GetRolesAsync(user);
            foreach (var role in userRoles)
            {
                if (role == "Admin")
                {
                    return RedirectToRoute(new { controller = "AdminDashboard", action = "Index" });
                }
                if (role == "Manager")
                {
                    return RedirectToAction("Index", "Booking", new { area = "Manager" });
                }
                if (role == "User")
                {
                    return RedirectToAction("Index", "Booking", new { area = "User" });
                }
            }

            return RedirectToAction("Index", "Default");
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Default");
        }
    }
}

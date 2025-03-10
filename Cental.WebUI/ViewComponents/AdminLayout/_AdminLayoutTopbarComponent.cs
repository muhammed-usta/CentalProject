using Castle.Components.DictionaryAdapter.Xml;
using Cental.DataAccessLayer.Migrations;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System;
using Microsoft.AspNetCore.Identity;
using Cental.EntityLayer.Entities;

namespace Cental.WebUI.ViewComponents.AdminLayout
{
    public class _AdminLayoutTopbarComponent(UserManager<AppUser> _userManager):ViewComponent
    {

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            if (user != null)
            {
                ViewBag.adminImage = user.ImageUrl;
                ViewBag.adminName = user.FirstName + " " + user.LastName;
            }

            return View();
        }

    }
}




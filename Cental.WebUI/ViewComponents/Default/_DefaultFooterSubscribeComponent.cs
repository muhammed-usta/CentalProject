using Cental.DtoLayer.UserDtos;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.ViewComponents.Default
{
    public class _DefaultFooterSubscribeComponent : ViewComponent
    {
        public IViewComponentResult Invoke(UserRegisterDto model)
        {
            return View(model);
        }
    }
}

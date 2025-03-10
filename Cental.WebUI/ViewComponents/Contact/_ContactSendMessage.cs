using Cental.DtoLayer.MessageDtos;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.ViewComponents.Contact
{
    public class _ContactSendMessage:ViewComponent
    {
        public IViewComponentResult Invoke(CreateMessageDto model)
        {
          return View(model);          
        }
    }
}

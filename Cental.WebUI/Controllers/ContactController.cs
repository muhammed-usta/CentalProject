using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.ContactDtos;
using Cental.DtoLayer.MessageDtos;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Cental.WebUI.Controllers
{
    [AllowAnonymous]
    public class ContactController(IContactService _contactService,IMessageService _messageService ,IMapper _mapper) : Controller
    {
        public IActionResult Index()
        {
            var values = _contactService.TGetAll()
                       .Where(x => x.Adress == "Ankara")
                       .FirstOrDefault();

            return View(values);

        }

        [HttpPost]
        public IActionResult SendMessage(CreateMessageDto model)
        {
            var message=_mapper.Map<Message>(model);
            _messageService.TCreate(message);
            return RedirectToAction("Index");
        }
    }
}

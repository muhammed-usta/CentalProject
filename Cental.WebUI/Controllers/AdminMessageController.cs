using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.MessageDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminMessageController (IMessageService _messageService ,IMapper _mapper): Controller
    {
        public IActionResult Index()
        {
            var values=_messageService.TGetAll();
            var messages=_mapper.Map<List<ResultMessageDto>>(values);
            return View(messages);
        }

        public IActionResult DeleteMessage(int id)
        {
            _messageService.TDelete(id);
            return RedirectToAction("Index");
        }
    }
}

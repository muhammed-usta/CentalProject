using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.ContactDtos;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.ViewComponents.Default
{
    public class _DefaultTopbarComponent(IContactService _contactService, IMapper _mapper, ISocialMediaService _socialMediaService) : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            ViewBag.topbarSocial = _socialMediaService.TGetAll();
            var values = _contactService.TGetAll().FirstOrDefault();
          var contacts=_mapper.Map<ResultContactDto>(values);
            return View(contacts);



        }
    }
}

using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.ContactDtos;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.ViewComponents.Default
{
    public class _DefaultFooterComponent(IContactService _contactService, IMapper _mapper):ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var values = _contactService.TGetAll().FirstOrDefault();
            var contacts=_mapper.Map<ResultContactDto>(values);
            return View(contacts);
           
        }
    }
}

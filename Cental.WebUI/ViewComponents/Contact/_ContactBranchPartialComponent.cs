using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.ContactDtos;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.ViewComponents.Contact
{
    public class _ContactBranchPartialComponent(IContactService _contactService,IMapper _mapper):ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var values = _contactService.TGetAll();
            var branchs=_mapper.Map<List<ResultContactDto>> (values);
            return View(branchs);
        }
    }
}

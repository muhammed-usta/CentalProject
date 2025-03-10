using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.ContactDtos;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AdminContactController (IContactService _contactService, IMapper _mapper): Controller
    {
        public IActionResult Index()
        { 

            var values=_contactService.TGetAll();
            var contacts=_mapper.Map<List<ResultContactDto>>(values);
            return View(contacts);


        }

       public IActionResult CreateContact()
        {

            return View();
        }

        [HttpPost]
        public IActionResult CreateContact(CreateContactDto model)
        {
            var contact = _mapper.Map<Contact>(model);
            _contactService.TCreate(contact);
            return RedirectToAction("Index");
        }

        public ActionResult UpdateContact(int id)
        {
            var contact=_contactService.TGetById(id);
            var udpdatedto=_mapper.Map<UpdateContactDto>(contact);
            return View(udpdatedto);    
        }

        [HttpPost]
        public IActionResult UpdateContact(UpdateContactDto model)
        {
            var contact=_mapper.Map<Contact>(model);    
            _contactService.TUpdate(contact);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteContact(int id)
        {
            _contactService.TDelete(id);
            return RedirectToAction("Index");
        }
    }
}

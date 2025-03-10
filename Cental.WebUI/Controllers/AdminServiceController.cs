using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.ServiceDtos;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminServiceController (IServiceService _serviceService,IMapper _mapper): Controller
    {
        public IActionResult Index()
        {
            var values=_serviceService.TGetAll();
            var services = _mapper.Map<List<ResultServiceDto>>(values);
            return View(services);
        }

        public IActionResult CreateService()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateService(CreateServiceDto model)
        {
            var service=_mapper.Map<Service>(model);
            _serviceService.TCreate(service);
            return RedirectToAction("Index");
        }

        public IActionResult UpdateService(int id)
        {
            var service=_serviceService.TGetById(id);
            var updatedto=_mapper.Map<UpdateServiceDto>(service);
            return View(updatedto);
        }

        [HttpPost]
        public IActionResult UpdateService(UpdateServiceDto model)
        {
            var service= _mapper.Map<Service>(model);
            _serviceService.TUpdate(service);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteService(int id)
        {
            
            _serviceService.TDelete(id);
            return RedirectToAction("Index");

        }
    }
}

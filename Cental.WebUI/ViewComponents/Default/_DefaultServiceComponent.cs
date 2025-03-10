using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.ServiceDtos;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.ViewComponents.Default
{
    public class _DefaultServiceComponent(IServiceService _serviceService,IMapper _mapper):ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var values = _serviceService.TGetAll();
            var services = _mapper.Map<List<ResultServiceDto>>(values);
            return View(services);  
        }
    }
}

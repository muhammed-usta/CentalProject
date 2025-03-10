using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.ProcessDtos;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.ViewComponents.Default
{
    public class _DefaultProcessComponent(IProcessService _processService,IMapper _mapper) : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var values = _processService.TGetAll();
            var processes = _mapper.Map<List<ResultProcessDto>>(values);
            return View(processes);
        }
    }
}

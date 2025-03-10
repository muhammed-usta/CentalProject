using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.FeatureDtos;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.ViewComponents.Default
{
    public class _DefaultFeatureComponent(IFeatureService _featureService,IMapper _mapper) : ViewComponent
    {
      public  IViewComponentResult Invoke()
        {
            var values = _featureService.TGetAll();
            var features=_mapper.Map<List<ResultFeatureDto>>(values);
           return View(features);   
        }

    }
}

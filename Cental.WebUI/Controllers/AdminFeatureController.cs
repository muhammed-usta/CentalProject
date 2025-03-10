using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.FeatureDtos;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminFeatureController(IFeatureService _featureService, IMapper _mapper) : Controller
    {
        public IActionResult Index()
        {
            var values = _featureService.TGetAll();

            // Verileri console'a yazdır (bunu sonra silebilirsin)
            Console.WriteLine($"Feature count: {values?.Count()}");

            if (values == null || !values.Any())
            {
                return View(new List<ResultFeatureDto>());
            }

            var featureList = _mapper.Map<List<ResultFeatureDto>>(values);
            return View(featureList);
        }

        public IActionResult CreateFeature()
        {

            return View();
        }

        [HttpPost]
        public IActionResult CreateFeature(CreateFeatureDto model)
        {
            var feature = _mapper.Map<Feature>(model);
            _featureService.TCreate(feature);
            return RedirectToAction("Index");
        }

        public IActionResult UpdateFeature(int id)
        {
            var feature = _featureService.TGetById(id);
            var updatedto=_mapper.Map<UpdateFeatureDto>(feature);
            return View(updatedto);
        }

        [HttpPost]
        public IActionResult UpdateFeature(UpdateFeatureDto model)
        {
            var feature=_mapper.Map<Feature>(model);
            _featureService.TUpdate(feature);
            return RedirectToAction("Index");
        }
    }
}

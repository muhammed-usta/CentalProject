using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.ReviewDtos;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Cental.WebUI.Areas.User.Controllers
{
    [Authorize(Roles = "User")]
    [Area("User")]
    public class ReviewController (IReviewService _reviewService,ICarService _carService,UserManager<AppUser> _userManager,IMapper _mapper,IBookingService _bookingService): Controller
    {
        public async Task<IActionResult> Index()
        {
  
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (user == null)
                return RedirectToAction("Index", "Home"); 

          
            var reviews = _reviewService.TGetReviewsByUserId(user.Id);
            return View(reviews);
        }

      
        private void SelectCarList(string userId)
        {
            
            int userIdInt = Convert.ToInt32(userId);

        
            var approvedBookings = _bookingService.TGetAll()
                .Where(b => b.UserId == userIdInt && b.IsApproved == true)
                .ToList();

            var approvedCarIds = approvedBookings
                .Select(b => b.CarId)
                .Distinct();

          
            var cars = _carService.TGetAll()
                .Where(car => approvedCarIds.Contains(car.CarId))
                .ToList();

          
            var carList = cars.Select(car => new SelectListItem
            {
                Text = $"{car.Brand.BrandName} {car.ModelName} {car.Year}",
                Value = car.CarId.ToString()
            }).ToList();

            ViewBag.CarList = carList;
        }

        public async Task<IActionResult> CreateReview()
        {
           
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (user == null)
                return RedirectToAction("Index", "Home");

           
            SelectCarList(user.Id.ToString());

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateReview(CreateReviewDto model)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var review = _mapper.Map<Review>(model);
            review.UserId = Convert.ToInt32(user.Id);  // Eğer user.Id int ise direkt atayabilirsiniz: review.UserId = user.Id;

            _reviewService.TCreate(review);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateReview(int id)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (user == null)
                return RedirectToAction("Index", "Home");

            SelectCarList(user.Id.ToString());

            var review = _reviewService.TGetById(id);
            var dtoReview = _mapper.Map<UpdateReviewDto>(review);
            return View(dtoReview);
        }

        [HttpPost]
        public IActionResult UpdateReview(UpdateReviewDto model)
        {
            var value = _mapper.Map<Review>(model);
            _reviewService.TUpdate(value);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteReview(int id)
        {
            _reviewService.TDelete(id);
            return RedirectToAction("Index");
        }
    }
}

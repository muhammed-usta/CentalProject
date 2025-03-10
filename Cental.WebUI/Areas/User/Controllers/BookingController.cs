using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.BookingDtos;
using Cental.DtoLayer.Enums;
using Cental.EntityLayer.Entities;
using Cental.WebUI.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Cental.WebUI.Areas.User.Controllers
{

    [Area("User")]
    [Authorize(Roles = "User")]

    public class BookingController(UserManager<AppUser> _userManager, IBookingService _bookingService, ICarService _carService, IMapper _mapper) : Controller
    {
        public async Task<IActionResult> Index()
        {
            ViewBag.Cities = EnumHelper.GetEnumSelectList<Cities>();

            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var bookings = _bookingService.TUsersBookings(user.Id);
            var bookingDtos = _mapper.Map<List<ResultBookingDto>>(bookings);
            return View(bookingDtos);
        }

        private List<SelectListItem> GetCarSelectedList()
        {
            var selectedCarList = (from car in _carService.TGetAll()
                                   select new SelectListItem
                                   {
                                       Value = car.CarId.ToString(),
                                       Text = $"{car.Brand.BrandName} {car.ModelName} {car.Year} {car.Transmission}  "
                                   }).ToList();
            return selectedCarList;
        }
        public async Task<IActionResult> CreateReservationAsync()
        {
            ViewBag.Cities = EnumHelper.GetEnumSelectList<Cities>();
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.user = user.Id;
            ViewBag.SelectedCarList = GetCarSelectedList();
            return View();
        }
        [HttpPost]
        public IActionResult CreateReservation(CreateBookingDto model)
        {

            var booking = _mapper.Map<Booking>(model);
            booking.Status = "On hold";
            booking.IsApproved = null;
            _bookingService.TCreate(booking);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateReservationAsync(int id)
        {
            ViewBag.Cities = EnumHelper.GetEnumSelectList<Cities>();

            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.user = user.Id;
            var booking = _bookingService.TGetById(id);
            if (booking.IsApproved == true)
            {
                booking.Status = "Approved";
            }
            else if (booking.IsApproved == false)
            {
                booking.Status = "Declined";
            }
            else
            {
                booking.Status = "On hold";
            }
            var bookingDto = _mapper.Map<UpdateBookingDto>(booking);
            ViewBag.SelectedCarList = GetCarSelectedList();
            return View(bookingDto);
        }
        [HttpPost]
        public IActionResult UpdateReservation(UpdateBookingDto model)
        {
           model.Status = "On hold";
            var booking = _mapper.Map<Booking>(model);
            _bookingService.TUpdate(booking);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteReservation(int id)
        {
            _bookingService.TDelete(id);
            return RedirectToAction("Index");
        }
    }
}

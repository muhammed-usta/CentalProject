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

namespace Cental.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]

    public class AdminBookingController(IBookingService _bookingService, ICarService _carService, IMapper _mapper, UserManager<AppUser> _userManager) : Controller
    {
        public IActionResult Index()
        {
            var bookings = _bookingService.TGetAll();
            var bookingDtos = _mapper.Map<List<ResultBookingDto>>(bookings);
            return View(bookingDtos);
        }
        private List<SelectListItem> GetUserSelectedList()
        {
            var selectedUserList = (from user in _userManager.Users
                                    select new SelectListItem
                                    {
                                        Text = user.FirstName + " " + user.LastName,
                                        Value = user.Id.ToString()
                                    }).ToList();
            return selectedUserList;
        }

        private List<SelectListItem> GetCarSelectedList()
        {
            var selectedCarList = (from car in _carService.TGetAll()
                                   select new SelectListItem
                                   {
                                       Text = car.Year + " " + car.ModelName + " " + car.Brand.BrandName,
                                       Value = car.CarId.ToString()
                                   }).ToList();
            return selectedCarList;
        }
        public IActionResult CreateBooking()
        {
            ViewBag.Cities = EnumHelper.GetEnumSelectList<Cities>();
            ViewBag.SelectedCarList = GetCarSelectedList();
            ViewBag.UserSelectedList = GetUserSelectedList();
            return View();
        }
        [HttpPost]
        public IActionResult CreateBooking(CreateBookingDto model)
        {
            var booking = _mapper.Map<Booking>(model);
            booking.Status = "On hold";
            booking.IsApproved = null;
            _bookingService.TCreate(booking);
            return RedirectToAction("Index");
        }


        public IActionResult UpdateBooking(int id)
        {
            ViewBag.Cities = EnumHelper.GetEnumSelectList<Cities>();
            var booking = _bookingService.TGetById(id);
            var bookingDto = _mapper.Map<UpdateBookingDto>(booking);
            ViewBag.SelectedCarList = GetCarSelectedList();
            ViewBag.UserSelectedList = GetUserSelectedList();
            return View(bookingDto);
        }
        [HttpPost]
        public IActionResult UpdateBooking(UpdateBookingDto model)
        {
            var booking = _mapper.Map<Booking>(model);
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
            _bookingService.TUpdate(booking);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteBooking(int id)
        {
            _bookingService.TDelete(id);
            return RedirectToAction("Index");
        }

        public IActionResult ApproveBooking(int id)
        {
            var booking = _bookingService.TGetById(id);
            booking.IsApproved = true;
            booking.Status = "Approved";
            _bookingService.TUpdate(booking);
            return RedirectToAction("Index");
        }

        public IActionResult DeclineBooking(int id)
        {
            var booking = _bookingService.TGetById(id);
            booking.IsApproved = false;
            booking.Status = "Declined";
            _bookingService.TUpdate(booking);
            return RedirectToAction("Index");
        }

        public IActionResult WaitingBooking(int id)
        {
            var booking = _bookingService.TGetById(id);
            booking.IsApproved = null;
            booking.Status = "On hold";
            _bookingService.TUpdate(booking);
            return RedirectToAction("Index");
        }
    }
}

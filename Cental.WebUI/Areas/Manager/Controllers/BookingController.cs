using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.BookingDtos;
using Cental.DtoLayer.Enums;
using Cental.EntityLayer.Entities;
using Cental.WebUI.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Cental.WebUI.Areas.Manager.Controllers
{
    [Area("Manager")]
    [Authorize(Roles = "Manager")]
    public class BookingController(IBookingService _bookingService, ICarService _carService, IMapper _mapper) : Controller
    {
        public IActionResult Index()
        {

            var bookings = _bookingService.TGetAll();
            var bookingDtos = _mapper.Map<List<ResultBookingDto>>(bookings);
            return View(bookingDtos);
        }
        private List<SelectListItem> GetCarSelectedList()
        {
            var selectedCarList = (from car in _carService.TGetAll()
                                   select new SelectListItem
                                   {

                                       Value = car.CarId.ToString(),
                                       Text = $"{car.Brand.BrandName} {car.ModelName} {car.Year} {car.Transmission}"
                                   }).ToList();
            return selectedCarList;
        }
        public IActionResult CreateReservation()
        {
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


        public IActionResult UpdateReservation(int id)
        {
            var booking = _bookingService.TGetById(id);
            var bookingDto = _mapper.Map<UpdateBookingDto>(booking);
            ViewBag.SelectedCarList = GetCarSelectedList();
            return View(bookingDto);
        }
        [HttpPost]
        public IActionResult UpdateReservation(UpdateBookingDto model)
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

        public IActionResult DeleteReservation(int id)
        {
            _bookingService.TDelete(id);
            return RedirectToAction("Index");
        }

        public IActionResult ApproveReservation(int id)
        {
            var booking = _bookingService.TGetById(id);
            booking.IsApproved = true;
            booking.Status = "Approved";
            _bookingService.TUpdate(booking);
            return RedirectToAction("Index");
        }

        public IActionResult DeclineReservation(int id)
        {
            var booking = _bookingService.TGetById(id);
            booking.IsApproved = false;
            booking.Status = "Declined";
            _bookingService.TUpdate(booking);
            return RedirectToAction("Index");
        }

        public IActionResult WaitingReservation(int id)
        {
            var booking = _bookingService.TGetById(id);
            booking.IsApproved = null;
            booking.Status = "On hold";
            _bookingService.TUpdate(booking);
            return RedirectToAction("Index");
        }
    }
}


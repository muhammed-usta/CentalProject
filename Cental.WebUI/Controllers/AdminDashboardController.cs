using Cental.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Controllers
{

    [Authorize(Roles = "Admin")]
    public class AdminDashboardController (IDashboardService _dashboardService): Controller
    {
        public IActionResult Index()
        {
            ViewBag.BrandCount = _dashboardService.TGetBrandCount();

            ViewBag.TotalUserCount = _dashboardService.TTotalUserCount();
            ViewBag.TotalReviewCount = _dashboardService.TGetReviewCount();
            ViewBag.TotalCarCount = _dashboardService.TTotalCarCount();
            ViewBag.TestimonialCount = _dashboardService.TGetTestimonialCount();


            var value = _dashboardService.TGetTestimonialAvarage();
            ViewBag.TestimonialAvarage = Math.Round(value, 2);

            ViewBag.TotalBookingCount = _dashboardService.TGetBookingCount();
            ViewBag.TotalMessageCount = _dashboardService.TGetMessageCount();
            ViewBag.BookingList = _dashboardService.TGetBookings();
            ViewBag.TestimonialList = _dashboardService.TGetTestimonials();
            ViewBag.MessageList = _dashboardService.TGetMessages();

            ViewBag.ApprovedBookingCount = _dashboardService.TApprovedBookingCount();
            ViewBag.WaitingBookingCount = _dashboardService.TWaitingBookingCount();
            ViewBag.DeclineBookingCount = _dashboardService.TDeclineBookingCount();

            ViewBag.LastAddedCars = _dashboardService.TGetLastAddedCars();

            return View();
        }
    }
}

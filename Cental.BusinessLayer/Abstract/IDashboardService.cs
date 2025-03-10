using Cental.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.BusinessLayer.Abstract
{
    public interface IDashboardService
    {
        int TGetBrandCount();
        int TTotalUserCount();
        int TTotalCarCount();
        int TGetReviewCount();
        double TGetTestimonialAvarage();
        int TGetTestimonialCount();
        List<Car> TGetLastAddedCars();
        List<Booking> TGetBookings();
        List<Message> TGetMessages();
        List<Testimonial> TGetTestimonials();

        int TGetBookingCount();
        int TGetMessageCount();
        int TApprovedBookingCount();
        int TWaitingBookingCount();
        int TDeclineBookingCount();
    }
}

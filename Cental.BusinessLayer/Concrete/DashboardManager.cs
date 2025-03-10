using Cental.BusinessLayer.Abstract;
using Cental.DataAccessLayer.Abstract;
using Cental.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.BusinessLayer.Concrete
{
    public class DashboardManager(IDashboardDal _dashboardDal):IDashboardService
    {
        public int TGetBookingCount()
        {
            return _dashboardDal.GetBookingCount();
        }

        public int TGetMessageCount()
        {
            return _dashboardDal.GetMessageCount();
        }

        public List<Booking> TGetBookings()
        {
            return _dashboardDal.GetBookings();
        }

        public int TGetBrandCount()
        {
            return _dashboardDal.GetBrandCount();
        }

        public List<Car> TGetLastAddedCars()
        {
            return _dashboardDal.GetLastAddedCars();
        }

        public List<Message> TGetMessages()
        {
            return _dashboardDal.GetMessages();
        }

        public int TGetReviewCount()
        {
            return _dashboardDal.GetReviewCount();
        }

        public List<Testimonial> TGetTestimonials()
        {
            return _dashboardDal.GetTestimonials();
        }

        public double TGetTestimonialAvarage()
        {
            return _dashboardDal.GetTestimonialAvarage();
        }

        public int TGetTestimonialCount()
        {
            return _dashboardDal.GetTestimonialCount();
        }

        public int TTotalCarCount()
        {
            return _dashboardDal.TotalCarCount();
        }

        public int TTotalUserCount()
        {
            return _dashboardDal.TotalUserCount();
        }

        public int TApprovedBookingCount()
        {
            return _dashboardDal.ApprovedBookingCount();
        }

        public int TWaitingBookingCount()
        {
            return _dashboardDal.WaitingBookingCount();
        }

        public int TDeclineBookingCount()
        {
            return _dashboardDal.DeclineBookingCount();
        }
    }
}

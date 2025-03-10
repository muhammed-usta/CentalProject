using Cental.DataAccessLayer.Abstract;
using Cental.DataAccessLayer.Context;
using Cental.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.DataAccessLayer.Concrete
{
    public class EfDashboardDal : IDashboardDal
    {
        private readonly CentalContext _context;

        public EfDashboardDal(CentalContext context)
        {
            _context = context;
        }

        public int GetBookingCount()
        {
            return _context.Bookings.Count(); ;
        }

        public List<Booking> GetBookings()
        {
            var bookings = _context.Bookings.OrderByDescending(x => x.BookingId).Where(x => x.IsApproved == null).Take(5).ToList();
            return bookings;
        }

        public int GetBrandCount()
        {
            return _context.Brands.Count();
        }

        public List<Car> GetLastAddedCars()
        {
            var cars = _context.Cars.OrderByDescending(x => x.CarId).Take(6).ToList();
            return cars;
        }

        public int GetMessageCount()
        {
            return _context.Messages.Count(); ;
        }

        public List<Message> GetMessages()
        {
            return _context.Messages.ToList();
        }

        public int GetReviewCount()
        {
            return _context.Reviews.Count();
        }

        public List<Testimonial> GetTestimonials()
        {
            return _context.Testimonials.OrderByDescending(x => x.TestimonialId).Take(3).ToList();
        }

        public double GetTestimonialAvarage()
        {
            var avarage = _context.Testimonials.Average(x => x.Review);
            return avarage;
        }

        public int GetTestimonialCount()
        {
            return _context.Testimonials.Count();
        }

        public int TotalCarCount()
        {
            return _context.Cars.Count();
        }

        public int TotalUserCount()
        {
            return _context.Users.Count();
        }

        public int ApprovedBookingCount()
        {
            return _context.Bookings.Where(x => x.IsApproved == true).Count();
        }

        public int WaitingBookingCount()
        {
            return _context.Bookings.Where(x => x.IsApproved == true).Count();
        }

        public int DeclineBookingCount()
        {
            return _context.Bookings.Where(x => x.IsApproved == false).Count();
        }
    }
}

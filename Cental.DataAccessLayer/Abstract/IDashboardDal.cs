using Cental.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.DataAccessLayer.Abstract
{
    public interface IDashboardDal
    {
        int TotalUserCount(); 
        int TotalCarCount(); 
        int GetBrandCount(); 
        int GetReviewCount();
        int GetTestimonialCount(); 
        double GetTestimonialAvarage(); 
        List<Car> GetLastAddedCars();  
        List<Booking> GetBookings(); 
        int GetBookingCount(); 
        int ApprovedBookingCount(); 
        int WaitingBookingCount(); 
        int DeclineBookingCount();

        List<Message> GetMessages();
        int GetMessageCount(); 
        List<Testimonial> GetTestimonials();
    }
}

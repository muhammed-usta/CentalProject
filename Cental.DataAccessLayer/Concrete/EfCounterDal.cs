using Cental.DataAccessLayer.Abstract;
using Cental.DataAccessLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.DataAccessLayer.Concrete
{
    public class EfCounterDal : ICounterDal
    {
        private readonly CentalContext _context;

        public EfCounterDal(CentalContext context)
        {
            _context = context;
        }

        public int GetBookingCount()
        {
            return _context.Bookings.Count();
        }

        public int GetCarCount()
        {
            return _context.Cars.Count();
        }

        public int GetReviewCount()
        {
            return _context.Reviews.Count();
        }

        public int GetUserCount()
        {
            return _context.Users.Count();
        }
    }
}

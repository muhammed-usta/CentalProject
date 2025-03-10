using Cental.BusinessLayer.Abstract;
using Cental.DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.BusinessLayer.Concrete
{
    public class CounterManager(ICounterDal _counterDal) : ICounterService
    {
        public int TGetCarCount()
        {
            return _counterDal.GetCarCount();
        }

        public int TGetReviewCount()
        {
            return _counterDal.GetReviewCount();
        }

        public int TGetBookingCount()
        {
            return _counterDal.GetBookingCount();
        }

        public int TGetUserCount()
        {
            return _counterDal.GetUserCount();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.DataAccessLayer.Abstract
{
    public interface ICounterDal
    {
        int GetUserCount();
        int GetCarCount();
        int GetBookingCount();
        int GetReviewCount();
    }
}

using Reti.NewCondeco.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reti.NewCondeco.Repositories
{
    public class BookingRepository : EFRepository<Booking>, IBookingRepository
    {
        public int Add(string description, int resourceId, DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public void Delete(int bookingId)
        {
            throw new NotImplementedException();
        }

        public Booking Get(int bookingId)
        {
            throw new NotImplementedException();
        }
    }
}

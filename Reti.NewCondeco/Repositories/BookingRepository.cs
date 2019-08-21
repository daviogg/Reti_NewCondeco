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
        public int Add(Booking item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            ((NewCondecoEntities)Context).Bookings.Add(item);
            return item.BookingId;
        }

        public void Delete(Booking item)
        {
            ((NewCondecoEntities)Context).Bookings.Remove(item);
        }

        public Booking Get(int bookingId)
        {
            return ((NewCondecoEntities)Context).Bookings.SingleOrDefault(i => i.BookingId == bookingId);
        }
    }
}

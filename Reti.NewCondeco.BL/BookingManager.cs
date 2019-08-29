using Reti.NewCondeco.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reti.NewCondeco.BL
{
    public class BookingManager
    {
        public Booking GetBookingById(int id)
        {
            Booking result;
            try
            {
                BookingRepository bookingRepo = new BookingRepository();
                result = bookingRepo.Get(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }


        public void CreateBooking(Booking Booking)
        {
            BookingRepository bookingRepo = new BookingRepository();
            try
            {
                bookingRepo.Add(Booking);
                GlobalUnitOfWork.Commit();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Booking> ReturnAllBookings()
        {
            IEnumerable<Booking> bookings;
            try
            {
                BookingRepository bookingRepo = new BookingRepository();

                bookings = bookingRepo.GetAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return bookings;
        }

        public void DeleteBooking(int BookingID)
        {
            try
            {
                BookingRepository bookingRepo = new BookingRepository();
                var b = bookingRepo.Get(BookingID);
                bookingRepo.Delete(b);
                GlobalUnitOfWork.Commit();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

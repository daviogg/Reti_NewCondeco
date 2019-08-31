using Reti.NewCondeco.Entities.Utils;
using Reti.NewCondeco.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
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

        public void CheckAvaibleRooms(DateTime startDate, DateTime endDate)
        {
            try
            {
                BookingRepository bookingRepo = new BookingRepository();
                ResourcesManager resourceManager = new ResourcesManager();
                RoomRepository roomRepo = new RoomRepository();
                RoomsManager roomMng = new RoomsManager();

                List<Booking> bl = new List<Booking>();
                HashSet<int> roomIds = new HashSet<int>();

                bl = bookingRepo.GetAll().ToList();
               

                bl.ForEach(b =>
                {
                    if (Utils.IsCurrentBooking(startDate, endDate, b.DateStart, b.DateEnd))
                    {
                        roomMng.UpdateAvaible(b.BRoomId, -1);
                        roomIds.Add(b.BRoomId);
                    }
                    else
                        roomMng.UpdateAvaible(b.BRoomId, 0);
                });

                foreach (var id in roomIds)
                {
                    roomMng.UpdateResetAvaibleSeats(id);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CheckAvaibleResources(DateTime startDate, DateTime endDate)
        {
            try
            {
                BookingRepository bookingRepo = new BookingRepository();
                ResourcesManager resourceMng = new ResourcesManager();
                List<Booking> bl = new List<Booking>();
                bl = bookingRepo.GetAll().ToList();
                //(startDate <= b.DateEnd && startDate >= b.DateStart || b.DateStart <= endDate && b.DateStart >= startDate)
                bl.ForEach(b =>
                {
                    if (Utils.IsCurrentBooking(startDate, endDate, b.DateStart, b.DateEnd))
                    {
                        resourceMng.UpdateAvaibleResource(b.BResourceId, false);
                    }
                    else
                    {
                        resourceMng.UpdateAvaibleResource(b.BResourceId, true);
                    }
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
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

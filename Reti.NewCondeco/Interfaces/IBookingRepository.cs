using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reti.NewCondeco.Interfaces
{
    public interface IBookingRepository
    {
        Booking Get(int bookingId);
        IEnumerable<Booking> GetAll();                               
        int Add(Booking item);                  
        void Delete(Booking item);
    }
}

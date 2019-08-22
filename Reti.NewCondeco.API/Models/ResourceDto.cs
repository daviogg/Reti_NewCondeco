using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Reti.NewCondeco.API.Models
{
    public class ResourceDto
    {
        public int ResourceID { get; set; }
        public string UserName { get; set; }
        public string SurName { get; set; }
        public string Name { get; set; }
        public string Mail { get; set; }
        public bool IsAvaible { get; set; }

        public IEnumerable<BookingDto> Bookings { get; set; }
    }
}
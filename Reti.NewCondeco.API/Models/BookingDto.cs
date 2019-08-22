using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Reti.NewCondeco.API.Models
{
    public class BookingDto
    {
        public int BookingId { get; set; }
        public string Description { get; set; }
        public int BResourceId { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }

    }
}
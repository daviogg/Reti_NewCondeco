using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Reti.NewCondeco.API.Models
{
    public class RoomDto
    {
        public int RoomId { get; set; }
        public string Name { get; set; }
        public int AvaiableSeats { get; set; }
        public int RoomBuildingId { get; set; }
        public bool IsAvaible { get; set; }
    }
}
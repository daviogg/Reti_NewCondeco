using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Reti.NewCondeco.API.Models
{
    public class BuildingDto
    {
        public int BuildingId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public bool IsAvaible { get; set; }
        public IEnumerable<RoomDto> Rooms { get; set; }
    }
}
namespace Reti.NewCondeco.Commons
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Room
    {
        public int RoomId { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        public int AvaiableSeats { get; set; }

        public int RoomBuildingId { get; set; }

        public bool IsAvaible { get; set; }

        public virtual Building Building { get; set; }
    }
}

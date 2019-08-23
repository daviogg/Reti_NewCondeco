namespace Reti.NewCondeco.Commons
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class NewCondecoModel : DbContext
    {
        public NewCondecoModel()
            : base("name=NewCondeco")
        {
        }

        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<Building> Buildings { get; set; }
        public virtual DbSet<Resource> Resources { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Building>()
                .HasMany(e => e.Rooms)
                .WithRequired(e => e.Building)
                .HasForeignKey(e => e.RoomBuildingId);

            modelBuilder.Entity<Resource>()
                .HasMany(e => e.Bookings)
                .WithRequired(e => e.Resource)
                .HasForeignKey(e => e.BResourceId)
                .WillCascadeOnDelete(false);
        }
    }
}

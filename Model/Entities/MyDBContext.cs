namespace Model.Entities
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MyDBContext : DbContext
    {
        public MyDBContext()
            : base("name=MyDBContext")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<RoomType> RoomTypes { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Room>()
                .Property(e => e.Number)
                .IsUnicode(false);

            modelBuilder.Entity<RoomType>()
                .HasMany(e => e.Bookings)
                .WithRequired(e => e.RoomType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RoomType>()
                .HasMany(e => e.Rooms)
                .WithRequired(e => e.RoomType)
                .HasForeignKey(e => e.Type)
                .WillCascadeOnDelete(false);
        }
    }
}

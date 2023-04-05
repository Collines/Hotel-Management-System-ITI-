using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using HotelManagementSystem.Entities;

namespace HotelManagementSystem.Context
{
    class FrontendDB:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
         =>   optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["FrontendConnection"].ConnectionString);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Room>().HasQueryFilter(R => R.IsReserved == false);
            modelBuilder.Entity<Room>().HasIndex(R=>R.RoomNumber).IsUnique();
            modelBuilder.Entity<Room>().Property(R => R.IsReserved).HasDefaultValue(false);
        }
        public virtual DbSet<Reservation> Reservations { get; set; }
        public virtual DbSet<Guest> Guests { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        
    }
}

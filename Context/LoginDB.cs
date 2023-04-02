using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace HotelManagementSystem.Context
{
    class LoginDB:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer("Server=DESKTOP-VREBPAN\\MSSQLSERVER17;Database=LOGIN;"+
                "Trusted_Connection=True;Encrypt=False");

        public virtual DbSet<Frontend> FrontendUsers { get; set; }
        public virtual DbSet<Kitchen> KitchenUsers { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Frontend>().HasKey(F => F.ID);
        //    modelBuilder.Entity<Frontend>()
        //        .Property(F => F.Username)
        //        .IsRequired()
        //        .HasMaxLength(30);
        //    modelBuilder.Entity<Kitchen>().HasKey(K => K.ID);
        //    modelBuilder.Entity<Kitchen>()
        //        .Property(K => K.Username)
        //        .IsRequired()
        //        .HasMaxLength(30);
        //}
    }
}

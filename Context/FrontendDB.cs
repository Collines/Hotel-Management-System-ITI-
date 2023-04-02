using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace HotelManagementSystem.Context
{
    class FrontendDB:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer("Server=DESKTOP-VREBPAN\\MSSQLSERVER17;Database=FRONTEND;"+
                "Trusted_Connection=True;Encrypt=False");

        public virtual DbSet<Reservation> Reservations { get; set; }

        
    }
}

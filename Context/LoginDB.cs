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
            => optionsBuilder.UseSqlServer("Server=DESKTOP-VREBPAN\\MSSQLSERVER17;Database=LOGIN_MANAGER;"+
                "Trusted_Connection=True;Encrypt=False");

        public virtual DbSet<Frontend> FrontendUsers { get; set; }
        public virtual DbSet<Kitchen> KitchenUsers { get; set; }
    }
}

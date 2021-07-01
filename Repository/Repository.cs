using Microsoft.EntityFrameworkCore;
using System;

namespace Repository
{
    public class Context : DbContext
    {
        public DbSet<Model.Guest> Guests { get; set; }
        public DbSet<Model.Clean> Cleans { get; set; }
        public DbSet<Model.Employee> Employees { get; set; }
        public DbSet<Model.Expense> Expenses { get; set; }
        public DbSet<Model.Product> Products { get; set; }
        public DbSet<Model.Reservation> Reservations { get; set; }
        public DbSet<Model.Room> Rooms { get; set; }
        public DbSet<Model.ReservationRoom> ReservationRooms { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
          

            optionsBuilder.UseMySql(
                "server=localhost;user=root;password=;database=hotelaria;",
                new MySqlServerVersion("8.0.22")
            );
            
        }


    }
}



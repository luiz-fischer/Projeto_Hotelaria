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
        public DbSet<Model.CleanRoom> CleanRooms { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            // string connUser = "bf07458e8e5095";
            // string connPass = "236c2802";
            // string connHost = "us-cdbr-east-04.cleardb.com";
            // string connDb = "heroku_1fb931cf91c4b37";

            // string connStr = $"server={connHost};Uid={connUser};Pwd={connPass};Database={connDb};SSL Mode=None";

            optionsBuilder.UseMySql(
                "server=localhost;user=root;password=;database=hotelaria;",
                new MySqlServerVersion("8.0.22")
            );

            // optionsBuilder.UseMySql(
            // connStr, new MySqlServerVersion("8.0.22"),
            // mySqlOptionsAction: mysqlOptions =>
            // {
            //     mysqlOptions.EnableRetryOnFailure(
            //         maxRetryCount: 1,
            //         maxRetryDelay: TimeSpan.FromSeconds(30),
            //         errorNumbersToAdd: null
            //     );
            // });
        }
    }
}




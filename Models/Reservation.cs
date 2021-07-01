using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Repository;



namespace Model {
    public  class Reservation {
       
       [Key]
        public int ReservationId { get; set; } 
        public virtual Guest Guest { get; set; }
        [ForeignKey("guests")] 
        public int GuestId { get; set; }
        public virtual Room Room { get; set; }
        [ForeignKey("rooms")] 
        [Required]
        public int RoomId { get; set; }

        public DateTime ReservationDate { get; set; }
        public int DaysOfStay { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public double Total { get; set; }
        public List<Room> rooms = new();

        public Reservation() {

        }
        public Reservation(
            Model.Guest guest,
            // Model.Room room,
            DateTime reservationDate,
            int daysOfStay,
            DateTime checkIn,
            DateTime checkOut,
            double total)
        {
            GuestId = guest.GuestId;
            // RoomId = room.RoomId;
            ReservationDate = reservationDate;
            DaysOfStay = daysOfStay;
            CheckIn = checkIn;
            CheckOut = checkOut;
            Total = total;
            rooms = new List<Room>();
            guest.AddReservation(this);

            var db = new Context();
            db.Reservations.Add(this);
            db.SaveChanges();
        }



    }
}
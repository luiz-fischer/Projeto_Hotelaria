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
        [Required]
        public int RoomId { get; set; }

        public DateTime ReservationDate { get; set; }
        public int DaysOfStay { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public double Total { get; set; }

        public Reservation() {

        }
        public Reservation(
            int guestId,
            int roomId,
            DateTime reservationDate,
            int daysOfStay,
            DateTime checkIn,
            DateTime checkOut,
            double total)
        {
            GuestId = guestId;
            RoomId = roomId;
            ReservationDate = reservationDate;
            DaysOfStay = daysOfStay;
            CheckIn = checkIn;
            CheckOut = checkOut;
            Total = total;

            var db = new Context();
            db.Reservations.Add(this);
            db.SaveChanges();
        }



    }
}
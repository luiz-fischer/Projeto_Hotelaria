using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Model {
    public partial class Reservation {
       
        [Key]
        private int ReservationId { get; set; } 
        public virtual Guest Guest { get; set; }
        [ForeignKey("guests")] 
        private int GuestId { get; set; }
        [Required]
        private int RoomId { get; set; }

        private DateTime ReservationDate { get; set; }
        private int DaysOfStay { get; set; }
        private DateTime CheckIn { get; set; }
        private DateTime CheckOut { get; set; }
        private double Total { get; set; }

        public Reservation() {

        }
        public Reservation(
            int reservationId,
            int guestId,
            int roomId,
            DateTime reservationDate,
            int daysOfStay,
            DateTime checkIn,
            DateTime checkOut,
            double total)
        {
            ReservationId = reservationId;
            GuestId = guestId;
            RoomId = roomId;
            ReservationDate = reservationDate;
            DaysOfStay = daysOfStay;
            CheckIn = checkIn;
            CheckOut = checkOut;
            Total = total;

            // Context db = new(); // BD
            // db.SaveChanges();   // BD
        }



    }
}
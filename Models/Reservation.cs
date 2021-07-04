using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Windows.Forms;
using Repository;

namespace Model
{
    public class Reservation
    {

        [Key]
        public int IdReservation { get; set; }
        public virtual Guest Guest { get; set; }
        [ForeignKey("guests")]
        public int IdGuest { get; set; }
        [Required] 
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public List<Room> rooms = new();

        public Reservation()
        {
        }

        public Reservation(
            Model.Guest guest,
            DateTime checkIn,
            DateTime checkOut
        )
        {
            IdGuest = guest.IdGuest;
            CheckIn = checkIn;
            CheckOut = checkOut;
            rooms = new List<Room>();
            guest.AddReservation(this);

            var db = new Context();
            db.Reservations.Add(this);
            db.SaveChanges();
        }

        public void AddRoom(Model.Room room)
        {
            var db = new Context();
            Model.ReservationRoom reservationRoom = new()
            {
                IdRoom = room.IdRoom,
                IdReservation = IdReservation
            };

            db.ReservationRooms.Add(reservationRoom);
            db.SaveChanges();
        }


        public static Reservation GetReservation(int reservationId)
        {
            var db = new Context();
            return (from reservation in db.Reservations
                    where reservation.IdReservation == reservationId
                    select reservation).First();
        }

        public static List<Reservation> GetReservations()
        {
            var db = new Context();
            return db.Reservations.ToList();
        }
        public static List<Model.Reservation> GetReservationByIdGuest(int guestId)
        {
            var db = new Context();
            return (from reservation in db.Reservations
                    where reservation.IdGuest == guestId
                    select reservation).ToList();
        }

        public static void UpdateReservation(
                int reservationId,
                DateTime checkIn,
                DateTime checkOut
                // double total
            )
        {
            var db = new Context();
            try
            {
                Reservation reservation = db.Reservations.First(reservation => reservation.IdReservation == reservationId);
                reservation.CheckIn = checkIn;
                reservation.CheckIn = checkIn;
                reservation.CheckOut = checkOut;
                // reservation.Total = total;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Erro ao Atualizar!");
            }
        }

        public static void DeleteReservation(int reservationId)
        {
            var db = new Context();
            try
            {
                Reservation reservation = db.Reservations.First(reservation => reservation.IdReservation == reservationId);
                db.Remove(reservation);
                db.SaveChanges();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Erro ao deletar!");
            }

        }
    }
}
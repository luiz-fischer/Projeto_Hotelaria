using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Repository;




namespace Model
{
    public class Reservation
    {

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

        public Reservation()
        {

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

        public static Reservation GetReservation(int reservationId)
        {
            var db = new Context();
            return (from reservation in db.Reservations
                    where reservation.ReservationId == reservationId
                    select reservation).First();
        }

        public static List<Reservation> GetReservations()
        {
            var db = new Context();
            return db.Reservations.ToList();
        }

        public static void InsertCheckIn(int reservationId)
        {
            var db = new Context();

            Reservation reservation = GetReservation(reservationId);
            reservation.CheckIn = DateTime.Now;
            db.SaveChanges();
        }

        public static void SetRoom(int reservationId, int roomId)
        {
            var db = new Context();

            Reservation reservation = GetReservation(reservationId);
            reservation.RoomId = roomId;
            db.SaveChanges();
        }

        public static void InsertCheckOut(int reservationId)
        {
            var db = new Context();

            Reservation reservation = GetReservation(reservationId);
            reservation.CheckOut = DateTime.Now;
            db.SaveChanges();
        }

        public static void UpdateReservation(
                int reservationId,
                DateTime reservationDate,
                int daysOfStay,
                DateTime checkIn,
                DateTime checkOut,
                double total
            )
        {
            var db = new Context();
            try
            {
                Reservation reservation = db.Reservations.First(reservation => reservation.ReservationId == reservationId);
                reservation.ReservationDate = reservationDate;
                reservation.DaysOfStay = daysOfStay;
                reservation.CheckIn = checkIn;
                reservation.CheckOut = checkOut;
                reservation.Total = total;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Erro ao Atualizar!");
            }
        }

        public static void UpdateTotal(int reservationId)
        {
            var db = new Context();
            Reservation reservation = GetReservation(reservationId);
            Room room = Room.GetRoomId(reservation.RoomId);
            Double TotalExpenses = 0;
            Double TotalDays = reservation.CheckOut.Subtract(reservation.CheckIn).TotalDays;
            Double AdditionalDays = TotalDays - reservation.DaysOfStay;
            foreach (Expense expense in Expense.GetExpenseByReservation(reservationId))
            {
                TotalExpenses += expense.Value;
            }
            if (TotalDays < reservation.DaysOfStay)
            {
                reservation.Total = (reservation.DaysOfStay * room.Value) + (AdditionalDays * 1.2 * room.Value) + TotalExpenses;
            }
            else if (TotalDays >= reservation.DaysOfStay)
            {
                reservation.Total = (reservation.DaysOfStay * room.Value) + (AdditionalDays * 1.2 * room.Value) + TotalExpenses;
            }
            db.SaveChanges();
        }

        public static void DeleteReservation(int reservationId)
        {
            var db = new Context();
            try
            {
                Reservation reservation = db.Reservations.First(reservation => reservation.ReservationId == reservationId);
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
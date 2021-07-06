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
        public List<Room> rooms = new List<Room>();

        public Reservation()
        {

        }

        public Reservation(
            Guest guest,
            DateTime checkIn,
            DateTime checkOut
        )
        {
            this.IdGuest = guest.IdGuest;
            this.CheckIn = checkIn;
            this.CheckOut = checkOut;
            rooms = new List<Room>();
            guest.AddReservation(this);

            Context db = new Context();
            db.Reservations.Add(this);
            db.SaveChanges();
        }

        public void AddRoom(Room room)
        {
            Context db = new Context();
            ReservationRoom reservationRoom = new ReservationRoom()
            {
                IdRoom = room.IdRoom,
                IdReservation = IdReservation
            };

            db.ReservationRooms.Add(reservationRoom);
            db.SaveChanges();
        }
        public double TotalValueReservation()
        {
            Guest guest = Guest.GetGuest(this.IdGuest);
            TimeSpan date = Convert.ToDateTime(this.CheckOut) - Convert.ToDateTime(this.CheckIn);

            int totalDays = date.Days;
            double total = 0;
            Context db = new Context();
            
            IEnumerable<int> rooms =
            from room in db.ReservationRooms
            where room.IdReservation == IdReservation
            select room.IdRoom;

            foreach (int id in rooms)
            {
                Room room = Room.GetRoom(id);
                total += room.RoomValue * totalDays;
            }

            return total;

        }

        public static Reservation GetReservation(int reservationId)
        {
            Context db = new Context();
            return (from reservation in db.Reservations
                    where reservation.IdReservation == reservationId
                    select reservation).First();
        }

        public static List<Reservation> GetReservations()
        {
            Context db = new Context();
            return db.Reservations.ToList();
        }
        public static List<Reservation> GetReservationByIdGuest(int guestId)
        {
            Context db = new Context();
            return (from reservation in db.Reservations
                    where reservation.IdGuest == guestId
                    select reservation).ToList();
        }

        public static void UpdateReservation(
                int reservationId,
                DateTime checkIn,
                DateTime checkOut
            )
        {
            Context db = new Context();
            try
            {
                Reservation reservation = db.Reservations.First(reservation => reservation.IdReservation == reservationId);
                reservation.CheckIn = checkIn;
                reservation.CheckIn = checkIn;
                reservation.CheckOut = checkOut;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Erro ao Atualizar!");
            }
        }

        public static void DeleteReservation(int reservationId)
        {
            Context db = new Context();
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

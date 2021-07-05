using System;
using System.Collections.Generic;
using System.Windows.Forms;
namespace Controller
{
    public class Reservation
    {
        public static Model.Reservation AddReservation(
            Model.Guest guest,
            DateTime checkIn,
            DateTime checkOut
        )
        {
            return new Model.Reservation(guest, checkIn, checkOut);
        }

        public static void DeleteReservation(int reservationId)
        {
            Model.Reservation reservation = Model.Reservation.GetReservation(reservationId);

            if (string.IsNullOrEmpty(reservation.CheckIn.ToString()))
            {
                Model.Reservation.DeleteReservation(reservationId);
            }
            else
            {
                MessageBox.Show("Não é possível remover.");
            }
        }

        public static Model.Reservation GetReservation(int reservationId)
        {
            return Model.Reservation.GetReservation(reservationId);
        }

        public static List<Model.Reservation> GetReservations()
        {
            return Model.Reservation.GetReservations();
        }

        public static List<Model.Reservation> GetReservationByIdGuest(int guestId)
        {
            return Model.Reservation.GetReservationByIdGuest(guestId);
        }
        public static List<Model.ReservationRoom> GetReservationsByIdRoom(int IdVeiculo)
        {
            return Model.ReservationRoom.GetReservationsByIdRoom(IdVeiculo);
        }
        public static Model.Reservation Add(Model.Guest guest, DateTime checkIn, DateTime checkOut)
        {
            return new Model.Reservation(guest, checkIn, checkOut);
        }

    }
}
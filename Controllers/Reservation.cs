using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Controller
{
    public class Reservation
    {
        public static Model.Reservation AddReservation(int guestId, DateTime date, int daysOfStay)
        {
            try
            {
                Guest.GetGuestId(guestId);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Hóspede não cadastrado!");
                if (date == null)
                {
                    MessageBox.Show(error.Message, "A data em Branco!");
                }
                if (daysOfStay <= 0)
                {
                    MessageBox.Show(error.Message, "Numeros de dias inválidos!");
                }
            }

            return new Model.Reservation(guestId, date, daysOfStay);
        }

        public static void DeleteReservation(int reservationId)
        {
            Model.Reservation reservation = Model.Reservation.GetReservation(reservationId);
            if (reservation.CheckIn == null)
            {
                Model.Reservation.DeleteReservation(reservationId);
            }
            else
            {
                MessageBox.Show("Não é possível remover uma reserva que já tenha tido o CheckIn feito.");
            }
        }

        public static List<Model.Reservation> GetReservations()
        {
            return Model.Reservation.GetReservations();
        }

        public static void CheckIn(int reservationId, int roomId)
        {
            if (reservationId == 0)
            {
                MessageBox.Show("Não foi selecionada nenhuma reserva");
            }

            if (roomId == 0)
            {
                MessageBox.Show("Não foi selecionado nenhum quarto");
            }
            try
            {
                Model.Reservation.SetRoom(reservationId, roomId);
                Model.Reservation.InsertCheckIn(reservationId);
            }
            catch
            {
                MessageBox.Show("Não foi possível Realizar o CheckIN");
            }


        }

        public static void CheckOut(int reservationId)
        {
            Model.Clean clean = Model.Clean.VerifyClean(reservationId);
            Model.Reservation.InsertCheckOut(reservationId);
            Model.Reservation.UpdateTotal(reservationId);
            Model.Clean.DeleteClean(clean.CleanId);
        }

        public static void SendToClean(int reservationId)
        {
            Model.Reservation reservation = Model.Reservation.GetReservation(reservationId);
            Controller.Clean.AddClean(reservation.RoomId);
        }
    }
}
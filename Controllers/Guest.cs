using System;
using System.Collections.Generic;
namespace Controller
{
    public class Guest
    {

        public static void AddGuest(
            string guestName,
            string guestBirth,
            int payment,
            string guestIdentification,
            string mothersName
        )
        {
            DateTime birthDate;
            try
            {
                birthDate = Convert.ToDateTime(guestBirth);
            }
            catch
            {
                Console.WriteLine("FORMATO INVÁLIDO!");
                birthDate = DateTime.Now;
            }

            new Model.Guest(
                guestName,
                guestBirth,
                payment,
                guestIdentification,
                mothersName
            );
        }

        public static void UpdateGuest(
            int guestId,
            string guestName,
            string guestBirth,
            double payment,
            string guestIdentification,
            string mothersName
        )
        {
            Model.Guest.UpdateGuest(
                guestId,
                guestName,
                guestBirth,
                payment,
                guestIdentification,
                mothersName
            );
        }

        public static void DeleteGuest(int guestId)
        {
            Model.Guest.DeleteGuest(guestId);
        }

        public static List<Model.Guest> GetGuests()
        {
            return Model.Guest.GetGuests();
        }

        public static Model.Guest GetGuestId(int guestsId)
        {
            return Model.Guest.GetGuestId(guestsId);
        }
    }
}
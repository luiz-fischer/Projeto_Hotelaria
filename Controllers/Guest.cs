using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Repository;

namespace Controller
{
    public class Guest
    {

        public static Model.Guest AddGuest(
            string guestName,
            DateTime guestBirth,
            int payment,
            string guestIdentification,
            string mothersName
        )
        {
            try
            {
                DateTime birthDate;
                birthDate = Convert.ToDateTime(guestBirth);
            }
            catch
            {
                Console.WriteLine("FORMATO INVÁLIDO!");
                guestBirth = DateTime.Now;
            }

            return new Model.Guest(
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
            DateTime guestBirth,
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
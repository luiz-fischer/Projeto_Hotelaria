using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Repository;



namespace Model
{
    public class Guest
    {
        [Key]
        public int GuestId { get; set; }
        public string GuestName { get; set; }
        public DateTime GuestBirth { get; set; }
        public double Payment { get; set; }
        public string GuestIdentification { get; set; }
        public string MothersName { get; set; }
        public List<Reservation> reservations = new();

        public Guest()
        {

        }

        public Guest(
            string guestName,
            DateTime guestBirth,
            double payment,
            string guestIdentification,
            string mothersName
        )
        {
            GuestName = guestName;
            GuestBirth = guestBirth;
            Payment = payment;
            GuestIdentification = guestIdentification;
            MothersName = mothersName;

            var db = new Context();
            db.Guests.Add(this);
            db.SaveChanges();

        }

        public override bool Equals(object obj)
        {
            return obj is Guest guest &&
                   GuestId == guest.GuestId &&
                   GuestName == guest.GuestName &&
                   GuestBirth == guest.GuestBirth &&
                   Payment == guest.Payment &&
                   GuestIdentification == guest.GuestIdentification &&
                   MothersName == guest.MothersName &&
                   EqualityComparer<List<Reservation>>.Default.Equals(reservations, guest.reservations);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(GuestId, GuestName, GuestBirth, Payment, GuestIdentification, MothersName, reservations);
        }

        public void AddReservation(Reservation reservation)
        {
            reservations.Add(reservation);
        }

        public static Guest GetGuest(int guestId)
        {
            var db = new Context();
            return (from guest in db.Guests
                    where guest.GuestId == guestId
                    select guest).First();
        }

        public static Guest GetGuestId(int guestId)
        {
            var db = new Context();
            return db.Guests.Find(guestId);
        }
        public static List<Guest> GetGuests()
        {
            var db = new Context();
            return db.Guests.ToList();
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
            var db = new Context();
            try
            {
                Guest guest = db.Guests.First(guest => guest.GuestId == guestId);
                guest.GuestName = guestName;
                guest.GuestBirth = guestBirth;
                guest.Payment = payment;
                guest.GuestIdentification = guestIdentification;
                guest.MothersName = mothersName;
                db.SaveChanges();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Erro ao Atualizar!");
            }
        }

        public static void DeleteGuest(int guestId)
        {
            var db = new Context();
            try
            {
                Guest guest = db.Guests.First(guest => guest.GuestId == guestId);
                db.Remove(guest);
                db.SaveChanges();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Erro ao deletar!");
            }
        }
    }

}
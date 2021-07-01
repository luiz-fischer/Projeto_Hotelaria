using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Windows.Forms;
using System.Text.RegularExpressions;


namespace  Model
{
    public class Guest {
        [Key]
        private int GuestId { get; set; }
        private string GuestName { get; set; }
        private DateTime GuestBirth { get; set; }
        private double Payment { get; set; }
        private string GuestIdentification { get; set; }
        private string MothersName { get; set; }
        public List<Reservation> reservations = new();

        public Guest(){
            
        }

        public Guest(
            int guestId,
            string guestName,
            DateTime guestBirth,
            double payment,
            string guestIdentification,
            string mothersName)
        {
            GuestId = guestId;
            GuestName = guestName;
            GuestBirth = guestBirth;
            Payment = payment;
            GuestIdentification = guestIdentification;
            MothersName = mothersName;

            // Context db = new(); // BD
            // db.SaveChanges();   // BD

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
    }
    
}
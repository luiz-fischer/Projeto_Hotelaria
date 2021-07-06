using System.Collections.Generic;
namespace Controller
{
    public static class Guest
    {

        public static void AddGuest(
            string guestName,
            string guestBirth,
            int payment,
            string guestIdentification,
            string mothersName
        )
        {

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

        public static Model.Guest GetGuest(int guestsId)
        {
            return Model.Guest.GetGuest(guestsId);
        }
    }
}

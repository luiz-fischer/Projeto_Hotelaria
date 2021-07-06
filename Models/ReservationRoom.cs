using System.Collections.Generic;
using System.Linq;
using Repository;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    public class ReservationRoom
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("reservations")]
        public int IdReservation { get; set; }
        public virtual Reservation Reservation { get; set; }
        [ForeignKey("rooms")]
        public int IdRoom { get; set; }
        public virtual Room Room { get; set; }

        public static List<ReservationRoom> GetReservationsByIdRoom(int IdRoom)
        {
            Context db = new Context();
            return (from reservation in db.ReservationRooms
                    where reservation.IdRoom == IdRoom
                    select reservation).ToList();
        }
    }
}

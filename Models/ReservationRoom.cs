using System.Collections.Generic;
using System.Linq;
using Repository;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model {
    public partial class ReservationRoom {
        [Key] 
        public int ReservationRoomId { get; set; }
        [ForeignKey("reservations")] 
        public int IdReservation { get; set; }
        public virtual Reservation Reservation { get; set; }
        [ForeignKey("rooms")] 
        public int IdRoom { get; set; }
        public virtual Room Room { get; set; }

        public static List<ReservationRoom> GetReservationsByRoom(int IdRoom)
        {
            var db = new Context();
            return (from reservation in db.ReservationRooms
                    where reservation.IdRoom == IdRoom
                    select reservation).ToList();
        }
    }
}
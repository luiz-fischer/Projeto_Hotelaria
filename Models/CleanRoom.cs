using System.Collections.Generic;
using System.Linq;
using Repository;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    public class CleanRoom
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("cleans")]
        public int IdClean { get; set; }
        public virtual Model.Clean Clean { get; set; }
        [ForeignKey("rooms")]
        public int IdRoom { get; set; }
        public virtual Model.Room Room { get; set; }

        public static List<CleanRoom> GetReservationsByIdRoom(int IdRoom)
        {
            var db = new Context();
            return (from clean in db.CleanRooms
                    where clean.IdRoom == IdRoom
                    select clean).ToList();
        }
    }
}
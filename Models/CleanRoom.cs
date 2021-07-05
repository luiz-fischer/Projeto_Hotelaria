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
        public virtual Clean Clean { get; set; }
        [ForeignKey("rooms")]
        public int IdRoom { get; set; }
        public virtual Room Room { get; set; }

        public static List<CleanRoom> GetCleansByIdRoom(int IdRoom)
        {
            var db = new Context();
            return (from clean in db.CleanRooms
                    where clean.IdRoom == IdRoom
                    select clean).ToList();
        }
        public static List<CleanRoom> GetRoomsByIdClean(int IdClean)
        {
            var db = new Context();
            return (from room in db.CleanRooms
                    where room.IdClean == IdClean
                    select room).ToList();
        }
        
    }
}

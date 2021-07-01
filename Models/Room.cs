using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Repository;


namespace Model {
    public partial class Room {
        [Key]
        public int RoomId { get; set; }
        public int Floor { get; set; }
        public string RoomNumber { get; set; }
        public string Description { get; set; }
        public double Value { get; set; }

        public Room(
            int floor,
            string roomNumber,
            string description,
            double value
        )
        {
            Floor = floor;
            RoomNumber = roomNumber;
            Description = description;
            Value = value;

            var db = new Context();
            db.Rooms.Add(this);
            db.SaveChanges();
        }

        public override bool Equals(object obj)
        {
            return obj is Room room &&
                   RoomId == room.RoomId &&
                   Floor == room.Floor &&
                   RoomNumber == room.RoomNumber &&
                   Description == room.Description &&
                   Value == room.Value;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(RoomId, Floor, RoomNumber, Description, Value);
        }
    }
}
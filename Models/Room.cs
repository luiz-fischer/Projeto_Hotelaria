using System;

namespace Model {
    public partial class Room {
        private int RoomId { get; set; }
        private int Floor { get; set; }
        private string RoomNumber { get; set; }
        private string Description { get; set; }
        private double Value { get; set; }

        public Room(
            int roomId,
            int floor,
            string roomNumber,
            string description,
            double value
        )
        {
            RoomId = roomId;
            Floor = floor;
            RoomNumber = roomNumber;
            Description = description;
            Value = value;
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
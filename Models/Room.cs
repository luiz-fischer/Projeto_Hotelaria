using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Windows.Forms;
using Repository;


namespace Model
{
    public partial class Room
    {
        [Key]
        public int RoomId { get; set; }
        public int RoomFloor { get; set; }
        public string RoomNumber { get; set; }
        public string RoomDescription { get; set; }
        public double RoomValue { get; set; }

        public Room(
            int roomFloor,
            string roomNumber,
            string roomRoomDescription,
            double roomRoomValue
        )
        {
            RoomFloor = roomFloor;
            RoomNumber = roomNumber;
            RoomDescription = roomRoomDescription;
            RoomValue = roomRoomValue;

            var db = new Context();
            db.Rooms.Add(this);
            db.SaveChanges();
        }

        public override bool Equals(object obj)
        {
            return obj is Room room &&
                   RoomId == room.RoomId &&
                   RoomFloor == room.RoomFloor &&
                   RoomNumber == room.RoomNumber &&
                   RoomDescription == room.RoomDescription &&
                   RoomValue == room.RoomValue;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(RoomId, RoomFloor, RoomNumber, RoomDescription, RoomValue);
        }
        public static Room GetRoom(int roomId)
        {
            var db = new Context();
            return (from room in db.Rooms
                    where room.RoomId == roomId
                    select room).First();
        }

        public static List<Room> GetRooms()
        {
            var db = new Context();
            return db.Rooms.ToList();
        }
        
        public static Room GetRoomId(int roomId)
        {
            var db = new Context();
            return db.Rooms.Find(roomId);
        }

        public static void UpdateRoom(
            int roomId,
            int roomFloor,
            string roomNumber,
            string roomRoomDescription,
            double roomRoomValue
            )
        {
            var db = new Context();
            try
            {
                Room room = db.Rooms.First(room => room.RoomId == roomId);
                room.RoomFloor = roomFloor;
                room.RoomNumber = roomNumber;
                room.RoomDescription = roomRoomDescription;
                room.RoomValue = roomRoomValue;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Erro ao Atualizar!");
            }
        }
        public static void DeleteRoom(int roomId)
        {
            var db = new Context();
            try
            {
                Room room = db.Rooms.First(room => room.RoomId == roomId);
                db.Remove(room);
                db.SaveChanges();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Erro ao deletar!");
            }

        }
    }
}
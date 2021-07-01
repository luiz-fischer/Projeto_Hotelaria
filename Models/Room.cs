using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Repository;


namespace Model
{
    public partial class Room
    {
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

        public static void UpdateRoom(
            int roomId,
            int floor,
            string roomNumber,
            string description,
            double value
            )
        {
            var db = new Context();
            try
            {
                Room room = db.Rooms.First(room => room.RoomId == roomId);
                room.Floor = floor;
                room.RoomNumber = roomNumber;
                room.Description = description;
                room.Value = value;
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
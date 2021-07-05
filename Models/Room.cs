using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Windows.Forms;
using Repository;

namespace Model
{
    public class Room
    {
        [Key]
        public int IdRoom { get; set; }
        public int RoomFloor { get; set; }
        public string RoomNumber { get; set; }
        public string RoomDescription { get; set; }
        public double RoomValue { get; set; }
        public List<Reservation> reservations = new List<Reservation>();
        public List<Clean> cleans = new List<Clean>();

        public Room()
        {

        }


        public Room(
            int roomFloor,
            string roomNumber,
            string roomDescription,
            double roomValue
        )
        {
            this.RoomFloor = roomFloor;
            this.RoomNumber = roomNumber;
            this.RoomDescription = roomDescription;
            this.RoomValue = roomValue;

            var db = new Context();
            db.Rooms.Add(this);
            db.SaveChanges();
        }

        public static Room GetRoom(int roomId)
        {
            var db = new Context();
            return (from room in db.Rooms
                    where room.IdRoom == roomId
                    select room).First();
        }
        public void AddReservation(Reservation reservation)
        {
            reservations.Add(reservation);
        }

        public static List<Room> GetRooms()
        {
            Context db = new Context();
            return db.Rooms.ToList();
        }

        public static void UpdateRoom(
            int roomId,
            int roomFloor,
            string roomNumber,
            string roomDescription,
            double roomValue
        )
        {
            Context db = new Context();
            try
            {
                Room room = db.Rooms.First(room => room.IdRoom == roomId);
                room.RoomFloor = roomFloor;
                room.RoomNumber = roomNumber;
                room.RoomDescription = roomDescription;
                room.RoomValue = roomValue;
                db.SaveChanges();
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
                Room room = db.Rooms.First(room => room.IdRoom == roomId);
                db.Remove(room);
                db.SaveChanges();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Erro ao deletar!");
            }

        }
        public void AddClean(Clean clean)
        {
            cleans.Add(clean);
        }
    }
}

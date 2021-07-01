using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Repository;

namespace Controller {
    public class Room {
        public static Model.Room AddRooms(
            int number,
            string roomFloor,
            string roomDescription,
            double roomValue
        )
        {
            return new Model.Room(number, roomFloor, roomDescription, roomValue);
        }

        public static void UpdateRoom(
            int roomId,
            int roomFloor,
            string roomNumber,
            string roomDescription,
            double roomValue
        )
        {
            Model.Room.UpdateRoom(roomId, roomFloor, roomNumber, roomDescription, roomValue);
        }

        public static void DeleteRoom(int RoomId)
        {
            Room.DeleteRoom(RoomId);
        }

        public static List<Model.Room> Rooms => Model.Room.GetRooms();

        public static Model.Room GetRoomsById(int roomsId)
        {
            return Model.Room.GetRoomId(roomsId);
        }

        public static List<Room> GetRooms()
        {
            var db = new Context();
            IQueryable<Room> rooms = (IQueryable<Room>)(from room in db.Rooms select room);
            return rooms.ToList();
        }
    }
}
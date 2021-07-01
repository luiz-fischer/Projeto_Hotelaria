using System.Collections.Generic;

namespace Controller {
    public class Room {
        public static Model.Room AddRooms(
            int number,
            string roomFloor,
            string roomDescription,
            double roomValue
        )
        {
            return new Model.Room(
                number,
                roomFloor,
                roomDescription,
                roomValue
            );
        }

        public static void UpdateRoom(
            int roomId,
            int roomFloor,
            string roomNumber,
            string roomDescription,
            double roomValue
        )
        {
            Model.Room.UpdateRoom(
                roomId,
                roomFloor,
                roomNumber,
                roomDescription,
                roomValue);
        }

        public static void DeleteRoom(int RoomId)
        {
            Model.Room.DeleteRoom(RoomId);
        }

        public static Model.Room GetRoomsById(int roomsId)
        {
            return Model.Room.GetRoomId(roomsId);
        }

        public static List<Model.Room> GetRooms()
        {
            return Model.Room.GetRooms();
        }
    }
}
using HotelRoom_Architecture_DataAnnotation_FluentAPI.Models;

namespace HotelRoomDB.repositories
{
    public interface IRoomRepo
    {
        void AddRoom(Room room);
        void DeleteRoom(int roomId);
        List<Room> GetAllRooms();
        Room GetRoomById(int roomId);
        void UpdateRoom(Room room);
    }
}
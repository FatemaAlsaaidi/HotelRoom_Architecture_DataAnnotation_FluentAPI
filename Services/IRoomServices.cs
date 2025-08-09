using HotelRoom_Architecture_DataAnnotation_FluentAPI.Models;

namespace HotelRoomDB.Services
{
    public interface IRoomServices
    {
        void AddNewRoom(decimal dailyRate, bool isAvailable);
        List<Room> GetAllRooms();
        Room GetRoomByID(int id);
        void RemoveRoom(int id);
        void UpdateRoom(int RoomId, bool isReserved);
        void UpdateRoom(int RoomId, int daliyRate);
    }
}
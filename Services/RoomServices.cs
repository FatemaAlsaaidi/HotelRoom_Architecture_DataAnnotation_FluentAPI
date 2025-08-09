using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelRoomDB.repositories; // Assuming this is the correct namespace for IRoomRepo
using HotelRoom_Architecture_DataAnnotation_FluentAPI.Models;


namespace HotelRoomDB.Services
{
    public class RoomServices
    {
        // Constructor Injection 
        private readonly IRoomRepo _roomRepository;
        public RoomServices(IRoomRepo roomRepository)
        {
            _roomRepository = roomRepository ?? throw new ArgumentNullException(nameof(roomRepository));
        }

        // Add methods for room services here, e.g., GetRoomById, AddRoom, UpdateRoom, DeleteRoom, etc.
        // Add new Room to the database through the repository
        public void AddNewRoom(decimal dailyRate, bool isAvailable)
        {
            // Create a new Room object
            var room = new Room
            {
                DailyRate = dailyRate,
                IsReserved = isAvailable
            };
            _roomRepository.AddRoom(room);
        }

        // Get All Rooms in the database through the repository
        public List<Room> GetAllRooms()
        {
            return _roomRepository.GetAllRooms();
        }

        // Get Room by id 
        public Room GetRoomByID(int id) 
        { 
            return _roomRepository.GetRoomById(id);
        }

        // Remove Room
        public void RemoveRoom(int id) 
        { 
            _roomRepository.DeleteRoom(id);
        }
    }
}

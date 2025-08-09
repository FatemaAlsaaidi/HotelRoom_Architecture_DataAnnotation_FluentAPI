using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelRoomDB.repositories; // Assuming this is the correct namespace for IRoomRepo


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
        
    }
}

using HotelRoom_Architecture_DataAnnotation_FluentAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelRoom_Architecture_DataAnnotation_FluentAPI.Models;

namespace HotelRoomDB.repositories
{
    public class RoomRepo
    {
        // Constructor Injection is used to provide the database context to the repository
        private readonly HotelRoomManagementDBContext _context; // This is the database context that interacts with the database
        public RoomRepo(HotelRoomManagementDBContext context) // Constructor that initializes the context
        {
            _context = context;
        }

        /// <summary>
        /// You can add methods here to interact with the Room entity, such as adding, updating, deleting, or retrieving rooms.
        /// </summary>
        /// <returns></returns>
       //  get all rooms from the database
        public List<Room> GetAllRooms() 
        {
            return _context.Rooms.ToList(); // Fetches all rooms from the database
        }
    }
}

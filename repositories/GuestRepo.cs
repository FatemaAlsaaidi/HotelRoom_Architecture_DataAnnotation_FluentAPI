using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelRoom_Architecture_DataAnnotation_FluentAPI;


namespace HotelRoomDB.repositories
{
    public class GuestRepo
    {
        private readonly HotelRoomManagementDBContext _context; 
        public GuestRepo(HotelRoomManagementDBContext context)
        {
            _context = context;
        }
    }
}

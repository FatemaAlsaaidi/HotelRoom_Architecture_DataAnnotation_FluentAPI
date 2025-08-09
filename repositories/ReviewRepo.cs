using HotelRoom_Architecture_DataAnnotation_FluentAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRoomDB.repositories
{
    public class ReviewRepo
    {
        private readonly HotelRoomManagementDBContext _context;
        public ReviewRepo(HotelRoomManagementDBContext context)
        {
            _context = context;
        }
    }
}

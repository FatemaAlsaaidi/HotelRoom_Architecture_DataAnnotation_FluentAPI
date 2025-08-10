using HotelRoomDB.repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRoomDB.Services
{
    public class AuthService
    {
        // Constructor to inject the repository
        private readonly IGuestRepo _repo;
        public AuthService(IGuestRepo repo) => _repo = repo;


    }
}

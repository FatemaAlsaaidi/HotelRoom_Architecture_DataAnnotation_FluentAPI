using HotelRoom_Architecture_DataAnnotation_FluentAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore; // for DbContext and DbSet

namespace HotelRoom_Architecture_DataAnnotation_FluentAPI
{
    public class HotelRoomManagementDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-J26O8DP\\SQLEXPRESS01;Initial Catalog=HotelRoomManagementDB;Integrated Security=True;TrustServerCertificate=True");
        }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Review> Reviews { get; set; }


        // Fluent api room model
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ----- Room -----
            modelBuilder.Entity<Room>(b =>
            {
                b.HasKey("RoomId");
                b.Property(r => r.RoomId)
                    .ValueGeneratedOnAdd(); // Auto-increment primary key
                b.Property(r => r.DailyRate).HasPrecision(10, 2).IsRequired();
                b.Property(r => r.IsReserved)
                    .IsRequired()
                    .HasDefaultValue(false)
                    .HasComment("Indicates if the room is currently reserved");
                
            });
                

           



    }

}

}

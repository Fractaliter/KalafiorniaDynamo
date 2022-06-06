using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace HotelKalafiornia.Models
{
    public class HotelContext : DbContext
    {
        public HotelContext(DbContextOptions<HotelContext> options)
               : base(options)
        { }
        public DbSet<Room> Rooms { get; set; }

    }
    public class Room
    {
        #region Fields

        public int RoomId { get; set; }
        [Required]
        public string RoomType { get; set; }
        public double PricePerNight { get; set; }
        public int MaxPersons { get; set; }
        public bool IsLocked { get; set; }
        #endregion
        #region Constructors
        public Room()
        {
            this.IsLocked = false;
        }
        #endregion
    }
}

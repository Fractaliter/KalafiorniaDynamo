using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Microsoft.EntityFrameworkCore;

namespace HotelKalafiornia.Models
{
    [Table("Bookings")]
    public class Booking
    {
        #region Fields
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public DateTime ArrivalDate { get; set; }
        [Required]
        public DateTime CheckoutDate { get; set; }
        [Required]
        public ICollection<Room> RoomId { get; set; }
        [Required]
        public Customer CustomerId { get; set; }
        [Required]
        public bool Breakfast { get; set; }
        [NotMapped]
        public int Nights { get; set; }
        public DateTime BookDate { get; set; }
        public bool IsCancelled { get; set; }
        public DateTime CancelledDate { get; set; }
        public string Comment { get; set; }
        #endregion
        #region Constructors
        public Booking()
        {
            this.IsCancelled = false;
            this.BookDate = DateTime.Now;
            this.Nights = (CheckoutDate - ArrivalDate).Days;
        }
        #endregion
    }
}
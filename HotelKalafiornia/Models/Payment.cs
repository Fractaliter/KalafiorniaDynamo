using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HotelKalafiornia.Models
{
    [Table("Payments")]
    public class Payment
    {
        #region Fields
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Booking BookingId { get; set; }
        public Customer CustomerId { get; set; }
        [NotMapped]
        public double Amount { get; set; }
        public bool IsPaid { get; set; }
        public DateTime? PaidDate { get; set; }
        #endregion
        #region Constructors
        public Payment()
        {
            this.IsPaid = false;
        }
        #endregion
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HotelKalafiornia.Models
{
    [Table("Customers")]
    public class Customer
    {
        #region Fields
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MinLength(3), MaxLength(24), Required]
        public string FirstName { get; set; }
        [MinLength(2), MaxLength(32), Required]
        public string LastName { get; set; }
        [MaxLength(128)]
        public string Address { get; set; }
        [MinLength(6), MaxLength(6)]
        public string PostalCode { get; set; }
        [MaxLength(128)]
        public string City { get; set; }
        [MaxLength(128)]
        public string Country { get; set; }
        [MaxLength(128), Required]
        public string EMail { get; set; }
        [MaxLength(11), Required]
        public string Phone { get; set; }
        public DateTime RegisterDate { get; set; }
        #endregion
        #region Constructors
        public Customer()
        {
            this.RegisterDate = DateTime.Now;
        }
        #endregion
    }
}
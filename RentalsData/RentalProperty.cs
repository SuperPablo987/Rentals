using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentalsData
{
    [Table("RentalProperty")]
    public class RentalProperty
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter Address")]
        [StringLength(100)]
        public string Address { get; set; }
        [Required(ErrorMessage = "Please enter City")]
        [StringLength(50)]
        public string City { get; set; }
        [Required(ErrorMessage = "Please enter Province")]
        [StringLength(15)]
        public string Province { get; set; }
        [Required(ErrorMessage = "Please enter Postal Code")]
        [StringLength(15)]
        public string PostalCode { get; set; }
        [Range(1, 10000)]
        public decimal Rent { get; set; }
        public int PropertyTypeId { get; set; }
        public int OwnerId { get; set; }
        //nullable int required if FK is nullable
        public int? RenterId { get; set; }
        //navigation properties
        public PropertyType PropertyType { get; set; }
        public Owner Owner { get; set; }
        public Renter Renter { get; set; }
    }
}

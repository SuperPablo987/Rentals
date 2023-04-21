using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentalsData
{
    [Table("Owner")]
    public class Owner
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter name")]
        [StringLength(100)]
        [Display(Name = "Owner")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Please enter phone number")]
        [StringLength(12)]
        public string Phone { get; set; }
        //navigation property
        public ICollection<RentalProperty> RentalProperties { get; set; }
    }
}

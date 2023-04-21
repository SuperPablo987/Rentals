using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace RentalsData
{
    [Table("Renter")]
    public class Renter
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter First Name")]
        [StringLength(30)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please enter Last Name")]
        [StringLength(40)]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please enter Phone")]
        [StringLength(12)]
        public string Phone { get; set; }
        //navigation property (one-to-one)
        public RentalProperty RentalProperty { get; set; }
    }
}

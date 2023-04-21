using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentalsData
{
    [Table("PropertyType")]
    public class PropertyType
    {

        public int Id { get; set; }
        [Required(ErrorMessage ="Please enter style")]
        [StringLength(50)]
        public string Style { get; set; }
        //navigation property
        public ICollection<RentalProperty> RentalProperties { get; set; }
    }
}

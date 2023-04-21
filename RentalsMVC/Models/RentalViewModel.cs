using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RentalsMVC.Models
{
    // view model for displaying rentals as read-only list
    public class RentalViewModel
    {
        public string Address { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string Rent { get; set; } // formatted Rent
        [Display(Name = "Propery Type")]
        public string PropertyType { get; set; } // Style of the property type
        public string Owner { get; set; } // Name of the owner
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalsData
{
    [Table("Users")]
    public class User
    {
        public int Id { get; set; }
        [Required(ErrorMessage="Please enter username")]
        [StringLength(50)]
        public string Username { get; set; }
        [Required(ErrorMessage = "Please enter password")]
        [StringLength(75)]
        public string Password { get; set; }
        [StringLength(100)]
        public string FullName { get; set; }
        [StringLength(50)]
        public string Role { get; set; }

        public int? OwnerID { get; set; }
        // navigation property
        public Owner? Owner { get; set; }
    }
}

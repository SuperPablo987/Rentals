using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalsData
{
    public static class RentalsManager
    {
        /// <summary>
        /// get all rental propeties, including owner and property type
        /// </summary>
        /// <returns>list of rental properties</returns>
        public static List<RentalProperty> GetAll()
        {
            RentalsContext db = new RentalsContext();
            List<RentalProperty> rentals = db.RentalProperties.
                Include(r => r.Owner).Include(r => r.PropertyType).ToList();
            return rentals;
        }

        /// <summary>
        /// filter properties by owner
        /// </summary>
        /// <param name="id">owner's id</param>
        /// <returns>filtered list of properties</returns>
        public static List<RentalProperty> GetPropertiesByOwner(int id = 0)
        {
            List<RentalProperty> rentals = null;
            RentalsContext db = new RentalsContext();
            if (id == 0) // no filtering
            {
                rentals = db.RentalProperties.Include(r => r.Owner).Include(r => r.PropertyType).ToList();
            }
            else // filter by owner
            {
                rentals = db.RentalProperties.
                Where(r => r.OwnerId == id).
                Include(r => r.Owner).Include(r => r.PropertyType).ToList();
            }          
            return rentals;
        }

        /// <summary>
        /// adds rental property
        /// </summary>
        /// <param name="rental">rental property to add</param>
        public static void Add(RentalProperty rental)
        {
            RentalsContext db = new RentalsContext();
            db.RentalProperties.Add(rental);
            db.SaveChanges();
        }

    }
}

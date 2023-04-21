using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalsData
{
    public static class OwnersManager
    {
        /// <summary>
        /// retries all owners
        /// </summary>
        /// <returns>list of owners in alphabetic order</returns>
        public static List<Owner> GetAll()
        {
            RentalsContext db = new RentalsContext();
            List<Owner> owners = db.Owners.OrderBy(o => o.Name).ToList();
            return owners;
        }

        /// <summary>
        /// add a new owner
        /// </summary>
        /// <param name="owner">owner data to add</param>
        public static void Add(Owner owner)
        {
            RentalsContext db = new RentalsContext();
            db.Owners.Add(owner);
            db.SaveChanges();
        }
       
    }
}

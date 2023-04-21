using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalsData
{
    public static class PropertyTypesManager
    {
        /// <summary>
        /// gets property types as value/text pairs for select drop down
        /// </summary>
        /// <returns>list of text/value pairs</returns>
        public static IList GetAllAsKeyValuePairs()
        {
            RentalsContext db = new RentalsContext();
            var types = db.PropertyTypes.Select(t => new {
                Value = t.Id,
                Text = t.Style
            }).ToList();
            return types;
        }

        /// <summary>
        /// get all property types
        /// </summary>
        /// <returns></returns>
        public static List<PropertyType> GetAll()
        {
            RentalsContext db = new RentalsContext();
            List<PropertyType> types = db.PropertyTypes.OrderBy(o => o.Style).ToList();
            return types;
        }
    }
}

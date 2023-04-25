using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalsData
{
    /// <summary>
    /// Class is responsible for authenticating and managing users.
    /// </summary>
    public class UserManager
    {
        // utilizes static constructor for first run
        //private readonly static List<User> _users;
        //// static constructor
        //static UserManager()
        //{
        //    _users = new List<User>();
        //    _users.Add(new User
        //    {
        //        Id = 1,
        //        Username = "jdoe",
        //        Password = "password",
        //        FullName = "John Doe",
        //        Role = "Manager"
        //    });
        //    _users.Add(new User
        //    {
        //        Id = 2,
        //        Username = "khunter",
        //        Password = "password",
        //        FullName = "Karen Hunter",
        //        Role = "Staff"
        //    });
        //}

        /// <summary>
        /// User is authenticated based on credentials and a user returned if exists or null if not.
        /// </summary>
        /// <param name="username">Username as string</param>
        /// <param name="password">Password as string</param>
        /// <returns>A user object or null.</returns>
        /// <remarks>
        /// Add additional for the docs for this application--for developers.
        /// </remarks>
        public static User Authenticate(string username, string password)
        {
            User user = null;
            using(RentalsContext dB = new RentalsContext())
            {
                user = dB.Users.SingleOrDefault(usr => usr.Username == username
                                                    && usr.Password == password);
            }
            // for static constructor method
            //var user = _users.SingleOrDefault(usr => usr.Username == username
            //&& usr.Password == password);
            return user; //this will either be null or an object
        }
    }
}

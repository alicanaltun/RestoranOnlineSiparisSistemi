using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp
{
    internal class UserSession
    {
        public static string UserName { get; set; }
        public static string UserEmail { get; set; }
        public static int UserId { get; set; }
        public static string HashedPassword { get; set; }
    }
}

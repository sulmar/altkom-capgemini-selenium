using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.Fundamentals
{
    public class Rent
    {
        public User Rentee { get; set; }

        public bool CanReturn(User user)
        {
            if (user == null)
                throw new ArgumentNullException();

            if (user.IsAdmin)
                return true;

            if (Rentee == user)
                return true;

            return false;
        }

    }


    public class User
    {
        public bool IsAdmin { get; set; }
    }
}

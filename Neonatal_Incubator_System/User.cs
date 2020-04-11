using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neonatal_Incubator_System
{
    class User
    {
        public string FullName { get; set; }
        public string Username { get; set; }
        public string InstitutionName { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        private static string error = "Username does not exist";

        public static void showError()
        {
            System.Windows.Forms.MessageBox.Show(error);
        }

        public static bool Isequal(User user1, User user2)
        {
            if(user1 == null || user2 == null)
            {
                return false;
            }
            else if(user1.Username != user2.Username)
            {
                error = "Username does not exist";
                return false;
            }
            else if (user1.Password != user2.Password)
            {
                error = "password does not match";
                return false;
            }

            return true;
        }
    }
}

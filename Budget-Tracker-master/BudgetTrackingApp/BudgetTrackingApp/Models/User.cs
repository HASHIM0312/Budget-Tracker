using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetTrackingApp.Models
{
    class User
    {
        string userName { get; set; }


        string userEmail { get; set; }

        private string userPassword;



        string userPhoneNumber { get; set; }

        public void User(string userName_, string userEmail_, string userPassword, string userPhoneNumber)
        {
            userName = userName_;
            userEmail = userEmail_;
            userPassword = userPassword;
            userPhoneNumber = userPhoneNumber;

        }
    }
}

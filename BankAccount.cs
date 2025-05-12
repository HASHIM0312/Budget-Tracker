using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetTrackingApp
{
    public class BankAccount
    {
        

        public int Spent { get; set; } = 0;
        public int CurrentBalance { get; set; } = 0;

      
        public BankAccount(int currentBalance_)
        {
            CurrentBalance = currentBalance_;
        }

      
    }
}

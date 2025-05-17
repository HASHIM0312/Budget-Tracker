using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetTrackingApp
{


    /// <summary>
    /// Represents a bank account for a user.
    /// With properties for the current balance and amount spent.
    /// Constructed with an initial balance.
    /// </summary>
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

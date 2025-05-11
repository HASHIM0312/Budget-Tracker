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
        //Hello

        public int Spent { get; set; } = 0;
        public int CurrentBalance { get; set; } = 0;

        //Started on new stuff from new laptop
        public BankAccount(int currentBalance_)
        {
            CurrentBalance = currentBalance_;
        }

      
    }
}

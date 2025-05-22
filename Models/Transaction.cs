using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetTrackingApp.Models
{
    public class Transaction
    {
        public bool transactionType { get; set; } // true for deposit, false for withdrawal
        public decimal amount { get; set; }
        public DateTime dateCreated { get; set; }
    }
}

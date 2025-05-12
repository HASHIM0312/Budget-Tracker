using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetTrackingApp.Models
{
    public class User : INotifyPropertyChanged
    {
        private decimal goal;
        public decimal Goal
        {
            get { return goal; }
            set
            {
                if (goal != value)
                {
                    if (value < 0)
                    {
                        throw new ArgumentException("Goal must be positive");
                    }
                    goal = decimal.Round(value, 2, MidpointRounding.AwayFromZero); ;
                    OnPropertyChanged(nameof(Goal));
                }
            }
        }

        
        public BankAccount bankAccount { get; set; }

        public string userName { get; set; }
        public string email { get; set; }
        public string password { get; set; }

        public User(string userName_, string email_, string password_, BankAccount bankAccount_)
        {
            userName = userName_;
            email = email_;
            password = password_;
            bankAccount = bankAccount_;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetTrackingApp.Models
{
    class User : INotifyPropertyChanged
    {
        private decimal goal;
        public decimal Goal
        {
            get { return goal; }
            set
            {
                if (goal != value)
                {
                    goal = value;
                    OnPropertyChanged(nameof(Goal));
                }
            }
        }

        
        public BankAccount bankAccount { get; set; }

        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }

        public User(string name_, string email_, string password_, BankAccount bankAccount_)
        {
            name = name_;
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

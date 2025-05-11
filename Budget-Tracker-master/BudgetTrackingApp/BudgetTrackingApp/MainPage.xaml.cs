using BudgetTrackingApp.Models;

namespace BudgetTrackingApp
{
    public partial class MainPage : ContentPage
    {

        private User _user;
        private BankAccount _bankAccount = new BankAccount(1000); // Example initial balance

        public MainPage()
        {
            InitializeComponent();
            _user = new User("Default", "default@example.com", "password", _bankAccount);
            BindingContext = _user;
        }
        private void OnSetGoalClicked(object sender, EventArgs e)
        {
            if (decimal.TryParse(GoalEntry.Text, out decimal goalAmount))
            {
                _user.Goal = goalAmount;
            }
            else
            {
                Console.WriteLine("Invalid goal amount");
            }
        }



    }

}

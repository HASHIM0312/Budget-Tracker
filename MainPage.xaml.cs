using BudgetTrackingApp.Models;

namespace BudgetTrackingApp
{
    public partial class MainPage : ContentPage
    {

        private User _user;
       

        public MainPage(User user)
        {
            InitializeComponent();
            _user = user;
            BindingContext = _user;

        }
        private void OnSetGoalClicked(object sender, EventArgs e)
        {
            try
            {
                if (decimal.TryParse(GoalEntry.Text, out decimal goalAmount))
                {
                    _user.Goal = goalAmount;
                }
                else
                {
                    DisplayAlert("Invalid goal", "Goal must be a valid decimal number (ex. 40.00 or 40.25)", "OK");
                }
            } catch(ArgumentException ex) 
            { 
                DisplayAlert("Invalid goal", ex.Message, "OK");
            
            }
           
        }



    }

}

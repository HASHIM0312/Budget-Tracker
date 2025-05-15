using System.Threading.Tasks;
using BudgetTrackingApp.Models;

namespace BudgetTrackingApp
{
   
    public partial class MainPage : ContentPage
    {

        private readonly UserState _userState;



        public MainPage()
        {
            InitializeComponent();
            _userState = Application.Current.Handler.MauiContext.Services.GetService<UserState>();
            BindingContext = _userState.CurrentUser;

        }
        private void OnSetGoalClicked(object sender, EventArgs e)
        {
            try
            {
                if (decimal.TryParse(GoalEntry.Text, out decimal goalAmount))
                {
                    _userState.CurrentUser.Goal = goalAmount;
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

        private async void OnSignOutClicked(object sender, EventArgs e)
        {
            if (await DisplayAlert("Confirm Sign out?", "This will take you back to Login Page", "OK", "NO"))
            {


                var currentWindow = Application.Current.Windows.FirstOrDefault();
                if (currentWindow != null)
                {
                    currentWindow.Page = new LoginPage();
                }
            }
        }



    }

}

using BudgetTrackingApp.Models;

namespace BudgetTrackingApp.Pages
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void OnLoginClicked(object sender, EventArgs e)
        {

            
            string email = EmailEntry.Text;
            string password = PasswordEntry.Text;

            //Validate Input by calling Authentication.ValidateEmailAndPassword
            if (!Authentication.ValidEmailAndPassword(email, password))
            {
                await DisplayAlert("Invalid Input", "Please enter a valid email and password.", "OK");
                return;
            }

            var bankAccount = new BankAccount(1000); // Example initial balance
            var user = new User(email, password, bankAccount);


            // Attempt to authenticate the user
            if (!await Authentication.LoginUser(user))
            { 
                await DisplayAlert("Login Failed", "Incorrect credentials", "OK");
                return;
            }

            // Ensure Application.Current is cast to IServiceProvider
            var userState = Application.Current.Handler.MauiContext.Services.GetService<UserState>();
             
            userState.CurrentUser = user;



            GoToMainPage();

        }

        private async void OnNavigateToSignupClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new SignUpPage());
        }


        private void GoToMainPage()
        {
            var currentWindow = Application.Current.Windows.FirstOrDefault();
            if (currentWindow != null)
            {
                currentWindow.Page = new AppShell();
            }
        }



    }
}
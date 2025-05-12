using BudgetTrackingApp.Models;

namespace BudgetTrackingApp
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void OnLoginClicked(object sender, EventArgs e)
        {
            // Retrieve user input
            string userName = UserNameEntry.Text;
            string email = EmailEntry.Text;
            string password = PasswordEntry.Text;

            // Validate input (basic example)
            if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                await DisplayAlert("Error", "All fields are required.", "OK");
                return;
            }

            // Create a User object and navigate to MainPage
            var bankAccount = new BankAccount(1000); // Example initial balance
            var user = new User(userName, email, password, bankAccount);

            // Navigate to MainPage and pass the user object
            await Navigation.PushAsync(new MainPage(user));
        }
    }
}
using BudgetTrackingApp.Models;

namespace BudgetTrackingApp;

public partial class SignUpPage : ContentPage
{
	public SignUpPage()
	{
		InitializeComponent();
	}

    private async void OnSignUpClicked(object sender, EventArgs e)
    {
        // Retrieve user input
        string userName = UserNameEntry.Text;
        string email = EmailEntry.Text;
        string password = PasswordEntry.Text;
        string confirmPassword = ConfirmPasswordEntry.Text;


        //Validate Input by calling Authentication.ValidateEmailAndPassword
        if (!Authentication.ValidEmailAndPassword(email, password))
        {
            await DisplayAlert("Invalid Input", "Please enter a valid email and password.", "OK");
            return;
        }
        var bankAccount = new BankAccount(1000); // Example initial balance
        var user = new User(userName, email, password, bankAccount);
        
        
        // Attempt to authenticate the user
        if (!await Authentication.RegisterUser(user))
        {
            await DisplayAlert("Sign Up Failed", "An error has occured", "OK");
            return;
        }


        // Ensure Application.Current is cast to IServiceProvider
        var userState = Application.Current.Handler.MauiContext.Services.GetService<UserState>();
        userState.CurrentUser = user;




        GoToLoginPage();
       
        
    }

    private async void OnNavigateToLoginClicked(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
    }
    private void GoToLoginPage()
    {
        var currentWindow = Application.Current.Windows.FirstOrDefault();
        if (currentWindow != null)
        {
            currentWindow.Page = new LoginPage();
        }
    }


}
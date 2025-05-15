using BudgetTrackingApp.Models;

namespace BudgetTrackingApp;

[QueryProperty(nameof(User), "User")]
public partial class DepositExpense : ContentPage
{
    private readonly UserState _userState;

    public DepositExpense()
    {
        InitializeComponent();
        _userState = Application.Current.Handler.MauiContext.Services.GetService<UserState>();
        BindingContext = _userState.CurrentUser; // Use the logged-in user
    }

}
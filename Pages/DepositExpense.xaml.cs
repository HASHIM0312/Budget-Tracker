using Amazon;
using Amazon.DynamoDBv2;
using BudgetTrackingApp.Models;

namespace BudgetTrackingApp.Pages;

[QueryProperty(nameof(User), "User")]
public partial class DepositExpense : ContentPage
{
    private readonly UserState _userState;

    

    public DepositExpense()
    {
        InitializeComponent();
        _userState = Application.Current.Handler.MauiContext.Services.GetService<UserState>();
        
       
    }

    public void OnAddDepositClicked(object sender, EventArgs e)
    {

    }

    public void OnAddExpenseClicked(object sender, EventArgs e)
    {
    }






}
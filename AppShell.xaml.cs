﻿using BudgetTrackingApp.Pages;

namespace BudgetTrackingApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
            Routing.RegisterRoute(nameof(DepositExpense), typeof(DepositExpense));
        }
    }
}
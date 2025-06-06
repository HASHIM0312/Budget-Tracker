﻿using BudgetTrackingApp.Models;
using Microsoft.Extensions.Logging;
using Syncfusion.Maui.Core.Hosting;

namespace BudgetTrackingApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureSyncfusionCore()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    
                });

            builder.Services.AddTransient<User>();
            builder.Services.AddSingleton<UserState>();


            //Hello
            //more
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
            
        }
    }
}

﻿using Microsoft.Extensions.Logging;
using MauiApp1;
using MauiApp1.Views;
using MauiApp1.ViewModels;


namespace MauiApp1;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif

		builder.Services.AddSingleton<CalculatorViewModel>();
		builder.Services.AddSingleton<MainPage>();

		return builder.Build();
	}
	
}

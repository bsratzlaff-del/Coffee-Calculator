﻿using Microsoft.Extensions.Logging;
using MauiApp1;
using MauiApp1.Views;

namespace MauiApp1.ViewModels;

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

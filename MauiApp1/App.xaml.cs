using Microsoft.Extensions.DependencyInjection;

namespace MauiApp1;

public partial class App : Application
{
	private readonly Views.MainPage _mainPage;
	public App(Views.MainPage mainPage)
	{
		InitializeComponent();
		_mainPage = mainPage;
	}

	protected override Window CreateWindow(IActivationState? activationState)
	{
		return new Window(new AppShell());
	}
}
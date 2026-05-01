using MauiApp1.ViewModels;

namespace MauiApp1.Views;

public partial class MainPage : ContentPage
{
	public MainPage(CalculatorViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}
}


using MauiApp1;

namespace MauiApp1.ViewModels;

public partial class MainPage : ContentPage
{
	public MainPage(CalculatorViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}
	private void OnEntryTextChanged(object? sender, TextChangedEventArgs e)
    {
        // 1. Get the ViewModel and the Entry that was typed in
        if (BindingContext is CalculatorViewModel vm && sender is Entry entry)
        {
            // 2. Try to turn the new text into a number
            // If the box is empty (backspaced), 'val' becomes null
            double? val = double.TryParse(e.NewTextValue, out double result) ? result : null;

            // 3. Manually push the value to the ViewModel based on the ClassId
            if (entry.ClassId == "Coffee")
            {
                if (vm.CoffeeUnits != val) vm.CoffeeUnits = val;
            }
            else if (entry.ClassId == "Water")
            {
                if (vm.WaterUnits != val) vm.WaterUnits = val;
            }
        }
    }
}



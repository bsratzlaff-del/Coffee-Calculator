using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MauiApp1.ViewModels; 
public class CalculatorViewModel : INotifyPropertyChanged
{
    private double _coffeeGrams;
    private double _waterGrams;
    private double _currentRatio = 15; //default medium ratio

    public double CoffeeGrams
    {
        get => _coffeeGrams;
        set
        {
            if (_coffeeGrams != value)
            {
                _coffeeGrams = value;
                OnPropertyChanged();

                //When the coffee changes, updates water
                _waterGrams = _coffeeGrams * _currentRatio;
                OnPropertyChanged(nameof(WaterGrams));
            }
        }
    }

    public double WaterGrams
    {
        get => _waterGrams;
        set
        {
            if (_waterGrams != value)
            {
                _waterGrams = value;
                OnPropertyChanged();

                //When the water changes, updates coffee
                _coffeeGrams = _waterGrams / _currentRatio;
                OnPropertyChanged(nameof(CoffeeGrams));
            }
        }
    }

    //event tells UI value changed, redraw the screen
    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

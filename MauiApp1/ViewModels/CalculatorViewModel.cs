using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MauiApp1.ViewModels;

public class CalculatorViewModel : INotifyPropertyChanged
{
    private double? _coffeeGrams;
    private double? _waterGrams;
    private double _currentRatio = 15; //default medium ratio

    public double CurrentRatio
    {
        get => _currentRatio;
        set
        {
            if (_currentRatio != value)
            {
                _currentRatio = value;
                OnPropertyChanged();
                WaterGrams = _coffeeGrams * _currentRatio;
            }
        }
    }

    public double? CoffeeGrams
    {
        get => _coffeeGrams;
        set
        {
            if (value == null || value <= 0)
            {
                _coffeeGrams = null;
                _waterGrams = null;
                NotifyAll();
                return;
            }

            if (_coffeeGrams != value)
            {
                _coffeeGrams = value;
                _waterGrams = _coffeeGrams * _currentRatio;
                NotifyAll();
            }
        }
    }


    public double? WaterGrams
    {
        get => _waterGrams;
        set
        {
            if (value == null || value <= 0)
            {
                _waterGrams = null;
                _coffeeGrams = null;
                NotifyAll();
                return;
            }

            if (_waterGrams != value)
            {
                _waterGrams = value;
                _coffeeGrams = _waterGrams / _currentRatio;
                NotifyAll();
            }
        }
    }

    private void NotifyAll()
    {
        OnPropertyChanged(nameof(CoffeeGrams));
        OnPropertyChanged(nameof(WaterGrams));
    }

    //event tells UI value changed, redraw the screen
    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

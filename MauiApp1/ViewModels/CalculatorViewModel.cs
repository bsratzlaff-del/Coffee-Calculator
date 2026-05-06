using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MauiApp1.ViewModels;

using MauiApp1;

public class CalculatorViewModel : INotifyPropertyChanged
{
    private double? _coffeeUnits;
    private double? _waterUnits;
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
                WaterUnits = _coffeeUnits * _currentRatio;
            }
        }
    }

    public double? CoffeeUnits
    {
        get => _coffeeUnits;
        set
        {
            if (_coffeeUnits != value)
{
                _coffeeUnits = value;
                // Tell C# "I know this isn't null, use the actual value"
                _waterUnits = _coffeeUnits.Value * _currentRatio; 
                
                FileLogger.Log($"Calculation triggered: Coffee={_coffeeUnits}, Water={_waterUnits}");
                NotifyAll();
            }

            // Inside WaterUnits setter
            if (_waterUnits != value)
            {
                _waterUnits = value;
                // Tell C# to use the value for the division
                _coffeeUnits = _waterUnits.Value / _currentRatio;
                NotifyAll();
            }
        }
    }


    public double? WaterUnits
    {
        get => _waterUnits;
        set
        {
            if (value == null || value <= 0)
            {
                _waterUnits = null;
                _coffeeUnits = null;
                NotifyAll();
                return;
            }

            if (_waterUnits != value)
            {
                _waterUnits = value;
                _coffeeUnits = _waterUnits / _currentRatio;
                NotifyAll();
            }
        }
    }

    private void NotifyAll()
    {
        OnPropertyChanged(nameof(CoffeeUnits));
        OnPropertyChanged(nameof(WaterUnits));
    }

    //event tells UI value changed, redraw the screen
    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

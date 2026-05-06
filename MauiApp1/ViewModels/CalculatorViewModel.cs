using System.ComponentModel;
using System.Runtime.CompilerServices;
using MauiApp1.Services;

namespace MauiApp1.ViewModels;



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
                
                if (_coffeeUnits is double c)
                {
                    _waterUnits = c * _currentRatio;
                    NotifyAll();
                }
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
                
                if (_coffeeUnits is double c)
                {
                    _waterUnits = c * _currentRatio;
                }
                else
                {
                    _waterUnits = null;
                }

                
                FileLogger.Log($"Calculation triggered: Coffee={_coffeeUnits}, Water={_waterUnits}");
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

                if (_waterUnits is double w)
                {
                    _coffeeUnits = w / _currentRatio;
                }
                else
                {
                    _coffeeUnits = null;
                }
                FileLogger.Log($"Water updated: {_waterUnits}. Coffee is now: {_coffeeUnits}");
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

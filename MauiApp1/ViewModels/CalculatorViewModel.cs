using System.ComponentModel;
using System.Runtime.CompilerServices;
using MauiApp1.Services;
using System.Windows.Input;

namespace MauiApp1.ViewModels;



public class CalculatorViewModel : INotifyPropertyChanged
{
    // Inside CalculatorViewModel.cs
    private double? _coffeeUnits;
    private double? _waterUnits;
    private double _currentRatio = 15; 
    public List<double> AvailableRatios { get; } = new() { 12, 15, 17, 18, 20 };

    public CalculatorViewModel()
    {
        try 
        {
            FileLogger.Log("App Session Started");
        }
        catch 
        {
            // If logging fails, don't let it crash the whole app!
            System.Diagnostics.Debug.WriteLine("Initial log failed.");
        }
    }

    public double CurrentRatio
{
    get => _currentRatio;
    set
    {
        if (_currentRatio != value)
        {
            _currentRatio = value;
            OnPropertyChanged();
            
            // Recalculate water if coffee weight is already entered
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
                    _waterUnits = Math.Round(c * _currentRatio, 1);
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
                    _coffeeUnits = Math.Round(w / _currentRatio, 1);
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
    public ICommand ResetCommand => new Command(() => 
    {
        CoffeeUnits = null;
        WaterUnits = null;
        FileLogger.Log("Inputs Reset by User");
    });

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

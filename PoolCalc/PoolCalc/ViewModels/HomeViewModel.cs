using Avalonia.Threading;
using PoolCalc.Enums;
using PoolCalc.Models;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO.Ports;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PoolCalc.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        double initialAmount = 0;
        double increase = 0;
        double max = 100;
        TimeSpan frequency = new TimeSpan(7, 0, 0, 0);
        DateTime dateStarted = DateTime.Today;
        DateTime dateFinished = DateTime.Today;
        int minValue;
        int maxValue;
        double sliderValue;
        VariableTypes variableToChange;
        VariableTypes variableToFind;
        List<VariableTypes> variableTypesToChange = AllVariableTypes;
        List<VariableTypes> variableTypesToFind = ToFindVariableTypes;

        public HomeViewModel()
        {
            sliderValue = max;
        }

        public string InitialAmount
        {
            get
            {
                return initialAmount.ToString();
            }
            set
            {
                if (int.TryParse(value, out var result))
                {
                    this.RaiseAndSetIfChanged(ref initialAmount, result);
                }
            }
        }

        public string Increase
        {
            get
            {
                return increase.ToString();
            }
            set
            {
                if (int.TryParse(value, out var result))
                {
                    this.RaiseAndSetIfChanged(ref increase, result);
                }
            }
        }

        public string Max
        {
            get
            {
                return max.ToString();
            }
            set
            {
                if (int.TryParse(value, out var result))
                {
                    this.RaiseAndSetIfChanged(ref max, result);
                }
            }
        }

        public string Frequency
        {
            get
            {
                return frequency.Days.ToString();
            }
            set
            {
                if (int.TryParse(value, out var result))
                {
                    this.RaiseAndSetIfChanged(ref frequency, new TimeSpan(result, 0, 0, 0));
                }
                OnUIUpdate();
            }
        }

        public DateTime DateStarted
        {
            get
            {
                return dateStarted;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref dateStarted, value);
            }
        }

        public DateTime DateFinished
        {
            get
            {
                return dateFinished;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref dateFinished, value);
            }
        }

        public int SliderValue
        {
            get
            {
                return (int)Math.Round(sliderValue);
            }
            set
            {
                sliderValue = value;
                setUI();
            }
        }

        public int MinValue
        {
            get
            {
                return minValue;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref minValue, value);
            }
        }

        public int MaxValue
        {
            get
            {
                return maxValue;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref maxValue, value);
            }
        }

        public VariableTypes VariableToChange
        {
            get
            {
                return variableToChange;
            }
            set
            {
                VariableTypesToChange = AllVariableTypes;
                VariableTypesToChange.Remove(value);
                VariableTypesToChange.Remove(VariableToChange);
                VariableTypesToFind = ToFindVariableTypes;
                VariableTypesToFind.Remove(value);
                VariableTypesToFind.Remove(VariableToChange);
                this.RaiseAndSetIfChanged(ref variableToChange, value);
            }
        }

        public VariableTypes VariableToFind
        {
            get
            {
                return variableToFind;
            }
            set
            {
                VariableTypesToChange = AllVariableTypes;
                VariableTypesToChange.Remove(value);
                VariableTypesToChange.Remove(VariableToChange);
                VariableTypesToFind = ToFindVariableTypes;
                VariableTypesToFind.Remove(value);
                VariableTypesToFind.Remove(VariableToChange);
                this.RaiseAndSetIfChanged(ref variableToFind, value);
            }
        }

        static List<VariableTypes> AllVariableTypes = new List<VariableTypes>() { VariableTypes.Initial, VariableTypes.Increase, VariableTypes.Max, VariableTypes.Frequency, VariableTypes.DateFinished, VariableTypes.DateStarted };
        public List<VariableTypes> VariableTypesToChange
        {
            get
            {
                return variableTypesToChange;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref variableTypesToChange, value);
            }
        }

        public List<string> types
        {
            get
            {
                return new List<string>() { "hi", "hello", "testing" };
            }
        }

        static List<VariableTypes> ToFindVariableTypes = new List<VariableTypes>() { VariableTypes.Increase, VariableTypes.Max, VariableTypes.Frequency, VariableTypes.DateFinished};
        public List<VariableTypes> VariableTypesToFind
        {
            get
            {
                return variableTypesToFind;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref variableTypesToFind, value);
            }
        }

        public void setUI()
        {
            Max = SliderValue.ToString();
            Increase = getIncrease().ToString();
        }

        public bool CanCalc()
        {
            int count = 0;
            if (string.IsNullOrWhiteSpace(Max))
            {
                count++;
            }
            else if (string.IsNullOrWhiteSpace(Increase))
            {
                count++;
            }
            else if (string.IsNullOrWhiteSpace(Frequency))
            {
                count++;
            }
            if (count == 1)
            {
                return true;
            }
            else{
                return false;
            }
        }

        public void OnUIUpdate()
        {
            if (CanCalc())
            {
                if (string.IsNullOrWhiteSpace(Max))
                {
                    Max = getEndAmount().ToString();
                }
                else if (string.IsNullOrWhiteSpace(Increase))
                {
                    Increase = getIncrease().ToString();
                }
                else if (string.IsNullOrWhiteSpace(Frequency))
                {
                    Frequency = getFrequency().ToString();
                }
            }
        }

        CalculationData getData()
        {
            return new CalculationData()
            {
                initialAmount = initialAmount,
                increase = increase,
                max = max,
                frequency = frequency,
                dateStarted = dateStarted,
                dateFinished = dateFinished
            };
        }

        double getEndAmount()
        {
            double currentAmount = initialAmount;
            var currentDate = dateStarted;
            while (currentDate < dateFinished)
            {
                currentAmount += increase;
                currentDate += frequency;
            }
            return currentAmount;
        }

        DateTime getDateFinished()
        {
            var currentAmount = initialAmount;
            var currentDate = dateStarted;
            while (max > currentAmount)
            {
                currentAmount += increase;
                currentDate += frequency;
            }
            return currentDate;
        }

        TimeSpan getFrequency()
        {
            var totalIncrease = max - initialAmount;
            var increaseAmounts = totalIncrease / increase;
            var timeAvailable = dateFinished - dateStarted;
            var frequency = timeAvailable / increaseAmounts;
            return frequency;
        }

        double getIncrease()
        {
            var timeAvailable = dateFinished - dateStarted;
            var increaseAmounts = timeAvailable / frequency;
            var totalIncrease = max - initialAmount;
            var increase = totalIncrease / increaseAmounts;
            return Math.Round(increase);
        }

    }
}

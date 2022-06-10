using CalculatorApp.DependencyClasses;
using CalculatorApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CalculatorApp.ViewModels
{
    public enum CalculatorState
    {
        PopulatingFirstNumber,
        PopulatingSecondNumber
    }

    public enum Operation
    {
        None,
        Add,
        Subtract,
        Divide,
        Multiply,
        Equal
    }

    public class CalculatorPageViewModel :  BaseViewModel
    {
        private string _displayText;
        private string _firstNumber = string.Empty;
        private string _secondNumber = string.Empty;
        private CalculatorState _state;
        private Operation _currentOperation;

        private readonly INavigationService navigationService;



        private List<string> _calculatorHistory { get; set; } = new List<string>();


      
        public CalculatorPageViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
            _state = CalculatorState.PopulatingFirstNumber;
            _currentOperation = Operation.None;
            SubscribeToMessage();
        }

        private void SubscribeToMessage()
        {
            MessagingCenter.Subscribe<HistoryPageViewModel, List<string>>(this, "Items", (vm, list) =>
               {
                   _calculatorHistory = list;

               });
        }

        public string DisplayText
        {
            get => _displayText;
            set
            {
                _displayText = value;
                OnPropertyChanged();
            }
        }

        public ICommand ClearCommand => new Command(ClearText);

        public ICommand AddCharCommand => new Command<string>(AddChar);

        public ICommand OperationCommand => new Command<Operation>(PerformOperation);

        public ICommand ShowHistoryCommand => new Command(async () => { await GoToHistoryPage(); });

        private async Task GoToHistoryPage()
        {


          
            
            //await navigationService.PushAsync<HistoryPageViewModel>(_calculatorHistory);
            await navigationService.PushAsync<InfoPageViewModel>(_calculatorHistory);
        }

        private void AddChar(string character)
        {
            if (_state == CalculatorState.PopulatingFirstNumber)
            {
                if (_firstNumber.Contains(",") && character == ",")
                {
                    return;
                }
                _firstNumber += character;
                DisplayText = _firstNumber;
                _state = CalculatorState.PopulatingSecondNumber;
                return;
            }

            if (_secondNumber.Contains(",") && character == ",")
            {
                return;
            }
            _secondNumber += character;
            DisplayText = _secondNumber;

            _state = CalculatorState.PopulatingFirstNumber;
        }

        private void ClearText()
        {
            if (_state == CalculatorState.PopulatingFirstNumber)
            {
                _firstNumber = string.Empty;
            }
            else
            {
                _secondNumber = string.Empty;
            }
            DisplayText = string.Empty;
        }

        private void PerformOperation(Operation operation)
        {
            if (operation == Operation.Equal &&
                !string.IsNullOrWhiteSpace(_firstNumber) &&
                !string.IsNullOrWhiteSpace(_secondNumber))
            {
                Calculate();
                return;
            }
            _currentOperation = operation;
            DisplayText = string.Empty;
            _state = CalculatorState.PopulatingSecondNumber;
        }

        private void Calculate()
        {
            var first = decimal.Parse(_firstNumber);
            var second = decimal.Parse(_secondNumber);
            decimal result = 0;
            switch (_currentOperation)
            {
                case Operation.Add:
                    result = first + second;
                    break;
                case Operation.Subtract:
                    result = first - second;
                    break;
                case Operation.Divide:
                    result = first / second;
                    break;
                case Operation.Multiply:
                    result = first * second;
                    break;
                default:
                    break;
            }
            DisplayText = result.ToString();

            _calculatorHistory.Add($"{_firstNumber} {GetOperationString()} {_secondNumber} = {result}");

            _currentOperation = Operation.None;
            _state = CalculatorState.PopulatingFirstNumber;
            _firstNumber = string.Empty;
            _secondNumber = string.Empty;
        }

        private object GetOperationString()
        {
            
            switch (_currentOperation)
            {
                
                case Operation.Add:
                    return "+";
                  
                case Operation.Subtract:
                    return "-";
                  
                case Operation.Divide:
                    return "/";
                  
                case Operation.Multiply:
                    return "*";
                 
                
                default:
                    return "";
                    
            }

        }
    }
}

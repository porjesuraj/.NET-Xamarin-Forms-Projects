using CalculatorApp.DependencyClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApp.Tests
{
    public class DialogMessageMock : IDialogMessage
    {
        public int DisplayAlertCallCount { get; set; }

        public async Task<string> DisplayActionSheet(string title, string destruction, params string[] buttons)
        {
            DisplayAlertCallCount++;

            return $"{DisplayAlertCallCount}";
        }

        public Task DisplayAlert(string title, string message, string cancel)
        {
            DisplayAlertCallCount++;

            return Task.CompletedTask;
        }

        public async  Task<string> DisplayPrompt(string title, string message)
        {
            DisplayAlertCallCount++;

            return  $"{DisplayAlertCallCount}";
        }
    }
}

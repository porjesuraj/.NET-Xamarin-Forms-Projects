using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalculatorApp.ViewModels;
using NUnit.Framework;
using Moq;
using CalculatorApp.DependencyClasses;

namespace CalculatorApp.Tests
{
    class DIPageViewModelTests
    {
        [Test]
        public void DispalyAlertCommand_displays_alert_on_button_pressed()
        {
            var dialogMessage = new DialogMessageMock();

            var viewModel = new DIDemoPageViewModel(dialogMessage);

            viewModel.DisplayAlertCommand.Execute(null);

            Assert.AreEqual(1, dialogMessage.DisplayAlertCallCount);
        }


        [Test]
        public void DispalyAlertCommand_displays_alert_on_button_pressed_using_moq()
        {
            var mockDialogMessage = new Mock<IDialogMessage>();

            mockDialogMessage.Setup(x => x.DisplayAlert("Hello", "Have a Great Day", "OK")).Returns(Task.CompletedTask);

            var viewModel = new DIDemoPageViewModel(mockDialogMessage.Object);

            viewModel.DisplayAlertCommand.Execute(null);

            mockDialogMessage.Verify(x => x.DisplayAlert("Hello", "Have a Great Day", "OK"), Times.Once);



        }

    }
}

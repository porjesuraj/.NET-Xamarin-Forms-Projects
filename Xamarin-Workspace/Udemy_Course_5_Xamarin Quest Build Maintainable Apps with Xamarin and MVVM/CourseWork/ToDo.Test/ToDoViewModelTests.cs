using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.ViewModels;

namespace ToDo.Test
{
  public  class ToDoViewModelTests
    {
        [Test]
        public void ViewModel_populates_ToDoItemCollection_correctly()
        {
            //Arrange

            var ViewModel = new ToDoPageViewModel();
            // Action

            Assert.AreEqual(5, ViewModel.ToDoItemCollection.Count);

            //Assert

        }


        [Test]
        public void AddItemCommand_adds_newItem_to_the_list()
        {
            //Arrange

            var ViewModel = new ToDoPageViewModel();


            //Act
            ViewModel.AddItemCommand.Execute(null);


            //Assert
            Assert.AreEqual(6, ViewModel.ToDoItemCollection.Count);

            Assert.AreEqual("ToDo Item 6", ViewModel.ToDoItemCollection.Last().Name);
        }


        [Test]
        public void MarkAsCompletedCommand_marks_item_As_completed_and_puts_it_at_the_ebd_of_list()
        {
            var viewModel = new ToDoPageViewModel();

            viewModel.MarkAsCompletedCommand.Execute(viewModel.ToDoItemCollection.First());

            Assert.True(viewModel.ToDoItemCollection.Last().IsCompleted);
        }

        [Test]
        public void MarkAsCompletedCommand_updates_progress()
        {
            var viewModel = new ToDoPageViewModel();

            viewModel.MarkAsCompletedCommand.Execute(viewModel.ToDoItemCollection.First());

            Assert.AreEqual("Completed 1 / 5", viewModel.CompletedHeader);

            Assert.AreEqual(0.2, viewModel.CompletedProgress);
        }

    }
}

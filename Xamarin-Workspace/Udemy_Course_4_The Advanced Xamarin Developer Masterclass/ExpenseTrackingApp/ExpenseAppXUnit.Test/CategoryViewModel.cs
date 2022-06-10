using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using ExpenseTrackingApp.ViewModels;
namespace ExpenseAppXUnit.Test
{
   public class CategoryViewModel
    {
        [Fact]
        public void ViewModel_populates_Categories_correctly()
        {
            CategoriesPageViewModel viewModel = new CategoriesPageViewModel();

            Assert.Empty(viewModel.Categories);

        }
        [Fact]
        public void GetCategories_adds_new_item_to_the_Categories()
        {
            CategoriesPageViewModel viewModel = new CategoriesPageViewModel();

            viewModel.GetCategories();

            Assert.Equal(7, viewModel.Categories.Count);
            Assert.Equal("Other", viewModel.Categories.Last());

        }

         [Fact] 
        public void GetExpensePerCategory_add_new_item_to_the_CategoryExpensesCollection()
        {
            CategoriesPageViewModel viewModel = new CategoriesPageViewModel();

            viewModel.GetCategories();
            viewModel.GetExpensePerCategory();

            Assert.Equal(7, viewModel.CategoryExpensesCollection.Count);
        }

    }
}

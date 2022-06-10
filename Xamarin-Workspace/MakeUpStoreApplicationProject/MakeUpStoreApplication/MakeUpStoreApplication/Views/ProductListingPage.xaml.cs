
using MakeUpStoreApplication.Common.Models;
using MakeUpStoreApplication.ViewModels;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;

namespace MakeUpStoreApplication.Views
{
    public partial class ProductListingPage : ContentPage
    {
        public ProductListingPage()
        {
            InitializeComponent();
        }

      


        private async void ProductList_SelectionChanged(object sender, System.EventArgs e)
        {
            try
            {
              
                var btn = sender as ImageButton;
                var item2 = btn.CommandParameter as MakeUp;

                int quantity = (int)await Navigation.ShowPopupAsync(new AddToCartPopup(item2));

                MakeUpProduct product = new MakeUpProduct
                {
                    ProductId = item2.Id,
                    Name = item2.Name,
                    Description = item2.Description,
                    ImageLink = item2.ImageLink,
                    Price = item2.Price,
                    Quantity = quantity,
                    Rating = item2.Rating
                };

                (BindingContext as ProductListingPageViewModel).AddToCartCommand.Execute(product);
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                
            }
           
        }
    }
}

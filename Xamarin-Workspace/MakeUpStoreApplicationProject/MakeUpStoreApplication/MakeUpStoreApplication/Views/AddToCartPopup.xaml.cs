using MakeUpStoreApplication.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MakeUpStoreApplication.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddToCartPopup : Popup
    {

        public int Quantity { get; set; } = 0;
        public Double Price { get; set; } 
        

        public MakeUp ProductDetail { get; set; }
        

        public AddToCartPopup(MakeUp product)
        {
            

            InitializeComponent();
            ProductDetail = product;

            Price =  Double.Parse(ProductDetail.Price);

            BindingContext = ProductDetail;

            
            
          
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
               Dismiss(Quantity);
        
        }

        private void Minus_Button_Clicked(object sender, EventArgs e)
        {
            if (Quantity > 0)
                --Quantity;
            else
                Quantity = 0;
            quantityLabel.Text = $"{Quantity}";

           
                Double total = Quantity * Price;
                AddButton.Text = $" $. {total}";
           
            
        }

        private void Plus_Button_Clicked(object sender, EventArgs e)
        {
            if (Quantity == 0 || Quantity > 0 )
                ++ Quantity;

            quantityLabel.Text = $"{Quantity}";

          
                double total = Quantity * Price;
                AddButton.Text = $"$. {total}";
            
        }
    }
}
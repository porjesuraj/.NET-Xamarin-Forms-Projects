using MakeUpStoreApplication.Common.Models;
using MakeUpStoreApplication.Common.SQLiteDataBase;
using Prism.AppModel;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Navigation.Xaml;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MakeUpStoreApplication.ViewModels
{
    public class ProductDetailsPageViewModel : ViewModelBase
    {

        private MakeUp productDetail;
        public MakeUp ProductDetail
        {
            get { return productDetail; }
            set { SetProperty(ref productDetail, value); }
        }

        private int quantity;
        public int Quantity
        {
            get { return quantity; }
            set { SetProperty(ref quantity, value); }
        }

        private double total;
        public double TotalAmount
        {
            get { return total; }
            set { SetProperty(ref total, value); }
        }

        public ICommand MinusButtonCommand { get; set; }
        public ICommand PlusButtonCommand { get; set; }

        public ICommand AddToCartCommand { get; set; }

        private readonly INavigationService navigationService1;

        private readonly IPageDialogService pageDialogService;
        private readonly IRepository<MakeUpProduct> repository;
        public ProductDetailsPageViewModel(INavigationService navigationService, IRepository<MakeUpProduct> repository1, IPageDialogService pageDialogueService1) : base(navigationService)
        {
            navigationService1 = navigationService;
            pageDialogService = pageDialogueService1;
            repository = repository1;
            MinusButtonCommand = new DelegateCommand(ExecuteMinus);
            PlusButtonCommand = new DelegateCommand(ExecutePlus);

            AddToCartCommand = new DelegateCommand(async () => await ExecuteAddToCart());
        }

        private async Task ExecuteAddToCart()
        {
            MakeUpProduct product = new MakeUpProduct
            {
                ProductId = ProductDetail.Id,
                Name = ProductDetail.Name,
                Description = ProductDetail.Description,
                ImageLink = ProductDetail.ImageLink,
                Price = ProductDetail.Price,
                Quantity = Quantity,
                Rating = ProductDetail.Rating
            };

            var list = (await repository.GetAllAsync()).FirstOrDefault((i) => i.ProductId == product.ProductId );
            try
            {
               if( list == null)
                {
                    int row = await repository.SaveAsync(product);
                    if (row > 0)
                    {
                        await pageDialogService.DisplayAlertAsync("Success", " Product Added to Cart", "OK");

                    }
                    else
                    {
                        await pageDialogService.DisplayAlertAsync("Error", $"message : Cant Add to Cart", "OK");

                    }
                }
                

            }
            catch (Exception ex)
            {

                await pageDialogService.DisplayAlertAsync("Error", $"message : {ex.Message}", "OK");
            }

        }

        private void ExecutePlus()
        {
            if (Quantity == 0 || Quantity > 0)
                ++Quantity;




            Double totals = Quantity * Double.Parse(ProductDetail.Price);
            TotalAmount = totals;
        }

        private void ExecuteMinus()
        {
            if (Quantity > 0)
                --Quantity;
            else
                Quantity = 0;
           


            Double totals = Quantity * Double.Parse(ProductDetail.Price);
            TotalAmount = totals;
        }

        public override void Initialize(INavigationParameters parameters)
        {


            parameters.TryGetValue<MakeUp>("product", out MakeUp product);

            if (product != null)
                ProductDetail = product;

            


        }

      
    }
}

using MakeUpStoreApplication.Common.Models;
using MakeUpStoreApplication.Common.SQLiteDataBase;
using Prism.AppModel;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Prism.Services;
namespace MakeUpStoreApplication.ViewModels
{
    public class CartPageViewModel : ViewModelBase, IPageLifecycleAware
    {
        private MakeUpProduct cartProduct;
        public MakeUpProduct CartProduct
        {
            get { return cartProduct; }
            set { SetProperty(ref cartProduct, value); }
        }

        private double totalAmount;
        public double TotalAmount
        {
            get { return totalAmount; }
            set { SetProperty(ref totalAmount, value); }
        }

        private int productTotal;
        public int ProductTotal
        {
            get { return productTotal; }
            set { SetProperty(ref productTotal, value); }
        }

        private double taxTotal;
        public double TaxTotal
        {
            get { return taxTotal; }
            set { SetProperty(ref taxTotal, value); }
        }

        
       // public ObservableCollection<MakeUpProduct> CartCollection { get; set; } = new ObservableCollection<MakeUpProduct>();

        private ObservableCollection<MakeUpProduct> cartCollection;
        public ObservableCollection<MakeUpProduct> CartCollection
        {
            get { return cartCollection; }
            set { SetProperty(ref cartCollection, value); }
        } 

        public ICommand GoBackCommand { get; set; }

        public ICommand DeleteFromCartCommand { get; set; }

        public ICommand UpdateCartCommand { get; set; }

        public ICommand PlaceOrderCommand { get; set; }

        public ICommand MinusButtonClickedCommand { get; set; }

        public ICommand PlusButtonClickedCommand { get; set; }

        private readonly IRepository<MakeUpProduct> repository;

        private readonly INavigationService navigationService1;

        private readonly IPageDialogService pageDialogService;
        public CartPageViewModel(INavigationService navigationService, IRepository<MakeUpProduct> repository1,IPageDialogService pageDialog) : base(navigationService)
        {
            repository = repository1;
            navigationService1 = navigationService;
            pageDialogService = pageDialog;

            CartCollection = new ObservableCollection<MakeUpProduct>();

            GoBackCommand = new DelegateCommand(async () => await GoBack());
            DeleteFromCartCommand = new DelegateCommand<object>(async (o) => await DeleteFromCart(o));

            UpdateCartCommand = new DelegateCommand<object>(async (o) => await UpdateCart(o));

            PlaceOrderCommand = new DelegateCommand(async () => await PlaceOrder());

            MinusButtonClickedCommand = new DelegateCommand<object>(MinusButtonClicked);

            PlusButtonClickedCommand = new DelegateCommand<object>(async (obj) => await PlusButtonClicked(obj));
        }

        private async Task  PlusButtonClicked(object obj)
        {
            var product = obj as MakeUpProduct;


            int itemIndex = -1;

            foreach (var item in CartCollection)
            {

                if(item.ProductId == product.ProductId)
                {
                    itemIndex = CartCollection.IndexOf(item);

                    product.Quantity += 1;
                }

            }

           int row = await repository.SaveAsync(product);

            if(itemIndex != -1)
            {
                CartCollection.RemoveAt(itemIndex);

                CartCollection.Insert(itemIndex, product);
            }

            CalculateTotal();

        }

        private void MinusButtonClicked(object obj)
        {
            var product = obj as MakeUpProduct;



            int itemIndex = -1;

            foreach (var item in CartCollection)
            {

                if (item.ProductId == product.ProductId)
                {
                    itemIndex = CartCollection.IndexOf(item);
                    if(product.Quantity > 0)
                     product.Quantity -= 1;
                }

            }
                 repository.SaveAsync(product);
            if (itemIndex != -1)
            {
                CartCollection.RemoveAt(itemIndex);

                CartCollection.Insert(itemIndex, product);
            }

            CalculateTotal();
        }

        private async Task PlaceOrder()
        {
            CartCollection.Clear();
            await pageDialogService.DisplayAlertAsync("Success", "Order Placed", "OK");
        }

        private async Task UpdateCart(object o)
        {
            MakeUpProduct item = o as MakeUpProduct;

            if(item != null)
                await pageDialogService.DisplayAlertAsync("Success", "Successfully Deleted product from Cart", "Ok");


           
        }

        private async Task DeleteFromCart(object o)
        {
            MakeUpProduct item = o as MakeUpProduct;


            if(item != null)
            {
                 int result = await repository.DeleteAsync(item); 

                if(result > 0)
                {
                    CartCollection.Remove(item);
                  await  pageDialogService.DisplayAlertAsync("Success","Successfully Deleted product from Cart", "Ok");
                }
            }
        }

        private async Task GoBack()
        {
            await navigationService1.GoBackAsync();
        }

        public async void OnAppearing()
        {
           await LoadData();
             CalculateTotal();
        }

        private  void CalculateTotal()
        {
            double total = 0;

            foreach (var item in CartCollection)
            {
                double price = Double.Parse(item.Price);

                int quantity = item.Quantity;

                total += price * quantity;


            }

            TaxTotal = 0.05 * total; 
              
            TotalAmount = total + TaxTotal;

        }

        public async Task LoadData()
        {
           var products = await repository.GetAllAsync();

            foreach (var item in products)
                CartCollection.Add(item);

            ProductTotal = CartCollection.Count();


        }

        public void OnDisappearing()
        {
            // Method intentionally left empty.
        }
    }
}

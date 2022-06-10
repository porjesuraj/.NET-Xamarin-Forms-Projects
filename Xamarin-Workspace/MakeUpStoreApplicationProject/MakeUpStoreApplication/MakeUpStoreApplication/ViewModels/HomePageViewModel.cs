using MakeUpStoreApplication.Common.Constants;
using MakeUpStoreApplication.Common.Models;
using MakeUpStoreApplication.Common.Services;
using Prism.AppModel;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Navigation.TabbedPages;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MakeUpStoreApplication.ViewModels
{


    public class HomePageViewModel : ViewModelBase, IPageLifecycleAware
    {

        private string selectedBrand;
        public string SelectedBrand
        {
            get { return selectedBrand; }
            set { SetProperty(ref selectedBrand, value); }
        }


        private string selectedProductType;
        public string SelectedProductType
        {
            get { return selectedProductType; }
            set { SetProperty(ref selectedProductType, value); }
        }


        private MakeUp listItem;
        public MakeUp ProductListItem
        {
            get { return listItem; }
            set { SetProperty(ref listItem, value); }
        }

        public ObservableCollection<MakeUp> CarosoulCollection { get; set; } = new ObservableCollection<MakeUp>();
        public ObservableCollection<MakeUp> NewProductCollection { get; set; } = new ObservableCollection<MakeUp>();

        public ObservableCollection<string> BrandCollection { get; set; } = new ObservableCollection<string>(Enum.GetNames(typeof(Brands)));
        public ObservableCollection<string> ProductTypeCollection { get; set; } = new ObservableCollection<string>(Enum.GetNames(typeof(ProductType)));
        private readonly IMakeUpApiService makeUpApiService;

        private readonly INavigationService navigationService1;

        private readonly IPageDialogService pageDialogService;

        public ICommand CarouselItemTapped { get; set; }

        public ICommand BrandSelectedCommand { get; set; }

        public ICommand ProductTypeSelectedCommand { get; set; }

        public ICommand ImageProductSelectedCommand { get; set; }
        public HomePageViewModel(IMakeUpApiService makeUpApiService1,INavigationService navigationService,IPageDialogService pageDialogServices):base(navigationService)
        {
            makeUpApiService = makeUpApiService1;

            navigationService1 = navigationService;

            pageDialogService = pageDialogServices;

            CarouselItemTapped = new DelegateCommand<object>(async (o) => await GoFromCarosoulToDetailsPage(o));

            BrandSelectedCommand = new DelegateCommand(async () => await GoToProductListPage());

            ProductTypeSelectedCommand = new DelegateCommand(async () => await GoToProductListPage());

            ImageProductSelectedCommand = new DelegateCommand(async () => await GoToDetailsPage());

            
        }

        private async Task GoFromCarosoulToDetailsPage(object o)
        {
            var args = o as TappedEventArgs;
            MakeUp product = args.Parameter as MakeUp;

                NavigationParameters navparams = new NavigationParameters
               {
                {"product",product},

                };
            
            await navigationService1.NavigateAsync("ProductDetailsPage", navparams);


           
        }

        private async Task GoToProductListPage()
        {
            NavigationParameters navparams = null;
            if (SelectedBrand != null)
            {
               navparams = new NavigationParameters
               {
                {"brand", SelectedBrand },

                };
            }
            if(SelectedProductType != null)
            {
                navparams = new NavigationParameters
               {
                {"productType", SelectedProductType },

                };
            }
            await navigationService1.SelectTabAsync("ProductListingPage", navparams);
          

            SelectedBrand = null;
            SelectedProductType = null;


        }

        private async Task GoToDetailsPage()
        {
             if(ProductListItem != null)
            {
                var parameters = new NavigationParameters()
            {
                {"product",ProductListItem }
            };

                await navigationService1.NavigateAsync("ProductDetailsPage", parameters);


                ProductListItem = null;

            }
        }

        public async Task LoadData()
        {
            try
            {
                string url = ApiConstant.API_BASE;

                var response = await makeUpApiService.GetAsync(url);

                if (response != null)
                {
                    foreach (var item in response)
                    {
                        CarosoulCollection.Add(item);

                    }

                    for (int i = 0; i < 5; i++)
                    {
                        NewProductCollection.Add(CarosoulCollection[i]);

                    }
                }
                
            }
            catch (Exception ex)
            {
                await pageDialogService.DisplayAlertAsync("Error", $"message : {ex.Message}", "OK");
              
            }
            
        }

        public async void OnAppearing()
        {
          await  LoadData();
        }

        public void OnDisappearing()
        {
            // Method intentionally left empty.
        }
    }
}

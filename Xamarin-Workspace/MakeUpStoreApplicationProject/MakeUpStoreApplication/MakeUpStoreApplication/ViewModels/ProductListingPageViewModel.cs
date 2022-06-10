using MakeUpStoreApplication.Common.Constants;
using MakeUpStoreApplication.Common.Models;
using MakeUpStoreApplication.Common.Services;
using MakeUpStoreApplication.Common.SQLiteDataBase;
using MakeUpStoreApplication.Views;
using Prism.AppModel;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Navigation.Xaml;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;

namespace MakeUpStoreApplication.ViewModels
{
    public class ProductListingPageViewModel : ViewModelBase
    {

        private string brand;
        public string Brand
        {
            get { return brand; }
            set { SetProperty(ref brand, value); }
        }


        private string productType;
        public string ProductType
        {
            get { return productType; }
            set { SetProperty(ref productType, value); }
        }

        private PriceFilter filter;
        public PriceFilter FilteredPrice
        {   
            get { return filter; }
            set { SetProperty(ref filter, value); }
        }

        private RatingsFilter ratingFilter;
        public RatingsFilter RatingFilter
        {
            get { return ratingFilter; }
            set { SetProperty(ref ratingFilter, value); }
        }

        private string brandFilter;
        public string BrandFilter
        {
            get { return brandFilter; }
            set { SetProperty(ref brandFilter, value); }
        }

        private string ptypeFilter;
        public string ProductTypeFilter
        {
            get { return ptypeFilter; }
            set { SetProperty(ref ptypeFilter, value); }
        }

        private MakeUp productSelected;
        public MakeUp ProductSelected
        {
            get { return productSelected; }
            set { SetProperty(ref productSelected, value); }
        }



        public ObservableCollection<MakeUp> ProductCollection { get; set; } = new ObservableCollection<MakeUp>();

        public ObservableCollection<PriceFilter> PriceFilterCollection { get; set; } = new ObservableCollection<PriceFilter>()
        {
                new PriceFilter{RangeInfo="Under $5 ",PriceLessThan=5,PriceGreaterThan=0},
                new PriceFilter{RangeInfo="$5 - $10",PriceLessThan=10,PriceGreaterThan=5},
                new PriceFilter{RangeInfo="$10 - $17",PriceLessThan=17,PriceGreaterThan=10},
                new PriceFilter{RangeInfo="Over $17",PriceLessThan=20,PriceGreaterThan=17}
        };

        public ObservableCollection<RatingsFilter> RatingsFilterCollection { get; set; } = new ObservableCollection<RatingsFilter>()
        {
            new RatingsFilter{RatingInfo="one + ",RatingGreaterThan=1},
            new RatingsFilter{RatingInfo="two + ",RatingGreaterThan=2},
            new RatingsFilter{RatingInfo="three + ",RatingGreaterThan=3},
            new RatingsFilter{RatingInfo="four + ",RatingGreaterThan=4}
        };



        public ObservableCollection<string> BrandFilterCollection { get; set; } = new ObservableCollection<string>(Enum.GetNames(typeof(Brands)));
        public ObservableCollection<string> ProductTypeFilterCollection { get; set; } = new ObservableCollection<string>(Enum.GetNames(typeof(ProductType)));


        private readonly INavigationService navigationService1;

        private readonly IMakeUpApiService makeUpApiService;
        private readonly IPageDialogService pageDialogService;

        private readonly IRepository<MakeUpProduct> repository;

        public ICommand SaveFilterCommand { get; set; }

        public ICommand ProductSelectedCommand { get; set; }

        public ICommand AddToCartCommand { get; set; }

        public ICommand GoToDetailCommand { get; set; }


        public ProductListingPageViewModel(INavigationService navigationService, IMakeUpApiService makeUpApiService1, IPageDialogService pageDialogService1,IRepository<MakeUpProduct> repository1) :base(navigationService)
        {
            navigationService1 = navigationService;
            makeUpApiService = makeUpApiService1;
            pageDialogService = pageDialogService1;

            repository = repository1;
            SaveFilterCommand = new DelegateCommand( async() => await ShowFilterResults());

            ProductSelectedCommand = new DelegateCommand<object>(async (o) => await GoToDetailsPage(o));

            AddToCartCommand = new DelegateCommand<object>(async (product) => await AddToCart(product));

            GoToDetailCommand = new DelegateCommand<object>(async (o) => await GoToDetailsPage(o));
        }

      

        private async Task AddToCart(object product)
        {
          
            try
            {
                MakeUpProduct makeUpProduct = product as MakeUpProduct;
              
               int row = await repository.SaveAsync(makeUpProduct);
                if(row > 0)
                {
                    await pageDialogService.DisplayAlertAsync("Success", " Product Added to Cart", "OK");

                }else
                {
                    await pageDialogService.DisplayAlertAsync("Error", $"message : Cant Add to Cart", "OK");

                }

            }
            catch (Exception ex)
            {

                await pageDialogService.DisplayAlertAsync("Error", $"message : {ex.Message}", "OK");
            }
            


           
        }

        private async Task GoToDetailsPage(object o)
        {
            Prism.Navigation.NavigationParameters parameters;
            if (ProductSelected != null)
            {
                parameters = new Prism.Navigation.NavigationParameters()
            {
                {"product",ProductSelected }
            };
            }else
            {
                MakeUp ProductDetail = o as MakeUp;
                parameters = new Prism.Navigation.NavigationParameters()
            {
                {"product",ProductDetail }
            };
            }
            

            await navigationService1.NavigateAsync("ProductDetailsPage", parameters);
        

            ProductSelected = null;

           
           
        }

      

        private async Task ShowFilterResults()
        {
            try
            {
                string url = ApiConstant.API_BASE;

                if (!string.IsNullOrEmpty(BrandFilter) && !string.IsNullOrEmpty(ProductTypeFilter) && RatingFilter != null && FilteredPrice != null)
                {
                    url += $"?brand={BrandFilter}&product_type={ProductType}&price_less_than={FilteredPrice.PriceLessThan}&price_greater_than={FilteredPrice.PriceGreaterThan}&rating_greater_than={RatingFilter.RatingGreaterThan}";
                }
                else
                {
                    if (!string.IsNullOrEmpty(BrandFilter) && !string.IsNullOrEmpty(ProductTypeFilter))
                    {
                        url += $"?brand={BrandFilter}&product_type={ProductType}";
                    } else
                    {

                    


                    if (!string.IsNullOrEmpty(Brand) && RatingFilter != null && FilteredPrice != null)
                    {

                        url += $"?brand={Brand}&price_less_than={FilteredPrice.PriceLessThan}&price_greater_than={FilteredPrice.PriceGreaterThan}&rating_greater_than={RatingFilter.RatingGreaterThan}";



                    } else
                    {
                        if (!string.IsNullOrEmpty(Brand))
                        {
                            url += $"?brand={Brand}";



                        }


                    }

                    if (!string.IsNullOrEmpty(BrandFilter) && RatingFilter != null && FilteredPrice != null)
                    {

                        url += $"?brand={BrandFilter}&price_less_than={FilteredPrice.PriceLessThan}&price_greater_than={FilteredPrice.PriceGreaterThan}&rating_greater_than={RatingFilter.RatingGreaterThan}";



                    } else
                    {
                        if (!string.IsNullOrEmpty(BrandFilter))
                        {
                            url += $"?brand={BrandFilter}";



                        }
                    }

                    if (!string.IsNullOrEmpty(ProductType) && RatingFilter != null && FilteredPrice != null)
                    {
                        url += $"?product_type={ProductType}&price_less_than={FilteredPrice.PriceLessThan}&price_greater_than={FilteredPrice.PriceGreaterThan}&rating_greater_than={RatingFilter.RatingGreaterThan}";


                    } else
                    {
                        if (!string.IsNullOrEmpty(ProductType))
                        {
                            url += $"?product_type={ProductType}";

                        }
                    }

                    if (!string.IsNullOrEmpty(ProductTypeFilter) && RatingFilter != null && FilteredPrice != null)
                    {
                        url += $"?product_type={ProductTypeFilter}&price_less_than={FilteredPrice.PriceLessThan}&price_greater_than={FilteredPrice.PriceGreaterThan}&rating_greater_than={RatingFilter.RatingGreaterThan}";


                    } else
                    {
                        if (!string.IsNullOrEmpty(ProductTypeFilter))
                        {
                            url += $"?product_type={ProductTypeFilter}";

                        }
                    }
                }
                }

                var response = await makeUpApiService.GetAsync(url);

                if (response != null)
                {
                    ProductCollection.Clear();
                    foreach (var item in response)
                    {
                        ProductCollection.Add(item);

                    }
                }

            }
            catch (Exception ex)
            {
                await pageDialogService.DisplayAlertAsync("Error", $"message : {ex.Message}", "OK");

            }
        }

        public async Task LoadData()
        {
            try
            {
                string url = ApiConstant.API_BASE;

                if (!string.IsNullOrEmpty(Brand) && !string.IsNullOrEmpty(ProductType))
                {
                  // Left Empty
                }
                else
                {



                    if (!string.IsNullOrEmpty(Brand))
                    {
                        url += $"?brand={Brand}";



                    }

                    if (!string.IsNullOrEmpty(ProductType))
                    {
                        url += $"?product_type={ProductType}";

                    }
                }

                var response = await makeUpApiService.GetAsync(url);

                if (response != null)
                {
                    foreach (var item in response)
                    {
                       ProductCollection.Add(item);

                    }
                }

            }
            catch (Exception ex)
            {
                await pageDialogService.DisplayAlertAsync("Error", $"message : {ex.Message}", "OK");

            }

        }

        public void OnDisappearing()
        {
            ProductCollection.Clear();
        }

     

        public async override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
           

           
            parameters.TryGetValue<string>("brand", out string brands);
            parameters.TryGetValue<string>("productType", out string producttype);

            if (!string.IsNullOrEmpty(brands))
                Brand = brands;


            if (!string.IsNullOrEmpty(  producttype))
                ProductType = producttype;

           await LoadData();


        }

        
    }
}

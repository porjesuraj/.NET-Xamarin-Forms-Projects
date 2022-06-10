using MakeUpStoreApplication.Common.Models;
using MakeUpStoreApplication.Common.Services;
using MakeUpStoreApplication.Common.SQLiteDataBase;
using MakeUpStoreApplication.ViewModels;
using MakeUpStoreApplication.Views;
using Prism;
using Prism.Ioc;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms;

namespace MakeUpStoreApplication
{
    public partial class App
    {
        public App(IPlatformInitializer initializer)
            : base(initializer)
        {
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/MainTabPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();

            containerRegistry.RegisterForNavigation<NavigationPage>();
         
            containerRegistry.RegisterForNavigation<HomePage, HomePageViewModel>();

            containerRegistry.Register<IMakeUpApiService, MakeUpApiService>();
            containerRegistry.RegisterForNavigation<ProductListingPage, ProductListingPageViewModel>();
            containerRegistry.RegisterForNavigation<ProductDetailsPage, ProductDetailsPageViewModel>();

            containerRegistry.Register<IRepository<MakeUpProduct>, Repository<MakeUpProduct>>();
            containerRegistry.RegisterForNavigation<MainTabPage, MainTabPageViewModel>();
            containerRegistry.RegisterForNavigation<CartPage, CartPageViewModel>();


            containerRegistry.RegisterForNavigation<ProfilePage, ProfilePageViewModel>();
        }
    }
}

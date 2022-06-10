using Prism;
using Prism.Ioc;
using SQLite;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms;
using XamlNavigation.Models;
using XamlNavigation.Services;
using XamlNavigation.ViewModels;
using XamlNavigation.Views;

namespace XamlNavigation
{
    public partial class App
    {
        public static Users users { get; set; }

        public static SQLiteAsyncConnection connect { get; set; } 

        public static string DatabaseLocation = string.Empty;

        
        public App(IPlatformInitializer initializer)
            : base(initializer)  
        {
        }

        

        public App(IPlatformInitializer initializer, string databaseLocation):base(initializer)
        {
            DatabaseLocation = databaseLocation;
            App.connect = new SQLiteAsyncConnection(App.DatabaseLocation);

             App.connect.CreateTableAsync<Post>();
             App.connect.CreateTableAsync<Users>();
        }



        protected override async void OnInitialized()
        {
            InitializeComponent();
            
            await NavigationService.NavigateAsync("NavigationPage/MainPage");

          
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();
            containerRegistry.RegisterForNavigation<HomePage, HomePageViewModel>();
            containerRegistry.RegisterForNavigation<HistoryPage, HistoryPageViewModel>();
            containerRegistry.RegisterForNavigation<MapPage, MapPageViewModel>();
            containerRegistry.RegisterForNavigation<ProfilePage, ProfilePageViewModel>();
            containerRegistry.RegisterForNavigation<NewTravelPage, NewTravelPageViewModel>();
            containerRegistry.RegisterForNavigation<PostDetailPage, PostDetailPageViewModel>();


            containerRegistry.RegisterSingleton<ISQLService, SQLService>();
            containerRegistry.RegisterForNavigation<EssentialMap, EssentialMapViewModel>();
            containerRegistry.RegisterForNavigation<RegisterPage, RegisterPageViewModel>();
        }

        protected override void OnSleep()
        {
            base.OnSleep();

            App.connect.CloseAsync();
        }
    }
}

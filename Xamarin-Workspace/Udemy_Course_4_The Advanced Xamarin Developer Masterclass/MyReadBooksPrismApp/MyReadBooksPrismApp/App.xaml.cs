using Prism;
using Prism.Ioc;
using Prism.Unity;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MyReadBooksPrismApp.Views;
using MyReadBooksPrismApp.ViewModels;

//[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace MyReadBooksPrismApp
{
    public partial class App : PrismApplication
    {
        public static string Databasepath;

        public App(IPlatformInitializer initializer):base(initializer)
        {

        }

        public App(IPlatformInitializer initializer,string databasePath) : base(initializer)
        {
            Databasepath = databasePath;
            NavigationService.NavigateAsync("NavigationPage/BooksPage");

        }
        protected override void OnInitialized()
        {

            InitializeComponent();

            //NavigationService.NavigateAsync("NavigationPage/BooksPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {

            // containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<BooksPage, BooksPageViewModel>();
            containerRegistry.RegisterForNavigation<BookDetailsPage, BookDetailsPageViewModel>();
            containerRegistry.RegisterForNavigation<NewBookPage, NewBookPageViewModel>();
        }

      
    }
}

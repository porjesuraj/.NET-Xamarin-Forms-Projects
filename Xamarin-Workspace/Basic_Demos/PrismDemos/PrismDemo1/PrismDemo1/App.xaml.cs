using Prism;
using Prism.Ioc;
using PrismDemo1.ViewModels;
using PrismDemo1.Views;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms;
using PrismDemo1.Dialogs;
namespace PrismDemo1
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

         //   DependencyService.Register<IPostService, PostService>();
            await NavigationService.NavigateAsync("NavigationPage/MainPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();

            containerRegistry.RegisterForNavigation<NavigationPage>();

            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();

            containerRegistry.RegisterForNavigation<PopUpDemo, PopUpDemoViewModel>();
         
            containerRegistry.RegisterForNavigation<DialogDemo, DialogDemoViewModel>();

            containerRegistry.RegisterForNavigation<PostPage,PostPageViewModel>();


            containerRegistry.RegisterDialog<PopUpDialog, PopUpDialogViewModel>();


            containerRegistry.RegisterForNavigation<RestPage1, RestPage1ViewModel>("RestPage");
        }
    }
}

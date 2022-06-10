using NewsApp.Common.Database;
using NewsApp.Common.Models;
using NewsApp.Common.Services;
using NewsApp.ViewModels;
using NewsApp.Views;
using Plugin.FirebasePushNotification;
using Prism;
using Prism.Ioc;
using System;
using Xamarin.Essentials;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms;

namespace NewsApp
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

         // await NavigationService.NavigateAsync("NavigationPage/AppShell");

            MainPage = new AppShell();
            CrossFirebasePushNotification.Current.OnTokenRefresh += Current_OnTokenRefresh;


        }

        private void Current_OnTokenRefresh(object source, FirebasePushNotificationTokenEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine($"Token : {e.Token}");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();

           /* containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<ArticleDetailsPage, ArticleDetailsPageViewModel>();



            containerRegistry.RegisterForNavigation<ArticleWebViewPage, ArticleWebViewPageViewModel>();
            containerRegistry.RegisterForNavigation<FavoriteArticlePage, FavoriteArticlePageViewModel>();*/

         containerRegistry.RegisterSingleton<IRepository<Article>, Repository<Article>>();
       //     containerRegistry.RegisterForNavigation<HomeTabbedPage, HomeTabbedPageViewModel>();

            containerRegistry.RegisterSingleton<INewsApiClient, NewsApiClient>();

          //  containerRegistry.RegisterForNavigation<AppShell, AppShellViewModel>();
        }

        protected override void OnAppLinkRequestReceived(Uri uri)
        {
            base.OnAppLinkRequestReceived(uri);

            if(uri.Host.EndsWith("xamboy.com",StringComparison.OrdinalIgnoreCase))
            {
                if(uri.Segments != null && uri.Segments.Length == 3)
                {
                    var action = uri.Segments[1].Replace("/", "");
                    var msg = uri.Segments[2];

                    switch(action)
                    {
                        case "hello" :
                            if (!string.IsNullOrEmpty(msg))
                            {
                                Device.BeginInvokeOnMainThread(async () =>
                                {
                                    await Current.MainPage.DisplayAlert("hello", msg.Replace("&", ""), "ok");

                                });
                            }

                            break;

                        default:
                           

                            Launcher.OpenAsync(uri);

                          
                            break;

                    }
                }
            }
        }
    }
}

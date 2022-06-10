using Autofac;
using moviesApp.Common.Databases;
using moviesApp.Common.Navigation;
using moviesApp.Models;
using moviesApp.Modules.Main;
using Plugin.SharedTransitions;
using System;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace moviesApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //class used for registration
            var builder = new ContainerBuilder();
            //scan and register all classes in the assembly
            var dataAccess = Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(dataAccess)
                   .AsImplementedInterfaces()
                   .AsSelf();

            builder.RegisterType<Repository<FullMovieInformation>>().As<IRepository<FullMovieInformation>>();


            //register navigation service
            SharedTransitionNavigationPage navigationPage = null;
            Func<INavigation> navigationFunc = () => {
                return navigationPage.Navigation;
            };
            builder.RegisterType<NavigationService>().As<INavigationService>()
                .WithParameter("navigation", navigationFunc)
                .SingleInstance();

            //get container
            var container = builder.Build();
            //set first page
            navigationPage = new SharedTransitionNavigationPage(container.Resolve<MainView>());
            MainPage = navigationPage;


           
        }

        protected override void OnStart()
        {
            // Method intentionally left empty.
        }

        protected override void OnSleep()
        {
            // Method intentionally left empty.
        }

        protected override void OnResume()
        {
            // Method intentionally left empty.
        }
    }
}


using Autofac;
using CalculatorApp.DependencyClasses;
using CalculatorApp.Views;
using System;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: ExportFont("MaterialIconsRegular.ttf", Alias = "Material")]
namespace CalculatorApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            #region using AutoFac

            //class used for registration
            var builder = new ContainerBuilder();
            //scan and register all classes in the assembly
            var dataAccess = Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(dataAccess)
                   .AsImplementedInterfaces()
                   .AsSelf();

            NavigationPage navigationPage = null;

            Func<INavigation> navigationFunc = () => {
                return navigationPage.Navigation;
            };

            builder.RegisterType<NavigationService>().As<INavigationService>()
                .WithParameter("navigation", navigationFunc);

            //get container
            var container = builder.Build();


            navigationPage = new NavigationPage(container.Resolve<MainPage>());
            MainPage = navigationPage;

            #endregion


            //  MainPage = new NavigationPage( new MainPage());


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

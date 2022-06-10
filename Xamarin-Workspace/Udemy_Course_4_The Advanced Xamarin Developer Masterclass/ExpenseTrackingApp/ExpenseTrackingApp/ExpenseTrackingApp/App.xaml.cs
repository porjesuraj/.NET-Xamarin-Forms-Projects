using ExpenseTrackingApp.ViewModels;
using ExpenseTrackingApp.Views;
using Prism;
using Prism.Ioc;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms;
using SQLite;
using ExpenseTrackingApp.Models;
using System.Threading.Tasks;
using ExpenseTrackingApp.Resources;

namespace ExpenseTrackingApp
{
    public partial class App
    {
        public static string DatabasePath { get; private set; }

        public static SQLiteAsyncConnection connect { get; set; }

       
        public App(IPlatformInitializer initializer,string databasePath)
          : base(initializer)
        {
            DatabasePath = databasePath;

            // CreateDb();
            App.connect = new SQLiteAsyncConnection(App.DatabasePath);

            App.connect.CreateTableAsync<Expense>();
          

        }

        public  static async Task<SQLiteAsyncConnection> CreateDb()
        {
           SQLiteAsyncConnection connection = new SQLiteAsyncConnection(DatabasePath);

            if (connection != null)
            {
              await  connection.CreateTableAsync<Expense>();
                return connection;
            }

            return null;
            

        }

        protected override async void OnInitialized()
        {
            InitializeComponent();

           // AppResources.Culture = new System.Globalization.CultureInfo("en-US");
            AppResources.Culture = new System.Globalization.CultureInfo("es");

            await NavigationService.NavigateAsync("NavigationPage/MainPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<CategoriesPage, CategoriesPageViewModel>();
            containerRegistry.RegisterForNavigation<ExpensesPage, ExpensesPageViewModel>();
            containerRegistry.RegisterForNavigation<NewExpensePage, NewExpensePageViewModel>();
            containerRegistry.RegisterForNavigation<ExpenseDetailPage, ExpenseDetailPageViewModel>();
        }

        protected override void OnSleep()
        {
            base.OnSleep();

            connect.CloseAsync();
        }
    }


}

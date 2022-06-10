using Autofac;
using CalculatorApp.ViewModels;
using CalculatorApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CalculatorApp.DependencyClasses
{
    public class NavigationService : INavigationService
    {

        private readonly Func<INavigation> _navigation;

        private readonly IComponentContext _container;

        private readonly Dictionary<Type, Type> _pageMap = new Dictionary<Type, Type>
        {
            {typeof(HistoryPageViewModel),typeof(HistoryPage) },
            {typeof(CalculatorPageViewModel),typeof(CalculatorPage) },
            {typeof(InfoPageViewModel),typeof(InfoPage) },
        };


        public NavigationService( Func<INavigation> navigation, IComponentContext container)
        {
            _navigation = navigation;

            _container = container;
                
        }


        public async Task NavigationAsync(Page page)
        {
           await Application.Current.MainPage.Navigation.PushAsync(page);
        }

        public async Task PopAsync()
        {
            await _navigation().PopAsync();
        }

        public async Task PushAsync<TViewModel>(object paramter = null) where TViewModel : BaseViewModel
        {
            var pageType = _pageMap[typeof(TViewModel)];

            Page page = _container.Resolve(pageType) as Page;

            await _navigation().PushAsync(page);

            await (page.BindingContext as BaseViewModel).InitializeAsync(paramter);

            

        }
    }
}

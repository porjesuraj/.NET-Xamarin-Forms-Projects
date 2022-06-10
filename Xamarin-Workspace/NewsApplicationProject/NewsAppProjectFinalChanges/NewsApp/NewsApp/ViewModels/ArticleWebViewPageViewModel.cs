using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NewsApp.ViewModels
{
    public class ArticleWebViewPageViewModel : ViewModelBase
    {
        private string url;
        public string Url
        {
            get { return url; }
            set { SetProperty(ref url, value); }
        }

        public ArticleWebViewPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            

        }


        public override void Initialize(INavigationParameters parameters)
        {
            base.Initialize(parameters);

            Url = parameters.GetValue<string>("url");


        }
    }
}

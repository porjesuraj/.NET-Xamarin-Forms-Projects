using NewsApp.Common.Database;
using NewsApp.Common.Models;
using Prism.AppModel;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NewsApp.ViewModels
{
    public class FavoriteArticlePageViewModel : ViewModelBase, IPageLifecycleAware
    {
        private Article selectedArticle;
        public Article SelectedArticle
        {
            get { return selectedArticle; }
            set { SetProperty(ref selectedArticle, value); }
        }

        public ObservableCollection<Article> ArticleCollection { get; set; } = new ObservableCollection<Article>();

        public ICommand ListItemSelectedCommand { get; set; }

        private readonly IPageDialogService pageDialogService;


        private readonly INavigationService navigationService1;

        public IRepository<Article> newsInfoRepository { get; set; }

        public FavoriteArticlePageViewModel(INavigationService navigationService, IPageDialogService pageDialog, IRepository<Article> repository)
            : base(navigationService)
        {
            pageDialogService = pageDialog;

            navigationService1 = navigationService;
            ListItemSelectedCommand = new DelegateCommand(async () => await GoToArticleDetialsPage());

         
            newsInfoRepository = repository;


        }


        private async Task GoToArticleDetialsPage()
        {
            try
            {
                var parameters = new NavigationParameters
            {
                {"article",SelectedArticle }
            };


                await navigationService1.NavigateAsync("ArticleDetailsPage", parameters);

                SelectedArticle = null;
            }
            catch (Exception ex)
            {

               await pageDialogService.DisplayAlertAsync("Error",$"Message : {ex}","OK");

            }

           
        }

        public  async void OnAppearing()
        {
            try
            {
                var Articles = await newsInfoRepository.GetAllAsync();


                ArticleCollection.Clear();

              
                foreach (var article in Articles)
                {
                    ArticleCollection.Add(article);


                }
            }
            catch (Exception ex)
            {

                await pageDialogService.DisplayAlertAsync("Error", $"Message : {ex}", "OK");

            }

          
        }

        public void OnDisappearing()
        {
            ArticleCollection.Clear();
        }
    }
}

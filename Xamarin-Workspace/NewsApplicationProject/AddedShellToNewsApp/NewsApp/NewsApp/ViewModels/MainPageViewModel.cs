
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Prism.Services;
using NewsApp.Common.Constants;

using System.Net;
using NewsApp.Common.Services;
using Newtonsoft.Json;

using NewsApp.Common.Models;
using Prism.AppModel;
using Xamarin.Forms;
using NewsApp.Views;

namespace NewsApp.ViewModels
{
    public class MainPageViewModel : ViewModelBase, IPageLifecycleAware
    {
        private  int listPage;
        private  int headlinePage;

        private string searchterm = "India";
        public string SearchTerm
        {
            get { return searchterm; }
            set { SetProperty(ref searchterm, value); }
        }


        private Article selectedArticle;
        public Article SelectedArticle
        {
            get { return selectedArticle; }
            set { SetProperty(ref selectedArticle, value); }
        }

        private Article headline;
        public Article HeadlineArticle
        {
            get { return headline; }
            set { SetProperty(ref headline, value); }
        }




        public ObservableCollection<Article> ArticleCollection { get; set; } = new ObservableCollection<Article>();


        public ObservableCollection<Article> HeadlineCollection { get; set; } = new ObservableCollection<Article>();

       

        public ICommand SearchArticleCommand { get; set; }

        public ICommand ListItemSelectedCommand { get; set; }

        public ICommand CarouselItemTapped { get; set; }

        public ICommand LoadMoreCommand { get; set; }

        public ICommand LoadMoreHeadlineCommand { get; set; }

        private readonly IPageDialogService pageDialogService;


        private readonly INavigationService navigationService1;

        private readonly INewsApiClient ApiClient;

        public MainPageViewModel(INavigationService navigationService, IPageDialogService pageDialog,INewsApiClient newsApiClient)
            : base(navigationService)
        {
            

            pageDialogService = pageDialog;

            navigationService1 = navigationService;

            ApiClient = newsApiClient;

            SearchArticleCommand = new DelegateCommand( GetData);

            ListItemSelectedCommand = new DelegateCommand(async () => await GoToArticleDetialsPage());
            CarouselItemTapped = new DelegateCommand(async () => await GoToWebPage());

            LoadMoreCommand = new DelegateCommand(GetData);

            LoadMoreHeadlineCommand = new DelegateCommand(GetHeadlines);

            GetHeadlines();

            GetData();

        }



        private async Task GoToWebPage()
        {
            try
            {
               var parameters = new NavigationParameters
            {
                {"article",HeadlineArticle}
            };


                await navigationService1.NavigateAsync("ArticleDetailsPage", parameters);
               // await Shell.Current.GoToAsync(nameof(ArticleDetailsPage));
            }
            catch (Exception ex)
            {

               await pageDialogService.DisplayAlertAsync("Error",$"Message : {ex}","OK");
            }
           
        }

        private async Task GoToArticleDetialsPage()
        {
            try
            {
               var parameters = new NavigationParameters
            {
                {"article",SelectedArticle }
            };
                string title = SelectedArticle.Title;
                string source = SelectedArticle.Source.Name;
                string description = SelectedArticle.Description;
                string urlToImage = SelectedArticle.UrlToImage;
                string url = SelectedArticle.Url;

                string published = SelectedArticle.PublishedAt.ToString();



               //await navigationService1.NavigateAsync("ArticleDetailsPage", parameters);
                await Shell.Current.GoToAsync($"articledetails?title={title}&source={source}&description={description}&urlToImage={urlToImage}&url={url}&published={published}");

                SelectedArticle = null;
            }
            catch (Exception ex)
            {

               await pageDialogService.DisplayAlertAsync("Error",$"Message : {ex}","OK");

            }


        }


        private void GetHeadlines()
        {
            headlinePage += 1;
            try
            {

              var response =  ApiClient.GetTopHeadlines(new TopHeadlinesRequest
                {
                    Country = Countries.US,
                    Category = Categories.Business,
                    Language = Languages.EN,
                    Page=headlinePage,
                    PageSize = 5
                    
                });

                if(response != null)
                {
                   

                   
                    foreach (var article in response.Articles)
                    {
                        HeadlineCollection.Add(article);


                    }
                }
           
            }
            catch (Exception ex)
            {

                pageDialogService.DisplayAlertAsync("Error", $"Message : {ex}", "OK");

            }


        }

       

        public void GetData()
        {
            listPage += 1;

            try
            {
              var response =  ApiClient.GetEverything(new EverythingRequest
                {
                    Q=SearchTerm,
                    SortBy=SortBys.Popularity,
                    Language=Languages.EN,
                    Page=listPage,
                    PageSize=5

                });

                if(response != null)
                {
                   



                    // here's the first 20
                    foreach (var article in response.Articles)
                    {
                        ArticleCollection.Add(article);


                    }

                }


            }
            catch (Exception ex)
            {

                 pageDialogService.DisplayAlertAsync("Error", $"Message : {ex}", "OK");
            }

        }



            public void OnAppearing()
        {

           // GetData();
           
        }

        public void OnDisappearing()
        {
            ArticleCollection.Clear();
      
            
        }
    }
}

using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Services;
using Prism.Navigation;
using NewsApp.Common.Models;
using System.Windows.Input;
using Xamarin.Forms;
using System.Threading.Tasks;
using NewsApp.Common.Database;
using Xamarin.Essentials;
using System.IO;
using System.Net;

namespace NewsApp.ViewModels
{
    public class ArticleDetailsPageViewModel : ViewModelBase
    {
        private readonly INavigationService navigationService1;

        private readonly IPageDialogService pageDialogService;

        private string url;
        public string UrlToImage
        {
            get { return url; }
            set { SetProperty(ref url, value); }
        }


        private Article articleDetails;
        public Article ArticleDetails
        {
            get { return articleDetails; }
            set { SetProperty(ref articleDetails, value); }
        }

        private bool isfavorite ;
        public bool IsFavorite
        {
            get { return isfavorite; }
            set { SetProperty(ref isfavorite, value); }
        }


        private bool isspeech;
        public bool IsSpeechOn
        {
            get { return isspeech; }
            set { SetProperty(ref isspeech, value); }
        }

        public ICommand ShareUrlCommand { get; set; }

        public ICommand FavoriteCommand { get; set; }

        public IRepository<Article> NewsInfoRepository { get; set; }


        public ICommand GoToWebCommand { get; set; }

        public ICommand SpeakNowCommand { get; set; }

        public ArticleDetailsPageViewModel(INavigationService navigationService, IPageDialogService pageDialog,IRepository<Article> repository) :base(navigationService)
        {
            FavoriteCommand = new Command(async () => await SetMovieAsFavorite());

          
            NewsInfoRepository =repository;

            pageDialogService = pageDialog;

            navigationService1 = navigationService;

            GoToWebCommand = new DelegateCommand(async () => await GoToWebPage());

            ShareUrlCommand = new DelegateCommand(async() => await ShareFromApp());

            SpeakNowCommand = new DelegateCommand(async () => await SpeakNow());
        }

        private async Task SpeakNow()
        {
            try
            {
                IsSpeechOn = !IsSpeechOn;



                var settings = new SpeechOptions()
                {
                    Volume = .75f,
                    Pitch = 1.0f

                };

                await TextToSpeech.SpeakAsync(ArticleDetails.Description, settings);

                IsSpeechOn = !IsSpeechOn;
            }
            catch (Exception ex)
            {

             await   pageDialogService.DisplayAlertAsync("Sorry ", $"This Feature Doesnt Work on Android Simulator as {ex.Message}", "OK");
            }

           

        }

        private async Task ShareFromApp()
        {

            try
            {
                await Share.RequestAsync(new ShareTextRequest
                {
                    Uri = ArticleDetails.Url,
                    Title = "Share Web Link",
                    Subject = "Send Web Link"

                });
            }
            catch (Exception ex)
            {

                await pageDialogService.DisplayAlertAsync("Error", $"Message : {ex}", "OK");

            }





        }

        private async Task GoToWebPage()
        {
            try
            {
                var parameter = new NavigationParameters
           {
               {"url",ArticleDetails.Url }
           };

                await navigationService1.NavigateAsync("ArticleWebViewPage", parameter);
            }
            catch (Exception ex)
            {

                await pageDialogService.DisplayAlertAsync("Error", $"Message : {ex}", "OK");

            }

            
        }

        private async Task SetMovieAsFavorite()
        {
            try
            {
                IsFavorite = !IsFavorite;

                ArticleDetails.IsFavorite = IsFavorite;



                if (ArticleDetails.IsFavorite)
                {
                    int row = await NewsInfoRepository.SaveAsync(ArticleDetails);

                    if (row > 0)
                    {
                        await pageDialogService.DisplayAlertAsync("Success", "Article saved to Database", "OK");
                    }
                    else
                    {
                        await pageDialogService.DisplayAlertAsync("Error", "Article Could not be saved", "OK");
                    }
                }
            }
            catch (Exception ex)
            {

                await pageDialogService.DisplayAlertAsync("Error", $"Message : {ex}", "OK");

            }

           

            
              

        }

        public override async void Initialize(INavigationParameters parameters)
        {
            try
            {
                base.Initialize(parameters);

                ArticleDetails = parameters.GetValue<Article>("article");



                var dbinfo = (await NewsInfoRepository.GetAllAsync()).FirstOrDefault(x => x.Title == ArticleDetails.Title);

                if (dbinfo != null)
                {
                    ArticleDetails.Id = dbinfo.Id;



                    IsFavorite = dbinfo.IsFavorite;

                }
            }
            catch (Exception ex)
            {

               await pageDialogService.DisplayAlertAsync("Error",$"Message : {ex}","OK");

            }




        }
    }
}

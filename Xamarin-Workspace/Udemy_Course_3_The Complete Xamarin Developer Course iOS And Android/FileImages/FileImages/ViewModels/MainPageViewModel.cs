using Plugin.Media;
using Plugin.Media.Abstractions;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace FileImages.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        #region Property

        private Xamarin.Forms.ImageSource selectedImageSource;

        public Xamarin.Forms.ImageSource SelectedImageSource { get => selectedImageSource; set => SetProperty(ref selectedImageSource, value); }
        #endregion

        public IPageDialogService pageDialogService { get; private set; }

        public DelegateCommand SelectImageCommand { get; set; }

        public MainPageViewModel(INavigationService navigationService, IPageDialogService PageDialogService)
            : base(navigationService)
        {
            Title = "Main Page";

            pageDialogService = PageDialogService;

            SelectImageCommand = new DelegateCommand(ExecuteSelectImage);
        }

        private async void ExecuteSelectImage()
        {
            await CrossMedia.Current.Initialize();
            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await pageDialogService.DisplayAlertAsync("Error", "This is not supported on your device", "OK");
                return;
            }

            var mediaOptions = new PickMediaOptions()
            {
                PhotoSize = PhotoSize.Medium,


            };

            var selectedImageFile = await CrossMedia.Current.PickPhotoAsync(mediaOptions);

            if (selectedImageFile == null)
            {
                await pageDialogService.DisplayAlertAsync("Error", "There was an error when trying to select your image", "OK");
                return;
            }

            SelectedImageSource = ImageSource.FromStream(() => selectedImageFile.GetStream());

        }


    }
}

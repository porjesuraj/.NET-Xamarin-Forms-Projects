using AzureBotApp.ViewModels;
using Xamarin.Forms;

namespace AzureBotApp.Views
{
    public partial class CustomBotPage : ContentPage
    {

       // CustomBotPageViewModel viewModel;

        public CustomBotPage()
        {
            InitializeComponent();


          //      viewModel = Resources["cvm"] as CustomBotPageViewModel;

          //  viewModel.MessagesChat.CollectionChanged += MessagesChat_CollectionChanged;
        }



        protected override void OnAppearing()
        {
            base.OnAppearing();
          
        }





       /* private void MessagesChat_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            try
            {
                var newMessage = viewModel.MessagesChat[viewModel.MessagesChat.Count - 1];
                Device.BeginInvokeOnMainThread(() =>
                {
                    chatListView.ScrollTo(newMessage, ScrollToPosition.End, true);

                });
            }
            catch (System.Exception)
            {

                throw;
            }

           
        }*/
  
    
    }




}

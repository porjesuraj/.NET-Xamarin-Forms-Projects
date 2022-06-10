using AzureBotApp.ViewModels.Helper;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace AzureBotApp.ViewModels
{
    public class CustomBotPageViewModel : BindableBase
    {
        BotServerHelper botHelper;

        public ICommand ScrollListCommand { get; set; }

        private string message;
        public string Message
        {
            get { return message; }
            set { SetProperty(ref message, value); }
        }


        public ObservableCollection<ChatMessage> MessagesChat { get; set; }

        public ICommand SendCommand { get; set; }

        public CustomBotPageViewModel()
        {
            botHelper = new BotServerHelper();

            SendCommand = new Command(SendActivity);

            MessagesChat = new ObservableCollection<ChatMessage>();

            botHelper.MessageRecieved += BotHelper_MessageRecieved;

            ScrollListCommand = new DelegateCommand<object>(ScrollListAction, CanScrollListAction);
        }

        private void ScrollListAction(object obj)
        {
            var list = (obj as ListView);

            if(MessagesChat.Count > 0)
            {
                var newMessage = MessagesChat[MessagesChat.Count - 1];

                list.ScrollTo(newMessage, ScrollToPosition.End, true);

            }
           
        }

        private bool CanScrollListAction(object arg)
        {
            return arg != null;
        }

        private void BotHelper_MessageRecieved(object sender, BotServerHelper.BotResponseEventArgs e)
        {
            
            foreach(var activity in e.Activities)
            {
                if(activity.From.Id != "user1")
                {
                    MessagesChat.Add(new ChatMessage
                    {
                        Text = activity.Text,
                        IsIncoming = true
                    });

                }

            }
        }

        private void SendActivity()
        {
            MessagesChat.Add(new ChatMessage
            {
                Text = Message,
                IsIncoming = false

            });


            botHelper.SendActivity(Message) ;

            Message = string.Empty;
        }


        public class ChatMessage
        {
            public string Id { get; set; }

            public string Text { get; set; }

            public bool IsIncoming { get; set; }
        

        }
    }
}

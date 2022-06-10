using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
namespace AzureBotApp.ViewModels.Helper
{
    public class BotServerHelper
    {
        public Conversation _Conversations { get; set; }

        public event EventHandler<BotResponseEventArgs> MessageRecieved;

        public BotServerHelper()
        {
            CreateConversation();

        }

        private async void CreateConversation()
        {
            //string endpoint = "https://xamrinbothandle.azurewebsites.net/api/messages";
            string endpoint = "/v3/directline/conversations";

            using(HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://directline.botframework.com");
                client.DefaultRequestHeaders.Add("Authorization","Bearer 3eAONPhg5S8.S3ytHXBkrpOnAkKhayx26CkqQ2dRLOyGXXWo1Ety7aQ");

              var response =   await client.PostAsync(endpoint, null);

                string json = await response.Content.ReadAsStringAsync();

                _Conversations = JsonConvert.DeserializeObject<Conversation>(json);

            }

            ReadMessage();

             
        }

       public async void SendActivity(string message)
        {
            string endpoint = $"/v3/directline/conversations/{_Conversations.ConversationId}/activities";

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://directline.botframework.com");
                client.DefaultRequestHeaders.Add("Authorization", "Bearer 3eAONPhg5S8.S3ytHXBkrpOnAkKhayx26CkqQ2dRLOyGXXWo1Ety7aQ");

                Activity activity = new Activity
                {
                    From = new ChannelAccount
                    {
                        Id = "user1"
                    },
                    Text = message,
                    Type = "message"

                };

                string jsonContent = JsonConvert.SerializeObject(activity);

                var buffer = Encoding.UTF8.GetBytes(jsonContent);

                var byteContant = new ByteArrayContent(buffer);

                byteContant.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

                var response = await client.PostAsync(endpoint, byteContant);

                string json = await response.Content.ReadAsStringAsync();

                var obj = JObject.Parse(json);

                string id = (string)obj.SelectToken("id");


            }

        }


        public async void ReadMessage()
        {
            var client = new ClientWebSocket();

            var cts = new CancellationTokenSource();

            await client.ConnectAsync(new Uri(_Conversations.StreamUrl), cts.Token);

            await Task.Factory.StartNew( async () =>
            {
                while(true)
                {
                    WebSocketReceiveResult result;

                    var message = new ArraySegment<byte>(new byte[4096]);

                    do
                    {
                        result = await client.ReceiveAsync(message, cts.Token);

                        if (result.MessageType != WebSocketMessageType.Text)
                            break;

                        var messageBytes = message.Skip(message.Offset).Take(result.Count).ToArray();

                        string messageJson = Encoding.UTF8.GetString(messageBytes);

                        BotsResponse botsResponse = JsonConvert.DeserializeObject<BotsResponse>(messageJson);

                        var args = new BotResponseEventArgs();

                        args.Activities = botsResponse.Activities;

                        MessageRecieved?.Invoke(this, args);

                    } while (!result.EndOfMessage);
                }

            }, cts.Token, TaskCreationOptions.LongRunning,TaskScheduler.Default);


        }


        public class BotResponseEventArgs: EventArgs
        {
            public List<Activity> Activities { get; set; }
        }


        public class BotsResponse
        {
            public string Watermark { get; set; }

            public List<Activity> Activities { get; set; }


        }

        public class ChannelAccount
        {
            public string Id { get; set; }

            public string Name { get; set; }
        }

        public class Activity
        {
            public ChannelAccount From { get; set; }

            public string Text { get; set; }

            public string Type { get; set; }

        }

        public  class Conversation
        {

            public string ConversationId { get; set; }

            public string Token { get; set; }

            public string StreamUrl { get; set; }

            public string ReferenceGrammarId { get; set; }

            public int Expires_in { get; set; }



        }


    }

  


}

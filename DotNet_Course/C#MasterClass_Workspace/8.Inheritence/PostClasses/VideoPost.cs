using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace _8.Inheritence.PostClasses
{
    class VideoPost : Post
    {

        // member field
        protected bool isPlaying = false;

        protected int currDuration = 0;

        public string VideoUrl { get; set; }

        public int  Length { get; set; }

        public TimeSpan VideoLength { get; set; }

        private Timer videoTimer { get; set; } = new Timer();

        public System.Threading.Timer timer { get; set; }
        private TimeSpan PlayingTime { get; set; }

        private TimeSpan StopTime { get; set; }


        public VideoPost(string videoUrl, TimeSpan videoLength, string title, string sendByUserName, bool isPublic) : base(title, sendByUserName, isPublic)
        {
            VideoUrl = videoUrl;
            VideoLength = videoLength;
        }

        public VideoPost(string videoUrl, int length, string title, string sendByUserName, bool isPublic) : base(title, sendByUserName, isPublic)
        {
            VideoUrl = videoUrl;
            Length = length;
        }



        public override string ToString()
        {
            return base.ToString() + $"Video Url : {VideoUrl} , Video Length : {VideoLength}";
        }


        public void Play2()
        {
            
            if(!isPlaying)
            {
                isPlaying = true;
                Console.WriteLine("Playing");

                timer = new System.Threading.Timer(TimerCallBack, null, 0, 1000);
            }
          

        }

        private void TimerCallBack(object o)
        {
            if(currDuration < Length)
            {
                currDuration++;
                Console.WriteLine("Video at {0} s.",currDuration);
                GC.Collect();
            }else
            {
                Stop2();
            }
        }

        public void Stop2()
        {
            if(isPlaying)
            {
                isPlaying = false;
                Console.WriteLine("Stopped at {0}", currDuration);
                currDuration = 0;
                timer.Dispose();
            }
          
        }


        #region tried solving Assignment 
        public void Play()
        {

            videoTimer.Elapsed += new ElapsedEventHandler(VideoTimer_Elapsed);
            videoTimer.Interval = 5000;
            videoTimer.Enabled = true;
            PlayingTime = VideoLength;
        }

        private void VideoTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            TimeSpan delta = new TimeSpan(0, 0, 5);

            PlayingTime = PlayingTime - delta;

            Console.WriteLine("Video time elapsed is {0}", PlayingTime);

        }

        public void Stop()
        {
            videoTimer.Elapsed -= VideoTimer_Elapsed;

            Console.WriteLine("Video time remaining is {0} ", PlayingTime);
        }
        #endregion



    }
}

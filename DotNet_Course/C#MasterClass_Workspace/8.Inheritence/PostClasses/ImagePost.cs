using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8.Inheritence.PostClasses
{
    class ImagePost :Post
    {
        

        public string ImageUrl { get; set; }

        public ImagePost()
        {

        }
        public ImagePost(string title, string sendByUserName, bool isPublic,string imageUrl) : base(title, sendByUserName, isPublic)
        {
            ImageUrl = imageUrl;
        }

        public override string ToString()
        {
            return base.ToString() + $" , image url = {ImageUrl}";
        }
    }

}

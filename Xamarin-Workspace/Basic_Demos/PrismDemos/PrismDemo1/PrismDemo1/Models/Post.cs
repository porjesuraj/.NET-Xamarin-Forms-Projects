using System;
using System.Collections.Generic;
using System.Text;

namespace PrismDemo1.Models
{
    public class Post
    {
        public int id { get; set; }

        public string title { get; set; }

        public string body { get; set; }

        public Post(Post p)
        {
            id = p.id;
            title = p.title;
            body = p.body;

        }
        public Post()
        {

        }
    }
}

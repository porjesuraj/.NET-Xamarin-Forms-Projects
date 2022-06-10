using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8.Inheritence.PostClasses
{
    class Post
    {
        private static int currentPostId;

        // properties
        protected int Id { get; set; }

        protected string Title { get; set; }

        protected string SendByUserName { get; set; }

        protected bool IsPublic { get; set; }

        // default constructor
        public Post()
        {
            Id = 0;
            Title = "My First Post";
            IsPublic = true;
            SendByUserName = "Suraj Porje";
        }

        // instance constructor
        public Post(string title, string sendByUserName, bool isPublic)
        {
            Id = GetNextId();
            Title = title;
            SendByUserName = sendByUserName;
            IsPublic = isPublic;
        }

        protected int GetNextId()
        {
            return ++currentPostId;
        }

        public void Update(string title,bool isPublic)
        {
            Title = title;
            IsPublic = isPublic;
        }

        public override string ToString()
        {
            return String.Format("{0} - {1} - by {2}",Id,Title,SendByUserName);
        }




    }
}

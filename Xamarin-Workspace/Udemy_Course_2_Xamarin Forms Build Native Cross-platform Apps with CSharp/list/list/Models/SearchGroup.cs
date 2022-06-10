using System;
using System.Collections.Generic;
using System.Text;

namespace list.Models
{
    class SearchGroup : List<Search>
    {
        public string Title { get; set; }
        public string ShortTitle { get; set; }

        public SearchGroup(string title,List<Search> searches) :base(searches)
        {
            Title = title;
          //  ShortTitle = shortTitle;
        }

        public  void RemoveListItem (Search s)
        {
            base.Remove(s); 
        }
    }
}

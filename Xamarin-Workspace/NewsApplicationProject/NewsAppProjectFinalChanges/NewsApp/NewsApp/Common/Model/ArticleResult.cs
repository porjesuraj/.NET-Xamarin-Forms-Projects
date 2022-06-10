using System;
using System.Collections.Generic;
using System.Text;

namespace NewsApp.Common.Model
{
    class ArticleResult
    {
        
            public string Status { get; set; }
            public int TotalResults { get; set; }
            public List<Article> Articles { get; set; }
        
    }
}

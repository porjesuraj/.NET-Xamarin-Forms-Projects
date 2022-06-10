using PrismDemo1.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace PrismDemo1.ViewModels
{
   public interface IPostService
    {
        Task<ObservableCollection<Post>> getPosts();
    }
}

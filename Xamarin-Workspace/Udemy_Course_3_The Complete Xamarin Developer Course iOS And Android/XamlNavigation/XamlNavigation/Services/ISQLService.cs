using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using XamlNavigation.Models;

namespace XamlNavigation.Services
{
   public interface ISQLService
    {
      SQLiteAsyncConnection GetConnection();

        Task<List<Post>> LoadData(SQLiteAsyncConnection conn);

        Task<int> DeletePost(SQLiteAsyncConnection conn, Post p);


       
    }
}

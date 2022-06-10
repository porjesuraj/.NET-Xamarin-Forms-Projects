using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using XamlNavigation.Models;

namespace XamlNavigation.Services
{
    public class SQLService : ISQLService
    {
        public static SQLiteAsyncConnection connection { get; private set; }

        public async Task<int> DeletePost(SQLiteAsyncConnection conn, Post p)
        {
            //conn = this.GetConnection();


            return await conn.DeleteAsync(p);
        }

        public  SQLiteAsyncConnection GetConnection()
        {
            if(connection == null)
            return new SQLiteAsyncConnection(App.DatabaseLocation);

            return connection;
        }

        public async Task<List<Post>> LoadData(SQLiteAsyncConnection conn)
        {
            await conn.CreateTableAsync<Post>();

            var posts = await conn.Table<Post>().ToListAsync();

            return new List<Post>(posts);
        }
    }
}

using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace XamlNavigation.Models
{
   public class Users
    {
        [PrimaryKey, AutoIncrement]
        public int  Id { get; set; }
        [MaxLength(250)]
        public string Email { get; set; }
        [MaxLength(250)]
        public string Password { get; set; }

        public static async Task<Users> GetUser(string Email)
        {
           return await (App.connect.Table<Users>().Where(u => u.Email == Email).FirstOrDefaultAsync());
        }

        public static async Task<int> Insert(Users user)
        {
            return await App.connect.InsertAsync(user);
        }
    }
}

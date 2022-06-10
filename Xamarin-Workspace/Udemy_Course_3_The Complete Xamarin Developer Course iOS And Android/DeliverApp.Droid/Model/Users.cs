using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;
using System.Threading.Tasks;

namespace DeliverApp.Droid.Model
{
   public class Users
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(300)]
        public string Email { get; set; }
        [MaxLength(300)]
        public string Password { get; set; }


        public static async Task<bool> Register(string email,string password,string confirmPassword)
        {

            try
            {
                if (!String.IsNullOrEmpty(email) && !String.IsNullOrEmpty(password))
                {
                    if (password == confirmPassword)
                    {
                        Users u = new Users
                        {
                            Email = email,
                            Password = password
                        };

                       // int row = await MainActivity.connect.InsertAsync(u);

                        bool row = await Constants.DataBase.Insert(u);

                        if (row)
                        {
                            return true;
                        }
                        else
                        {
                            
                            return false;

                        }
                    }
                    else
                    {
                       
                        return false;
                    }
                }
                else
                {
                    
                    return false;
                }
            }
            catch (Exception)
            {

                return false; 
            }
        }
   
        public static async Task<bool> Login(string loginEmail,string loginPassword)
        {
            if (string.IsNullOrEmpty(loginEmail) || string.IsNullOrEmpty(loginPassword))
            {
                return false;
            }
            else
            {
                var user = await MainActivity.connect.Table<Users>().Where(u => u.Email == loginEmail && u.Password == loginPassword).FirstOrDefaultAsync();

                if (user != null)
                {
                    System.Console.WriteLine("Login successful");
                    return true;

                   
                }
                else
                {
                    System.Console.WriteLine("Login Failed");
                    return false;

                   
                }
            }
        }
    }
}
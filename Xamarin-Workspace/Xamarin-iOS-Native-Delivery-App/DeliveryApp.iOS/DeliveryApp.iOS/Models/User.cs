using System;
using System.Threading.Tasks;
using SQLite;
namespace DeliveryApp.iOS.Models
{
   
    public class User
    {

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(300)]
        public string Email { get; set; }

        [MaxLength(300)]
        public string  Password { get; set; }



        public User()
        {
        }

        internal async static Task<bool> Register(string email, string password, string confirmPassword)
        {

            if(!string.IsNullOrEmpty(email))
            {
                if (password == confirmPassword)
                {

                    var user = new User
                    {
                        Email = email,
                        Password = password
                    };

                 int row =   await AppDelegate.connect.InsertAsync(user);

                    if (row > 0)
                        return true;
                    else
                        return false;

                }
                else
                    return false;
            }else
            {
                return false;
            }
        }

        internal async static Task<bool> Login(string email, string password)
        {

            if(string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                return false;
            }else
            {

                var user = await AppDelegate.connect.Table<User>().Where(u => u.Email == email && u.Password == password).FirstOrDefaultAsync();

                if (user != null)
                    return true;
                else
                    return false;

            }
        }
    }
}

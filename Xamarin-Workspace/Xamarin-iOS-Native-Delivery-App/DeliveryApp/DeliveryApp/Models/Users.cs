using System;
using SQLite;
namespace DeliveryApp.Models
{
    public class Users
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }

        [MaxLength(300)]
        public string Email { get; set; }

        [MaxLength(300)]
        public string Password { get; set; }


        public Users()
        {
        }
    }
}

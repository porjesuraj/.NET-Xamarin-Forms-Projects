using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace _7.Debugging
{
    class Program
    {
        static void Main(string[] args)
        {

            var friends = new List<string>
            {
                "jane",
                "joe",
                "Andy",
                "Maria",
                "Angelina",
                "Scooby",
                "rav",
                "dov",
                "Kakarot"
            };

            var partyFriends = GetPartyFriends(friends,12);
            foreach (var name in partyFriends)
            {
                Console.WriteLine(name);

            }
            Console.ReadLine();
        }

        private static List<string> GetPartyFriends(List<string> lists, int count)
        {
            if (lists == null)
                throw new ArgumentNullException("lists", "list is set to null");

            if (count > lists.Count || count <= 0)
            {
                MessageBox.Show("Error Message", "Error");

                throw new ArgumentOutOfRangeException("count", "Count cannot be greater than element in the list or less than zero");

            }




            var partyFriends = new List<string>();
            var buffer = new List<string>(lists);

            while (partyFriends.Count < count)
            {
               
                var currentFriend = GetPartyFriend(buffer);
                partyFriends.Add(currentFriend);
                buffer.Remove(currentFriend);
            }
            return partyFriends;
        }

        /// <summary>
        /// we decide  who are party friends here
        /// </summary>
        /// <param name="lists"></param>
        /// <returns></returns>
        private static string GetPartyFriend(List<string> lists)
        {
            string shortestName = lists[0];
            for (int i = 0; i < lists.Count; i++)
            {
                if(lists[i].Length < shortestName.Length)
                {
                    shortestName = lists[i]; 

                }

                

            }
            return shortestName;

        }
    }
}

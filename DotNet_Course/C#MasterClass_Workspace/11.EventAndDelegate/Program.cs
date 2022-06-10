using _11.EventAndDelegate.MultiCastDelegate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.EventAndDelegate
{
    class Program
    {
        /* #region Event and Delegate 1: 
        static void Main(string[] args)
         {

             Console.ReadLine();
         }
         #endregion
         */

        #region Event and Delegate 1: Basics
        static void Main1(string[] args)
        {
            List<string> names = new List<string>() { "suraj", "raj", "elon", "steve jobs" };

            foreach (string name in names)
            {
                Console.Write(name + " ");
            }
            Console.WriteLine();

            // calling RemoveAll and passsing a method Filter we created
            names.RemoveAll(FilterMethod);
            Console.WriteLine("---- after ----");
            foreach (string name in names)
            {
                Console.Write(name + " ");
            }
            Console.WriteLine();

            Console.ReadLine();
        }

        static bool FilterMethod(string name)
        {
            return name.Contains("o");
        }
        #endregion
        #region Event and Delegate 2:Creating new Delegate and Anonymous Methods

      

        //defining a delegate type Filter with return type bool and Person as method argument
        public delegate bool FilterPersonDelegate(Person P);
        static void Main2(string[] args)
        {
            List<Person> people = new List<Person>
            {
                new Person{Name="Suraj",Age=27},
                new Person{Name="raj",Age=12},
                new Person{Name="Suj",Age=17},
                new Person{Name="RajKumar",Age=26},
                new Person{Name="Kumar",Age=66},
            };
         
          
            DisplayPeople("Kids", people,IsMinor);
            DisplayPeople("Adult", people,IsAdult);
            DisplayPeople("Senior", people,IsSenior);

            // creating anonymous method and assigning to delegate.
            FilterPersonDelegate filter = delegate (Person p)
            {
                return p.Age >= 18 && p.Age <= 65;
            };
            Console.WriteLine("using anonymous method");

            DisplayPeople("Adults anonymous ", people, filter);

            DisplayPeople("All : ",people, delegate(Person p) {
                return true;});
            Console.ReadLine();
        }

        private static void DisplayPeople(string title, List<Person> people, FilterPersonDelegate filter)
        {
            Console.WriteLine(title);

            foreach (Person person in people)
            {
                if(filter(person))
                {
                    Console.WriteLine($"{person.Name}, {person.Age} years old");
                }

            }
        }

        static bool IsMinor(Person p)
        {
            return p.Age < 18;
        }

        static bool IsAdult(Person p)
        {
            return p.Age > 18 ;
        }
        static bool IsSenior(Person p)
        {
            return p.Age > 65;
        }


        #endregion
        #region Event and Delegate 3: Anonymous Method 
        static void Main3(string[] args)
        {
            List<Person> people = new List<Person>
            {
                new Person{Name="Suraj",Age=27},
                new Person{Name="raj",Age=12},
                new Person{Name="Suj",Age=17},
                new Person{Name="RajKumar",Age=26},
                new Person{Name="Kumar",Age=66},
            };

            // creating anonymous method and assigning to delegate.
            FilterPersonDelegate filter = delegate (Person p)
            {
                return p.Age >= 18 && p.Age <= 65;
            };
            Console.WriteLine("using anonymous method");

            DisplayPeople("Adults anonymous ", people, filter);

            DisplayPeople("All : ", people, delegate (Person p) {
                return true;
            });
            Console.ReadLine();
        }
        #endregion

        #region Event and Delegate 4: Lambda Expression 
        static void Main4(string[] args)
        {
            List<Person> people = new List<Person>
            {
                new Person{Name="Suraj",Age=27},
                new Person{Name="raj",Age=12},
                new Person{Name="Suj",Age=17},
                new Person{Name="RajKumar",Age=26},
                new Person{Name="Kumar",Age=66},
                new Person{Name="ARUN",Age=26},
            };

            // creating anonymous method and assigning to delegate.
            FilterPersonDelegate filter = delegate (Person p)
            {
                return p.Age >= 18 && p.Age <= 65;
            };
            Console.WriteLine("using anonymous method");

            DisplayPeople("Adults anonymous ", people, filter);

            DisplayPeople("All : ", people, delegate (Person p) {
                return true;
            });


            string searchKeyword = "A";
            // using statement lambda 
            DisplayPeople("age > 20 with search keyword:" + searchKeyword, people, p =>
             {
                 if (p.Name.Contains(searchKeyword) && p.Age > 20)
                   return true;
                 else
                     return false;
             });

            // using Expression lambda 
            DisplayPeople("exactly 26 ", people, p => p.Age == 26);

            Console.ReadLine();
        }
        #endregion

        #region Event and Delegate 5: Event and Multicast Delegate  
        static void Main(string[] args)
        {

           

            // creating audio system
            AudioSystem audioSystem = new AudioSystem();

            // creating rendering engine
            RenderingEngine renderingEngine = new RenderingEngine();

            // creating 2 players 
            Player player1 = new Player("FullStackGamer");
            Player player2 = new Player("LiveDeveloper");
            Player player3 = new Player("WolfWarrior");

            #region Without using MultiCast Delegate
            /* Console.WriteLine("--------Without using MultiCast Delegate");

             // start the audio and rengdering system
             audioSystem.StartGame();
             renderingEngine.StartGame();

             // spawn the players
             player1.StartGame();
             player2.StartGame();

             Console.WriteLine("Game is Running ... Press any key to end the game");

             Console.ReadKey();

             //shutdown all
             audioSystem.GameOver();
             renderingEngine.GameOver();

             // remove players

             player1.GameOver();
             player2.GameOver();*/
            #endregion



            Console.WriteLine("Using Multicast Delegate");

            GameEventManager.TriggerGameStart();

            Console.WriteLine("Game is running, press any key to end the game");
            Console.ReadLine();

            GameEventManager.TriggerGameOver();

            Console.ReadLine();
        }



        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _8.Inheritence.AnimalClasses;
using _8.Inheritence.Classes;
using _8.Inheritence.CompanyClasses;
using _8.Inheritence.InterfaceClasses;
using _8.Inheritence.PostClasses;

namespace _8.Inheritence
{
    class Program
    {


        /*  #region Inheritence 5: 

          static void Main(string[] args)
          {
        
              Console.ReadLine();
          }

          #endregion*/
        #region Inheritence 11:  IEnumerable<T> Demo

        static void Main(string[] args)
        {
            List<int> numberList = new List<int>() { 56, 7, 8, 8, 99 };

            int[] numberArray = new int[] { 1, 2, 3, 4, 5, 6 };

            CollectionSum(numberList);

            CollectionSum(numberArray);

            Console.ReadLine();
        }

        static void CollectionSum(IEnumerable<int> anyCollection)
        {
            int sum = 0;

            foreach (int num in anyCollection)
            {
                sum += num;

            }

            Console.WriteLine("Sum of element in collections  is {0}",sum);

        }
        #endregion
        #region Inheritence 10: IEnumerable Examples 

        static void Main10(string[] args)
        {
            IEnumerable<int> unknownCollection;

            unknownCollection = GetCollection(3);

            foreach (int num in unknownCollection)
            {
                Console.Write(num + " ");

            }
            Console.WriteLine();

            Console.ReadLine();
        }
        static IEnumerable<int> GetCollection(int option)
        {
            List<int> numberList = new List<int>() { 1, 2, 3, 4, 5, 6 };
            Queue<int> numbersQueue = new Queue<int>();
            numbersQueue.Enqueue(7);
            numbersQueue.Enqueue(8);
            numbersQueue.Enqueue(9);
            numbersQueue.Enqueue(10);
            numbersQueue.Enqueue(11);

            switch (option)
            {
                case 1:
                    return numberList;
                case 2:
                    return numbersQueue;
                default:
                    return new int[] { 12, 13, 14 };
                    
            }
            
        }

        #endregion
        #region Inheritence 9:  Commonly used Interaces: IEnumerabl<T> and IEnumerable 



        static void Main9(string[] args)
        {
            DogShelter shelter = new DogShelter();

            foreach (Dog dog in shelter)
            {
                if (!dog.IsNaughtyDog)
                    dog.GiveTreat(2);
                else
                    dog.GiveTreat(1);
            }


            Console.ReadLine();
        }

        #endregion

        #region Inheritence 8: Interface Implementation 

        static void Main8(string[] args)
        {
            Chair officeChair = new Chair("Brown", "Plastic");
            Chair gamingChair = new Chair("Red", "Wood");

            Car damagedCar = new Car(80f, "Blue");

            damagedCar.DestroyablesNearby.Add(officeChair);
            damagedCar.DestroyablesNearby.Add(gamingChair);

            damagedCar.Destroy();

            Console.ReadLine();
        }

        #endregion

        #region Inheritence 7: Interface

        static void Main7(string[] args)
        {
            Ticket ticket1 = new Ticket(10);
            Ticket ticket2 = new Ticket(10);

            Console.WriteLine("are ticket 1 equal to ticket 2 = {0}",ticket1.Equals(ticket2));

         

            Console.ReadLine();
        }

        #endregion
        #region Inheritence 6:  Assignment 2

        static void Main6(string[] args)
        {
            Employee employee = new Employee("raj Dhinge", "Raj", 100000);

            Boss boss = new Boss("Suraj Porje", "suraj", 1000000, "Tesla");

            Trainee trainee = new Trainee("suraj p", "suraj", 10000, 8, 4);

            employee.Work();

            boss.Lead();

            trainee.Work();

            Console.ReadLine();
        }

        #endregion

        #region Inheritence 5: Assignment solution

        static void Main5(string[] args)
        {
            VideoPost myFirstVideoPost = new VideoPost(videoUrl, 10, "Hello World", "Suraj", true);

            myFirstVideoPost.Play2();
            Console.WriteLine("Press any key to stop the video");
            Console.ReadKey();
            Console.WriteLine();
            myFirstVideoPost.Stop2();


            Console.ReadLine();
        }
        #endregion

        #region Inheritence 4: Assignment 
        private const string videoUrl = "http://image.con/video";
        static void Main4(string[] args)
        {
            TimeSpan videoLength = new TimeSpan(5, 20, 1);
           

            VideoPost myFirstVideoPost = new VideoPost(videoUrl, videoLength, "Investment", "Suraj ", true);
            string end;
            Console.WriteLine(myFirstVideoPost.ToString());
            do
            {
                myFirstVideoPost.Play();

                Console.WriteLine("Press Any key to stop the video, or Enter to Continue ");
                end = Console.ReadLine();
            } while (end  != "");
          

            if(string.IsNullOrEmpty(end) )
            {
                myFirstVideoPost.Stop();
            }

            Console.ReadLine();
        }
        #endregion
        #region Inheritence 3: Deriving class
        private const string PostUrl = "https://images.com/shoes";
        static void Main3(string[] args)
        {
            Post post1 = new Post("Welcome", "Suraj Porje", true);

            Console.WriteLine(post1.ToString());

            ImagePost newImagePost = new ImagePost( "Made Great investment","Raj", true, PostUrl);
            Console.WriteLine(newImagePost.ToString());

            Console.ReadLine();
        }
        #endregion

        #region Inheritence 2: Virutal Override 


        static void Main2(string[] args)
        {
            Monkey monkey = new Monkey("kong", 100);

            Console.WriteLine($"{monkey.Name} is {monkey.Age} years old");

            monkey.Play();
            monkey.Eat();

            Console.ReadLine();
        }
        #endregion

        #region Inheritence 1
        static void Main1(string[] args)
     {

            Radio myRadio = new Radio(false, "Sony");
            myRadio.SwitchOn();
            myRadio.DeviceStatus();

            myRadio.SwitchOff();

            myRadio.DeviceStatus();

            TV myTv = new TV(false, "LG");
            myTv.SwitchOn();
            myTv.DeviceStatus();
            myTv.SwitchOff();
            myTv.DeviceStatus();

            Console.ReadLine();
      }
    #endregion

    }
}

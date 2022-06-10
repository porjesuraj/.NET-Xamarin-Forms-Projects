using _6.Collections.Classes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.Collections
{
    class Program
    {

        

        //22
        #region Assignment on Queue
        static void Main(string[] args)
        {
            Queue<Order> orderQueue = new Queue<Order>();

            foreach (Order order in RecievedOrderFromBranch1())
            {
                // add each order to the queue 
                orderQueue.Enqueue(order);

            }
            foreach (Order order in RecievedOrderFromBranch2())
            {
                // add each order to the queue
                orderQueue.Enqueue(order);

            }

            while (orderQueue.Count > 0)
            {
                // remove the order at the front of the queue
                // and store it in a variable called currentOrder
                Order currentOrder = orderQueue.Dequeue();
                // process the order
                currentOrder.Processorder();

            }
            Console.ReadLine();
        }

        // this method create an array of orders and return it 
        static Order[] RecievedOrderFromBranch1()
        {
            // create new orders array
            Order[] orders = new Order[]
            {
                new Order(1,5),
                new Order(2,10),
                new Order(6,15)
            };

            return orders;

        }
        static Order[] RecievedOrderFromBranch2()
        {
            // create new orders array
            Order[] orders = new Order[]
            {
                new Order(3,5),
                new Order(4,10),
                new Order(5,15)
            };

            return orders;

        }
        #endregion
        #region Queue
        static void Main21(string[] args)
        {
            // defining a queue of integers
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);

            Console.WriteLine("the value in the front of the queue is {0}",queue.Peek());
            int deletedItem = 0;
            if (queue.Count > 0)
               deletedItem = queue.Dequeue();

            Console.WriteLine("the value deleted is {0}",deletedItem);
            Console.WriteLine("the value in the front of the queue is {0}", queue.Peek());

            while(queue.Count > 0)
            {
              

                Console.WriteLine("the value deleted  is  : {0}", queue.Dequeue());
                Console.WriteLine("the count of Queue is  : {0}", queue.Count());
            }



            Console.ReadLine();
        }
        #endregion
        #region Stacks
        static void Main20(string[] args)
        {
            // defining a new stack
            Stack<int> stack = new Stack<int>();
            // add elements to the stack using push
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            // peek() will return top element in stack
            Console.WriteLine("Top value in the stack is {0}",stack.Peek());
            int myStackItem = 0;
            if (stack.Count > 0)
                myStackItem = stack.Pop();

            Console.WriteLine("Popped Item : {0}",myStackItem);
            Console.WriteLine("Top value in the stack is {0}", stack.Peek());


            while(stack.Count > 0)
            {
         
                Console.WriteLine("item {0} Removed ",stack.Pop());
                Console.WriteLine("Stack count is {0}",stack.Count());
            }
            Console.WriteLine("Stack Cleared");


            int[] numbers = new int[] { 8, 7, 6, 5, 4, 3, 2, 1 };

            Console.WriteLine("Number Series is ");
            Array.ForEach(numbers,x => Console.Write(x + " "));
            Console.WriteLine();

            // defining a new stack of int
            Stack<int> myNumberStack = new Stack<int>(numbers);

            Console.WriteLine("Number Series in Reverse Order is ");
            foreach (var item in myNumberStack)
            {
                Console.Write("{0} ",item);
            }
            Console.ReadLine();


        }
        #endregion
        #region Dictionaries

        // key - value 
        // Auto = Car
        static void Main19(string[] args)
        {
            Dictionary<int, string> myDictionary = new Dictionary<int, string>()
            {
                {1, "one" },
                {2, "two" },
                {3, "three" }
            };

            Employee[] employees =
            {
                new Employee("CEO","Suraj",30,10000),
                new Employee("Manager","Joe",35,300),
                new Employee("HR","porus",45,300),
                new Employee("Secretary","chaanakya",55,300),
                new Employee("Developer","Ethirium",25,300),
            };

            Dictionary<string, Employee> employeesDirectory = new Dictionary<string, Employee>();

            // add data to dictonary
            foreach (Employee emp in employees)
            {
                employeesDirectory.Add(emp.Role, emp);
            }

            // get data from dictonary

            foreach (KeyValuePair<string,Employee> entry in employeesDirectory)
            {
                Console.WriteLine("Role : {0}",entry.Key );

                Console.WriteLine("Emplyee : {0}",entry.Value.ToString());

            }


            string key = "CEO";

            if(employeesDirectory.ContainsKey(key))
            {
                Employee emp1 = employeesDirectory[key];

                Console.WriteLine("found : {0}", emp1.ToString());
            }


            Employee result = null;
            // using TryGetValue() it returns true if the operation is successful and false if not
            if (employeesDirectory.TryGetValue("Developer",out result))
            {
                Console.WriteLine( "Value Retrieved !.");

                Console.WriteLine(result.ToString());

            }else
            {
                Console.WriteLine("the key does not exist");
            }
            Console.WriteLine();


            // update the dictonary  value 
            string KeyToUpdate = "HR";

            if(employeesDirectory.ContainsKey(KeyToUpdate))
            {
                employeesDirectory[KeyToUpdate] = new Employee("HR", "Poonam", 26, 200);
                Console.WriteLine("Employee with Role {0} was Updated !", KeyToUpdate);

            }else
            {
                Console.WriteLine("Employee not found with this key");
            }


            // remove dictionary element 
            string KeyToRemove = "Manager";
            if (employeesDirectory.Remove(KeyToRemove))
            {
                Console.WriteLine("Employee Role/Key {0} was Removed !",KeyToRemove);
            }else
                Console.WriteLine("Employee not found with {0} key",KeyToRemove);


            for (int i = 0; i < employeesDirectory.Count; i++)
            {
                // using ElementAt(i) to return the key-value pair stored at index 1
                KeyValuePair<string, Employee> keyValuePair = employeesDirectory.ElementAt(i);

                // print the key
                Console.WriteLine("Key : {0}",keyValuePair.Key);

                // print properties of employee
                Console.WriteLine(keyValuePair.Value.ToString());

            }
           
            
            Console.ReadLine();

        }
        #endregion
        #region Assignment HashTable
        static void Main18(string[] args)
        {

            Student[] students = new Student[5]
            {
                 new Student(1, "Raj", 90),
                 new Student(2, "Viraj", 80),
                 new Student(3, "Sahiraj", 70),
                 new Student(4, "ajay", 60),
                 new Student(1, "Rajishri", 50)
            };

            Hashtable studentsTable = new Hashtable();
            foreach (var item in students)
            {
                if (studentsTable.ContainsKey(item.Id))
                {
                    Console.WriteLine($"Sorry ,A Student with same ID  : {item.Id} already exists");
                }
                else
                {
                    studentsTable.Add(item.Id, item);

                    Console.WriteLine($" student wih Id : {item.Id} Added");
                }
            }

            Console.ReadLine();

        }
        #endregion
        #region HastTables

        // Auto - car
        // one to one relationship as Key -Value Pair
        // Hastable is a collectio of Dictionary Entries. 
        static void Main17(string[] args)
        {
            Hashtable studentTable = new Hashtable();

            Student stud1 = new Student(1, "Raj", 90);
            Student stud2 = new Student(2, "Viraj", 80);
            Student stud3 = new Student(3, "Sahiraj", 70);
            Student stud4 = new Student(4, "ajay", 60);
            Student stud5 = new Student(5, "Rajishri", 50);
            Student stud6 = new Student(6, "Raju", 79);

            studentTable.Add(stud1.Id, stud1);
            studentTable.Add(stud2.Id, stud2);
            studentTable.Add(stud3.Id, stud3);
            studentTable.Add(stud4.Id, stud4);
            studentTable.Add(stud5.Id, stud5);
            studentTable.Add(stud6.Id, stud6);

            // retrieve individual item with known id
            Student storedStudent = (Student)studentTable[key: 1];
            Console.WriteLine($"Stored Student Id : {storedStudent.Id},Name : {storedStudent.Name}, GPA " +
                $"{storedStudent.GPA} ");


            // retrieve all values from a hashtable 
            foreach (DictionaryEntry entry in studentTable)
            {
                Student stud = entry.Value as Student;
                Console.WriteLine($"Stored Student Id : {stud.Id},Name : {stud.Name}, GPA : " +
               $"{stud.GPA} ");
            }

            foreach (Student stud in studentTable.Values)
            {
                Console.WriteLine($"Stored Student Id : {stud.Id},Name : {stud.Name}");
            }

            Console.ReadLine();

        }
        #endregion
        #region List Exercise
        static void Main16(string[] args)
        {
            var list = Solution();
            Console.WriteLine("list of even integers from 100 to 170");
            list.ForEach(x => Console.Write(x + " "));

            Console.ReadLine();

        }

        /// <summary>
        /// A method that return list of even number integer ,between 100 and 170
        /// </summary>
        /// <returns></returns>
        public static List<int> Solution()
        {
            List<int> evenList = new List<int>();

            for (int i = 100; i <= 170; i++)
            {
                if (i % 2 == 0)
                    evenList.Add(i);

            }

            return evenList;
        }
        #endregion
        #region List
        static void Main15(string[] args)
        {
            var list = new List<int>() { 1, 2, 3, 4, 5, 6 };

            list.Add(7);
            list.Remove(1);

            foreach (var item in list)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            for (int i = 0; i < list.Count; i++)
            {
                Console.Write(list[i] + " ");

            }

            Console.ReadLine();
        }
        #endregion
        #region ArrayList
        static void Main14(string[] args)
        {

            // declaring an Arraylist
            ArrayList myArrayList = new ArrayList();

            // declaring ArrayList with defined amount of object
            ArrayList myArrayList2 = new ArrayList(100);

            myArrayList.Add(25);
            myArrayList.Add(35);
            myArrayList.Add(45);
            myArrayList.Add("Hello");
            myArrayList.Add(13.37);
            myArrayList.Add(13.37f);

            // delete element with specific value from the arraylist
            myArrayList.Remove(13);

            // delete eleemnt at specific position
            myArrayList.RemoveAt(0);

            Console.WriteLine("Array list count  = {0}", myArrayList.Count);


            double sum = 0;

            foreach (var obj in myArrayList)
            {
                if(obj is int )
                {
                    sum += Convert.ToDouble(obj);

                } else if(obj is double)
                {
                    sum += (double)obj;
                }else if (obj is string)
                {
                    Console.WriteLine(obj);
                }




            }

            Console.WriteLine("Sum of arraylist int values = {0}",sum);

            Console.ReadLine();


        }
        #endregion
        #region Collection - Generic and Not Generic
        static void Main13(string[] args)
        {
            int num1 = 5;
            float num2 = 3.14f;
            string name = "Suraj";
            // Non= Generic Collection
            ArrayList myArrayList = new ArrayList();

            myArrayList.Add(num1);
            myArrayList.Add(num2);
            myArrayList.Add(name);

            foreach (dynamic item in myArrayList)
            {
                Console.Write(item + " ");

            }
            Console.WriteLine();

            // Generic Collection 
            string animal1 = "Cat";
            string animal2 = "Dog";
            string animal3 = "Rat";
            List<string> myList = new List<string>();
            myList.Add(animal1);
            myList.Add(animal2);
            myList.Add(animal3);

            foreach (string item in myList)
            {
                Console.Write(item + " ");
            }

            Console.ReadLine();

        }
        #endregion
        #region Params usecase
        static void Main12(string[] args)
        {
          int minimum =  MinV2(5, 82, 2, 4, 5, 5, 45, 6, 54, 33, 3, 1);

            Console.WriteLine("Minimum value is {0}",minimum);

            Console.ReadLine();
        }

        public static int MinV2(params int[] numbers)
        {
            int min = int.MaxValue;

            foreach (var num in numbers)
            {
                if (num < min)
                    min = num;

            }

            return min;

        }

        #endregion
        #region Params keyword
        static void Main11(string[] args)
        {

            string[] sentence = { "this ", "is", "a ", "long sentence" };
            int number = 5;
            ParamsMethod(sentence);
            ParamsMethod("this ", "is", "a sentence using  param", " syntax");

            ParamsObjectMethod( number, "Hello World",'$');
            Console.ReadLine();

        }

        private static void ParamsMethod(params string[] sentence)
        {
            for (int i = 0; i < sentence.Length; i++)
            {
                Console.Write(sentence[i] + " ");
                
            }
            Console.WriteLine();
        }
        private static void ParamsObjectMethod(params object[] stuff)
        {
            foreach (var item in stuff)
            {

                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
        #endregion
        #region Assignment on Array as Parameter
        static void Main10(string[] args)
        {
            int[] happiness = new int[5] { 1, 2, 3, 4, 5 };

            Console.WriteLine("Item in Array Before \n");
            foreach (var item in happiness)
            {
                Console.Write(item + " ");
            }
            SunIsShining(happiness);

            Console.WriteLine("Item in Array After \n");

            foreach (var item in happiness)
            {
                Console.Write(item + " ");
            }

            Console.ReadLine();
        }

        private static void SunIsShining( int[] happiness)
        {
         var newHappy =   happiness.Select(i => i + 2).ToArray();

            happiness = newHappy;
        }
        #endregion

        #region Using Arrays as Parameters
        static void Main9(string[] args)
        {
            int[] gradesArray = new int[] { 5,5,5,5,10};

          double averageResult =  GetAverage(gradesArray);

            Console.WriteLine("Average is {0}",averageResult);
            Console.ReadLine();
        }

        private static double GetAverage(int[] gradesArray)
        {
            double average;

              double sum =  gradesArray.Sum();

            average = sum / gradesArray.Length;

            return average;
            
        }


        #endregion
        #region Assignment jagged array
        // create a jagged array , which contains 3  "friends arrays", in which two family members should be stored
        // Introduce family members from different families to each other via console 

        static void Main8(string[] args)
        {
            // we can create a separate array and store it into our jagged array


            string[] joesFamily = new string[] { "jame", "elon" };
            string[][] SocietyJaggedArray = new string[4][]
                {
                    new string[] {"raj","mohit"},
                    new string[] {"raju","mohit0"},
                    new string[] {"ra","ohit0"},
                    joesFamily
                };


            for (int i = 0; i < SocietyJaggedArray.Length; i++)
            {
                Console.WriteLine("Introducing Family {0}", i + 1);
                for (int j  = 0; j < SocietyJaggedArray[i].Length; j++)
                {

                    Console.WriteLine("Hello my Name is {0}", SocietyJaggedArray[i][j]);
                }

            }

            Console.ReadLine();
        }
        #endregion

        #region Jagged Array - array in an array

        // index                        0    1   2    3       
        // normal array of type int : [15],[21],[23],[13]
        // index                             0                         1               2
        // jagged array of type int : [array1([15][13] [5]), array2([7],[8],[2]), array3([7],[8],[1])]
        static void Main7(string[] args)
        {

            // declare jagged array
            int[][] jaggedArray = new int[3][];

            jaggedArray[0] = new int[5];
            jaggedArray[1] = new int[3];
            jaggedArray[2] = new int[2];

            // initialize jagged array
            jaggedArray[0] = new int[] { 2, 3, 4, 5, 6 };
            jaggedArray[1] = new int[] { 2, 3, 4 };
            jaggedArray[2] = new int[] { 2, 3 };

            //second wat to init
            int[][] jaggedArray2 = new int[][]
            {
                 new int[] { 2, 3, 4, 5, 6 },
                  new int[] { 2, 3, 4},
                   new int[] { 2, 3}
            };
            //get value from jagged array
            Console.WriteLine("the value in middle of first entry is {0}",jaggedArray2[0][3]);
           

            for (int i = 0; i < jaggedArray2.Length; i++)
            {
                Console.WriteLine("Element {0}",i);
                for (int j = 0; j < jaggedArray2[i].Length; j++)
                {
                    Console.WriteLine("value at index [{0}] [{1}] is {2}",i,j,jaggedArray2[i][j]);
                }

            }

            Console.ReadLine();
        }
        #endregion
        #region Nested For Loop

        static int[,] matrix =
        {
            {1,2,3 },
            {4,5,6 },
            {7,8,9 }
        };

        static void Main6(string[] args)
        {
            foreach(int item in matrix)
            {
                Console.Write(item  + " ");
                //cannot assign new value to collection item
               // item = 3;

            }
            Console.WriteLine();
            // Prinitng array using nested for loop

            Console.WriteLine("This is our 2D array printed using nested for loop");

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i,j] % 2 == 0)
                        Console.Write(matrix[i, j] + " ");
                    else
                        Console.Write(" ");
                   
                }
                Console.WriteLine();
            }

            Console.WriteLine("Print diagonal element of array");
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (i==j)
                        Console.Write(matrix[i, j] + " ");
                    else
                        Console.Write(" ");

                }
                Console.WriteLine();
            }

            Console.WriteLine("print diagonal element using one for loop");
            int col = matrix.GetLength(0);
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
              
                Console.WriteLine(matrix[i,--col] );
               

            }

            Console.WriteLine("Secodn Approach,print diagonal element using one for loop");

            for (int i = 0,j= 2; i < matrix.GetLength(0); i++,j--)
            {
                Console.WriteLine(matrix[i,j]);
            }

            Console.ReadLine();

        
        }
        #endregion
        #region Multi Dimensional Array
        static void Main5(string[] args)
        { 
            // declare 2-D array
            string[,] matrix;
           /// Error, not correct approach 
           /// matrix = { { "1","2"}, { "3","4"} };
            // 3D array
            string[,,] threeD;

            // 2D Array
            int[,] arrat2D = new int[,]
            {
                {1,2,3 },
                {4,5,6 },
                {7,8,9 }
            };

            Console.WriteLine("Central value is {0}",arrat2D[1,1]);

            Console.WriteLine("At Position 2,0 we have {0}",arrat2D[2,0]);

            string[,,] array3D = new string[,,]
            {
                {
                    {"000","001" },
                    {"010","011" },
                    {"Hi there","What's up" }

                },

                {
                    {"100","101" },
                    {"110","111" },
                    {"GoodBye","see you again" }
                }
            };



            Console.WriteLine("3 D Array ,the value is {0}",array3D[0,2,0]);
            Console.WriteLine("3 D Array ,the value is {0}",array3D[1,2,0]);

            // another way to specify array

            string[,] array2DString = new string[3, 2]
            {
                {"1","2" },
                {"3","4" },
                {"5","6" },
            };

            array2DString[1,1] = "Chicken";
            Console.WriteLine("2 D Array ,the value is {0}",array2DString[1,0]);
            Console.WriteLine("2 D Array ,the new value is {0}", array2DString[1,1]);

            int dimensions = array2DString.Rank;

            Console.WriteLine("Dimension of array is {0}",dimensions);

            // declaring array without specifying dimension(rank)
            int[,] intArray2D = { { 1, 2 }, { 3, 4 } };

            Console.ReadLine();

        }
        #endregion

        #region Assignment 2
        static void Main4(string[] args)
        {
            int choice = 1;
            while(choice != 0)
            {
                string inputValue;
                int inputChoice;
                string inputDataType = string.Empty;
                bool valid = false;
                Console.WriteLine("Please Enter a Input value");

                inputValue = Console.ReadLine();

                Console.WriteLine("Please select dataype of input");
                Console.WriteLine("Press 1 for String \n Press 2 for integer \n Press 3 for Boolean \n press 0 To Exit");
                
                int.TryParse(Console.ReadLine(), out inputChoice);
                switch (inputChoice)
                {
                    case 0:
                        choice = 0;

                        break;
                    case 1:
                        valid =  IsAllAlphabetic(inputValue);
                        inputDataType = "String";
                       

                        break;
                    case 2:
                        valid = int.TryParse(inputValue, out int  result);

                        inputDataType = "Integer";

                        break;
                    case 3:
                        valid = bool.TryParse(inputValue, out bool boolResult);

                        inputDataType = "Boolean";

                        break;

                    default:
                        inputDataType = "unkwown";
                        Console.WriteLine("Please Select from Given Options ");
                        break;
                }

                Console.WriteLine("you have entered a value : {0}", inputValue);
                if (valid)
                    Console.WriteLine("it is  valid : {0}",inputDataType);
                else
                    Console.WriteLine("it is not a valid : {0}",inputDataType);


            }

            Console.ReadLine();
        }

        private static bool IsAllAlphabetic(string inputValue)
        {
           foreach(char c in inputValue)
            {
                if (char.IsLetter(c))
                    return false;      
            }

            return true;
        }
        #endregion
        #region Assignment Friends Array
        static void Main3(string[] args)
        {

            string[] friends = new string[5];
            friends[0] = "Pawan";
            friends[1] = "Shaunak";
            friends[2] = "Mohit";
            friends[3] = "RajKumar";
            friends[4] = "Abhishekh J";

            string[] Friends = new string[] { "Pawan", "Shaunak", "Mohit", "RajKumar", "Abhishekh J" };



            foreach(string friend in Friends)
            {
                Console.WriteLine("Hello, {0} my Friend",friend);

            }

            Console.ReadLine();
        }
        #endregion
        #region  Forach loop with Array 
        static void Main2(string[] args)
        {
            int[] nums= new int[10];
            // first method for for
            for (int i = 0; i < nums.Length; i++)
            {
                nums[i] = i + 10;

                Console.WriteLine("Element{0} = {1}",i,nums[i]);
            }
            // second method 
            Console.WriteLine("Second Method");
            int counter = 0;
            foreach(int k in nums)
            {
                Console.WriteLine("Element {0} = {1}",counter++,k);
                

            }



            Console.ReadLine();
        }
        #endregion
        #region Arrays Basics
        static void Main1(string[] args)
        {
            int[] grades = new int[5];
            grades[0] = 20;
            grades[1] = 30;
            grades[2] = 40;
            grades[3] = 50;
            grades[4] = 60;

            Console.WriteLine("Enter  a Number to enter the array");
            string input = Console.ReadLine();
            
            grades[0] = int.Parse(input);

            Console.WriteLine("grades at index 0 : {0}",grades[0]);

            //Another way of initializing an array
            int[] gradesOfMathStudentsA = { 20, 13, 13, 8, 8 };

            // third way of init
            int[] gradesOfMathStudentsB = new int[] { 15, 23, 3, 13, 30, 34 };
            int lengthOfB = gradesOfMathStudentsB.Length;
            Console.WriteLine("length of gradesOfMathStudentsB is {0}",lengthOfB);
            Console.ReadLine();
        }
        #endregion
    }
}

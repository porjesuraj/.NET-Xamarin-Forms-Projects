# <a href="https://docs.microsoft.com/en-us/dotnet/fundamentals/"> C# Master Course </a>
### Section 1
+ starting C# programming using VS2019 ide, so certain features provided by ide: 


### Section 2

#### 1. Data Types are
+ Primitive type
 1. sbyte : it is a signed byte, can store no from -129 to 127
 2. short : store whole no between -32767 to 32767
 3. int : store no beteen +2.14 to -2.14 Billion
 4. long : to store large data ,store no beteen +9.22 to -9.22 Billion
 5. float, use to store decimal no, its data must end with a constant 'f'
  + it has precision of 7-digit  .
  + used in graphic libraries (high demands for processing power)
 6.  Double, allows decimal and range higher than float, 15-digit precision
  + no need for constants at end. 
  + used for real world values(except money calculations)
 7. decimal: 28 -digit precision.
  + used for financial applications(high level of accuracy)
 8. bool : only true or false
 9. Char : allow a single character literal or unicode ,need '' (single quotes surrounding the text) 
 10. string: for multiple letters and uniquodes. 
   
   
#### Coding Standard

1. Reasonable Variable Name 

```c#

int age = 22;
int userAge = 35;
```

2. Proper Method Name 

```c#
void CheckInternetConnection()
{}
```
3. Comments
+ function should have comments descibing use of function , a must 
+ Types of Comment
 1. Single Line using //
 2. Multiline Comment using /* */
 3. XML documentation comments 
 ```c#
      ///<summary>
      // info related to method
      ///<summary>
      void CoolMethod() {}
 ```
```c#
// use to check internet connection
void CheckInternetConnection()
{}


```

4. Casing used in .NET
+ there are two casing Pascal and Camel :
 1. Pascal Casing  used for for Class Name, Method name 
+ In Pascal casing starting letter is capital , followed by every added word 
+ ex:
 >  Class AdditionProgram { }
  > public void AdditionMethod()
 2. Camel Casing used for method arguments, local variables
  + ex:
   > int void Main(string[] args)
   > var name = ""; 

 3. Points to remember 
  + try to avoid using abbrevation 
  + dont use number at tje start of variable names
  + try to avoid _ in variable ,can use at the start 
  + try to avoid capital form of Datatypes 
  + use noun prases for classes.
  + use verb for methods as they are action 


#### Value type and Reference Type
+ value type store actual data , while ref type store memeory address to the data . 
+ reference type are string, class ,Array, etc
+ value type are primitive types like int, float,etc.
+ reference type can be used to reduce memory used by a program,as reference can be passed instead of copy of object

#### String manipulation 
1. Foramtting String 
```c#
 int age = 31;

            string name = "Sunny";
            string job = "developer";
            // 1. String concatination 
            Console.WriteLine("String Concationation");

            Console.WriteLine("Hello my name is " + name + ", I am " + age + "years old");

            // 2. String formating 
            Console.WriteLine("String Formatting");

            Console.WriteLine("Hello my name is {0} , I am  {1} years old, I'm a {2}",name,age,job);


            // 3. String Interpolation 
            // it uses $ at the start which will allow us to write our variable like {v}

            Console.WriteLine(" String Interpolation ");
            Console.WriteLine($"Hello my name is {name} , I am  {age} years old, I'm a {job}");

            /* 4. Verbatim strings 
             verbatim strings starts with @ and tells the compiler to take the string
            literally and ignore any spaces and escape characters like \n 
            */

            Console.WriteLine("Verbatim Strings");
            Console.WriteLine(@"Hello All,
SCRUM is iterative, incremental methodology ");
            // great use case in case of url or path 
   Console.WriteLine(@"C:\Users\surajpor\Desktop\DotNet_Course\Notes");
// with these even valid escape char wont work

            Console.WriteLine(@" Bye \n All");
            Console.WriteLine(" Bye \n All");
            Console.ReadLine();
```


### Section3: Methods

#### Decision making : Enhanced If Else
```c#
   temperature += 30;
 stateOfMatter = temperature < 0 ? "solid" : "liquid";

 // it is eveluated as   a ? b : (c ? d : e); 
 stateOfMatter = temperature < 0 ? "solid" : temperature > 100 ? "gaseous" : "liquid";

```

### Section4: Loops

1. Advantage of Loops:
 + Save time
 + Quick and easy repetition of code
 + Allows you to work with huge amounts of data
 + allows you to loop through arrays

2. Loop Types
+ for Loop
+ great for counters
```c#
for(start value;condition;increment)
{
  //code body
}
```
+ While loop (check then go)
```c#
countVariable = 0;
while(condition)
|{
  // execute code
  counterVariable++;
}
```
+ do while loop (do first then check)
```c#
countVariable = 0;
do
{
  countVariable++;

}While(condition)
```

+ foreach loop (run through array or list)
```c#
 foreach(var item : collection)
 {

 }
```

### Section5 : OOP

1. Class
+ it is a blue print of an object
+ it has properties that are member variable and actions called member function 
+ it can be used like a class


2. <a href="https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/access-modifiers"> Access Modifier </a>
+ Access modifiers are keywords used to specify the declared accessibility of a member or a type. T
+ his section introduces the four access modifiers:
1. public
2. protected
3. internal
4. private
+ The following six accessibility levels can be specified using the access modifiers:
1. public: Access is not restricted.

2. protected: Access is limited to the containing class or types derived from the containing class.

3. internal: Access is limited to the current assembly.

4. protected internal: Access is limited to the current assembly or types derived from the containing class.

5. private: Access is limited to the containing type.

6. private protected: Access is limited to the containing class or types derived from the containing class within the current assembly.



3. Properties
   + Property  are used with a private field, they  provide public getter and setter to a field.
   + we can use shortcut like "prop / propfull + Tab + Tab" to create Auto Implemented Properties 


4. Class Members 

+ 1. Finalizer
```c#
  // member - finalizer - destructor 
        // we can create only one destructor per class
        // desctructor cannot be overloaded, inherited, or called

        ~Members()
        {
            //cleanup statement 
             Debug.Write("Destruction of Members Object");

        }
```

### Section6: Collection 

1. Array

```c#
 datatype [] arrayName = new dataType[amountOfEntries];
             arrayName[index] = value;
            
 int [] grades = new int[5];
```

2. Foreach
+ For Loop is faster than foreach loop
+ using foreach on string 
```c#

    private static bool IsAllAlphabetic(string inputValue)
        {
           foreach(char c in inputValue)
            {
                if (char.IsLetter(c))
                    return false;      
            }

            return true;
        }
```
3. String

```c#
  string[] friends = new string[5];
            friends[0] = "Pawan";
            //second method
    string[] Friends = new string[] { "Pawan", "Shaunak", "Mohit", "RajKumar", "Abhishekh J" };

```

4. Multi-Dimensional Array

```c#
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
```

5. Nested For Loop
+ we can use array.GetLength(dimension) method to get dimension of array.
```c#
 foreach(int item in matrix)
            {
                Console.Write(item  + " ");
                //cannot assign new value to collection item
               // item = 3;
            }
          
            // Prinitng array using nested for loop
            Console.WriteLine("This is our 2D array printed using nested for loop");
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                  // we can assign new value to array item; 
                    if (i == j)
                        Console.Write(matrix[i, j] + " ");
                    else
                        Console.Write(" ");
                   
                }
                Console.WriteLine();
            }
```

6. Jagged Array
 + it an array , in which each index contains another array.
 +  we can create a separate array and store it into our jagged array
```c#
 // index                        0    1   2    3       
        // normal array of type int : [15],[21],[23],[13]
        // index                             0                         1               2
        // jagged array of type int : [array1([15][13] [5]), array2([7],[8],[2]), array3([7],[8],[1])]
        static void Main(string[] args)
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
```

7. Params keyword
+ we can use this keyword , and add our collection element as method parameter or no parameter is also acceptable.
+ using params we can take any numbers of arguments for a method.
```c#


  private static void ParamsObjectMethod(params object[] stuff)
        {
            foreach (var item in stuff)
            {

                Console.Write(item + " ");
            }
            Console.WriteLine();
        }



int number = 5;

 ParamsObjectMethod( number, "Hello World",'$');
```

7. Collection
+ Collections are classes that can store a collection of Objects
+ its element are not limited to one type of objects
+ it has no size constraint, it can grow in size as we add more elements 

+ We use Collection to store, manage and manipulate groups of objects more efficiently like adding, deleting, searching ,etc.
+ ther are two types of Collections:
 1. Non-Generic Collection
 + Can store any type of objects
 + these are object type collections.
 + Located in System.Collections
 + eg: ArrayList, IList,Stack

 2. Generic Collections 
 + limited to one type of object, specified as type parameter
 + located in System.Collections.Generic namespace
 + eg: LinkedList<>,Dictionary<>,List<>

+ Collections :
 1.  HashTable 
 ```c#
 Hashtable studentTable = new Hashtable();

            Student stud1 = new Student(1, "Raj", 90);
             studentTable.Add(stud1.Id, stud1);
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

 ```
 2. Dictionary
```c#
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

            // check for Key using ContainsKey()
                string key = "CEO";

            if(employeesDirectory.ContainsKey(key))
            {
                Employee emp1 = employeesDirectory[key];

                Console.WriteLine("found : {0}", emp1.ToString());
            }


               // use TryGetValue
            Employee result = null;
            // using TryGetValue() it returns true if the operation is successful and false if not
            if (employeesDirectory.TryGetValue("Developer",out result))
            { }

            // update the dictonary  value 
            string KeyToUpdate = "HR";

            if(employeesDirectory.ContainsKey(KeyToUpdate))
            {
                employeesDirectory[KeyToUpdate] = new Employee("HR", "Poonam", 26, 200);
            }
             // remove dictionary element 
            string KeyToRemove = "Manager";
            if (employeesDirectory.Remove(KeyToRemove))
            {
                Console.WriteLine("Employee Role/Key {0} was Removed !",KeyToRemove);
            }
```


8. TickTacToe Assignment 
```c#
namespace SudokuGameAssignment
{
    class SecondApproach
    {
      public  static char[,] board = new char[3, 3]
         {
                {'1','2','3' },
                {'4','5','6' },
                {'7','8','9' }
         };
        static int turns = 0;

        static void Main(string[] args)
        {
            int player = 2;
            int input = 0;
            bool inputCorrect = true;
            SetField();
            do
            {
                if (player == 2)
                {
                    player = 1;
                    EnterXorO('O',input);
                }
                else if (player == 1)
                {
                    player = 2;
                    EnterXorO('X',input);
                }
                SetField();
                #region Check Winning Condition
                char[] playerChars = { 'X', 'O' };
                foreach (char  playerChar in playerChars)
                {
                    if(    ((board[0,0] == playerChar) && (board[0, 1] == playerChar) && (board[0, 3] == playerChar))
                        || ((board[1, 0] == playerChar) && (board[1, 1] == playerChar) && (board[1, 3] == playerChar))
                        || ((board[2, 0] == playerChar) && (board[2, 1] == playerChar) && (board[2, 3] == playerChar))
                        || ((board[0, 0] == playerChar) && (board[1, 0] == playerChar) && (board[2, 0] == playerChar))
                        || ((board[0, 1] == playerChar) && (board[1, 1] == playerChar) && (board[2, 1] == playerChar))
                        || ((board[0, 2] == playerChar) && (board[1, 2] == playerChar) && (board[2, 2] == playerChar))
                        || ((board[0, 0] == playerChar) && (board[1, 1] == playerChar) && (board[2, 2] == playerChar))
                        || ((board[0, 2] == playerChar) && (board[1, 1] == playerChar) && (board[2, 0] == playerChar))
                        )
                    {
                        if(playerChar == 'X')
                          Console.WriteLine("\n player 2 has won!");
                        else
                         Console.WriteLine("\n player 1 has won!");
                        
                        Console.WriteLine("Please press any key to reset the game!");
                        Console.ReadKey();

                        // TO DO RESET Field
                        ResetField();
                        break;
                    }else if(turns == 10)
                    {
                        Console.WriteLine("Please press any key to reset the game ");
                        Console.ReadKey();
                        ResetField();
                        break;
                    }
                   
                }
                #endregion

                #region Test if filed is already taken
                do
                {
                    try
                    {
                        Console.WriteLine("\n Player {0} : Choose your field! ", player);
                        input = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (Exception) { Console.WriteLine("Enter a Number");}

                    if ((input == 1) && (board[0, 0] == '1'))
                        inputCorrect = true;
                    else if ((input == 2) && (board[0, 1] == '2'))
                        inputCorrect = true;
                    else if ((input == 3) && (board[0, 2] == '3'))
                        inputCorrect = true;

                    else if ((input == 4) && (board[1, 0] == '4'))
                        inputCorrect = true;
                    else if ((input == 5) && (board[1, 1] == '5'))
                        inputCorrect = true;
                    else if ((input == 6) && (board[1, 2] == '6'))
                        inputCorrect = true;
                    else if ((input == 7) && (board[2, 0] == '7'))
                        inputCorrect = true;
                    else if ((input == 9) && (board[2, 1] == '8'))
                        inputCorrect = true;
                    else if ((input == 9) && (board[2, 2] == '9'))
                        inputCorrect = true;
                    else
                    {
                        Console.WriteLine("\n Incorrect input ! please use another field");
                        inputCorrect = false;
                    }
                } while (!inputCorrect);
                #endregion
            } while (true);
            Console.ReadLine();
        }

        private static void EnterXorO(char playerSign,int input)
        {
            switch (input)
            {
                case 1: board[0, 0] = playerSign; break;
                case 2: board[0, 1] = playerSign; break;
                case 3: board[0, 2] = playerSign; break;
                case 4: board[1, 0] = playerSign; break;
                case 5: board[1, 1] = playerSign; break;
                case 6: board[1, 2] = playerSign; break;
                case 7: board[2, 0] = playerSign; break;
                case 8: board[2, 1] = playerSign; break;
                case 9: board[2, 2] = playerSign; break;
                default:
                    break;
            }
        }

        static void SetField()
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Clear();
            Console.WriteLine("       |    |        ");
            Console.WriteLine("     {0} |  {1} | {2}    ", board[0, 0], board[0, 1], board[0, 2]);
            Console.WriteLine("    ___|____|____  ");
            Console.WriteLine("       |    |        ");
            Console.WriteLine("     {0} |  {1} | {2}    ", board[1, 0], board[1, 1], board[1, 2]);
            Console.WriteLine("    ___|____|____   ");
            Console.WriteLine("       |    |        ");
            Console.WriteLine("     {0} |  {1} | {2}    ", board[2, 0], board[2, 1], board[2, 2]);
            Console.WriteLine("       |    |        ");
            turns++;
        }

        public static void ResetField()
        {
              char[,] initialBoard = new char[3, 3]
        {
                {'1','2','3' },
                {'4','5','6' },
                {'7','8','9' }
        };
        board = initialBoard;
            SetField();
            turns++;
        }
    }
    }

```



### Section7 Debugging

1. we have breakpoint window to show all breakpoint
2. auto window to show all variable and their value
3. Local window to show all local variable ,i.e in the block 

4. Using Windows Prompt in Console Application
+ for this we use MessageBox ,i.e in System.Windows
+ using it we can show prompt ,alert ,or message to user and get response too from user

```c#
   MessageBoxResult box = MessageBox.Show("hello");
   //create a prompt to get response 
            MessageBoxResult box;
            MessageBoxButton btn = MessageBoxButton.YesNoCancel;
            MessageBox.Show("Yes or No", "Are you trying your best", btn);
```

5. throw Exception at the time of checking
```c#
 
            if (count > lists.Count || count <= 0)
            {
                MessageBox.Show("Error Message", "Error");

                throw new ArgumentOutOfRangeException("count", "Count cannot be greater than element in the list or less than zero");

            }
```

6. Call Stack Window
 + we can see the execution flow   
### Section8 Inheritence 

  
####  IEnumerable Interace 
+ Base interface for many Collection in C#, and it provided a way to iterate thorugh Collection.
+ eg: for List,Array
+ it has Generic IEnumerable<> and non Generic IEnumerable

1. It is better to use Generic type rather than non Generic
+ as in generic type, there is no box and unboxing
+ so it improves performance 


 2. IEnumerable<T>
 + it contains a single method that you must implement with interace
 + i.e GetEnumerator() , which returns an IEnumerator<T> object.
 + THe returned IEnumerator<T> provides the ability to iterate through the collection
 + by exposing a Current property that points at the object we are currently at in the collection 

3. Impelenting IEnumerable in a Collection object for a class
+ so now as class has access to GetEnumerator of Collection, this collection can be iterated by a foreach loop
```c#
 class DogShelter : IEnumerable<Dog>
    {
        public List<Dog> dogs;

        public DogShelter()
        {
            dogs = new List<Dog>()
                {
                    new Dog("Casper",false),
                    new Dog("Jasper",false),
                    new Dog("persi",true),
                    new Dog("Pixel",false)
                };

        }

        public IEnumerator<Dog> GetEnumerator()
        {
            return dogs.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
```

4. Demo of IEnumerable
 + Passing IEnumerable as a Method Parameter, so all Collection implementing this interface are acceptable method arguments
```c#
        static void CollectionSum(IEnumerable<int> anyCollection)
        {
            int sum = 0;

            foreach (int num in anyCollection)
            {
                sum += num;

            }

            Console.WriteLine("Sum of element in collections  is {0}",sum);

        }

```
+ IEnumerable as the return type to a method, so that we can take any object that impelement iEnumerable as a Return type.
```c#
 static IEnumerable<int> GetCollection(int option)
        {
            List<int> numberList = new List<int>() { 1, 2, 3, 4, 5, 6 };
            Queue<int> numbersQueue = new Queue<int>();
            numbersQueue.Enqueue(7);
            numbersQueue.Enqueue(8);
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

```

1. When to use IEnumerable<T>
+ your collection represent a maasive database table
+ you don't want to copy entire thing into memory ans cause performance issue

6. When not to use IEnumerable<T>
+ you need the results right away and are possibly mutating  / editing the objects later on .,
+ in this case, so better to use Array or List

### Section9: Polymorphism 

1. Between Parent and Child classes
+ here car is base class and audi and bmw are derived class
```c#
          Console.WriteLine("\n\n List of Cars \n");
            var cars = new List<Car>()
            {
                new Audi(250,"blue","A4"),
                new BMW(300,"navy blue","M2")
            };

            foreach (var vehicle in cars)
            {
                Console.WriteLine(vehicle.ShowDetails());

                vehicle.Repair();
            }

```

2. Instead of overriding we can use "new" keyword to denote to priortize this method instead of base class
```c#
class BMW: Car
{
    // assigning new , to tell to prioritize this method
     public new string ShowDetails()
        {
           return $"The car brand is  {brand}  and Model is {Model} , having {Color} color and Hp of {HP}";

        }
}
```
3. Difference between new and override keyowrd in polymorphism
+ for override
 1. if we use reference of base class and object of derive class, and call a overrided method, the derive class method is called

+ for new
 1. . if we use reference of base class and object of derive class, and call a new method, the base class method is called
 2. So, for using base class method on derive class object, we must use new keyword on methods.
 3. so, we use new, to avoid overriding .
```c#
             //BMW using new keyword on ShowDetials method
             //Audi using override keyword on ShowDetials method
            Car bmw2 = new BMW(300, "Brown", "Z-100");

            Car audi2 = new Audi(300, "light brown", "Y-100");

            BMW bmw3 = new BMW(350, "green", "Z-10");
            Console.WriteLine("Car reference BMW  : " + bmw2.ShowDetails());
          
            Console.WriteLine("Car reference audi : " + audi2.ShowDetails());

            Console.WriteLine("BMW ref and obj : " + bmw3.ShowDetails());

/* Output
Car reference BMW  :  the car color is Brown and HP is 300
Car reference audi : The car brand is  Audi  and Model is Y-100 , having light brown color and Hp of 300
BMW ref and obj : The car brand is  BMW  and Model is Z-10 , having green color and Hp of 350

/*
```
4. Sealed Keyword
+ it can be used on overrided method, so that it cannot to further inherited in derived classes

```c#
class BMW
{
    // now we cannot inherit this method in further derived classes
     public sealed override void Repair()
        {
            Console.WriteLine($"The car with brand  {brand}  and Model  {Model} is Repaired");
        }
}

```

5. Has-A relationship (Aggregator)
+ Aggregator is a  program that collects related items of content and displays  links to them
+ in IS-A relationship, we have a BMW is a Car, a Audi is a Car
+ for Has-A relation, we can use classes as datatype of our field so we can store these component as part of class

```c#
 class CarIDInfo
    {
        public int IDNUm { get; set; } = 0;

        public string Owner { get; set; } = "No Owner";

    }

    class Car
    {
        // car Has A CarIdInfo 
        protected CarIDInfo carIDInfo = new CarIDInfo();

    }


```

6. Abstract classes vs Interface class
+ **Abstract Class:** A class designed to be inherited by subclasses
+ if derived class implement same method 
+ so we must use abstract class with inherited classes
+ class inherited from abstract class, must implement the abstract method only
+ we use abstract class with inheritence, when the methods share core methodology of the class
+ abstract class can be explained as "What an object is "
```c#
abstract class Shape
    {
      

        public string Name { get; set; }

       // to be overrided, i.e so has default implementation
        public virtual void GetInfo()
        {
            Console.WriteLine($"\n This is a {Name}");
         }
         // abstract method, same as interface method, compulsory to define in derived class, no default implementation
        public abstract double Volume();
    }
```
+ **Interface :** it is a contract, and only contain method declaration and not method definition
 + we must use interface , when we have to give some common  functionality to classes , which are not related
 + interface name should start with I. 
 + we cannot create instance of interface
 + class inherited from abinterface, must implement all methods in interface
 + it like abstract class support polymorphism
+ interface can be explained as "What an object can do"
7. using is and as keyword
```c#
             foreach (Shape s in shapes)
            {
                s.GetInfo();

                // to cast to a type use as 
                 Cube iceCube = s as Cube;
                if(iceCube == null)
                    Console.WriteLine("This shape is no cube");
                    // to check a type use "is"
                else if(s is Cube)
                    Console.WriteLine("Shape is a cube");
            }

```
8. IO Operation
+ IO operation using System.IO.File class
+ Read
```c#
  // Example 1
            string text = System.IO.File.ReadAllText(Path);

            Console.WriteLine("Text file contains following text :{0}",text);

            // Example 2
            string[] lines = System.IO.File.ReadAllLines(Path);

            Console.WriteLine("Contents of textFile.txt = ");
            foreach (string line in lines)
            {
                Console.WriteLine("\t" + line);     
                        
            }
```
+ Write
```c#

  // method 1
            string[] lines = { "First : 250", "Second: 260", "Third : 300" };
            File.WriteAllLines(Path3, lines);

            // method 2
            Console.WriteLine("Add file Name");
            string fileName = Console.ReadLine();

            Console.WriteLine("Enter text to write to file {0}",fileName);
            string input = Console.ReadLine();
            File.WriteAllText(HalfPath + fileName + ".txt", input);

          // method 3

            using(StreamWriter file = new StreamWriter(HalfPath + "myText.txt"))
            {
                foreach(string line in lines)
                {
                    if(line.Contains("Third"))
                    {
                        file.WriteLine(line);
                    }
                }
            }
```

### Section10: C# Advanced Conceps

#### 0. .NET 
* There are four major components of .NET architecture:
1. Common language specification (CLS)
+ it  defines how objects are implemented so they work everywhere .NET works.
+  CLS is a subset of Common Type System (CTS) — which sets a common way to describe all types.
2. Framework class library (FCL) 
+ it is a standard library that collects reusable classes, interfaces, and value types.
3. Common language runtime (CLR)
+ it  is the virtual machine that runs the framework and manages the execution of .NET programs.
4. Tools  
+ such as Visual Studio to create standalone applications, interactive websites, web applications and web services.
* It provides services that include:
 1. Memory management
 2. Type and memory safety
 3. Security
 4. Networking
 5. Application deployment
 6. Data structures
 7. APIs

#### 1. Difference between .NET core and .NET Framework
+ **.NET Framework**
1. Developers use the .NET framework to create Windows desktop applications and server based applications. This includes ASP.NET web applications. 
2. . So use it When :
 + It is already being used.,For example, developers can write a new web service in ASP .NET Core.
 + You’re using third-party libraries or NuGet packages not available in .NET Core. 
 + You’re using technologies not yet available in .NET Core.
3. Not to use it:
 +  Multiple OS platforms are required
 + High performance and scalability are needed
 + If .NET Core works
 + Open source framework is required

+ **.NET Core** 
1. .NET Core is used to create server applications that run on Windows, Linux and Mac. 
2.  .NET Core provides a standard base library that can now be used across Windows, Linux, macOS, and mobile devices (via Xamarin)
3.  it can be used to develop applications on any platform.
 +  used for cloud applications or refactoring large enterprise applications into microservice
4. So use it When :
 +  There are cross-platform needs
 +  Microservices are being used
 +  When Docker containers are being used. 
 +  If you have high performance and scalable system needs.
 +  If you are running multiple .NET versions side-by-side. 
 +  If you want command line interface (CLI) control.

5. Not to use it:
 +  Windows Forms and WPF applications
 +  ASP.NET WebForms don’t exist.
 +  You need to create a WCF service. .
+

+ **More .NET Platforms on .NET Standards**
+ In addition to .NET Framework, .NET Core and Xamarin,foll platform:
 1. Mono
 2. Universal Windows Platform
 3. Windows Phone Silverlight(depricated)
 4. Windows Phone 


* **.Net Standards** 
+  a common set of APIs that replaces portable class libraries (PCLs). This ensures code sharing across desktop applications, mobile apps & games, and cloud services.
+  Stackify’s free code profiler, Prefix, to write better code on your workstation. 

#### 2. Access Modifiers
+ grant and prevent access
+ marking field and method with access modifier is part of OOP and icreases the safeness of your code and are an important part of encapsulation 

+ types: 
1. private: available in same class only, not outside
2. public: avaialable everywhere by creating objects
3. protected: accessible from the class and all classes that derive from it.
4. internat: accesible from its assembly(namespace and project)

+ make everything as restrictive first, i.e private and then check if working 
+ Why use it?
 * gives you full control over your methods and variables

#### 3. Structs
+ they are value type counter part of reference type class
+ they can have varable , methods, implement interface but no param less contructor
+ they do not support inheritence,
+ struct can only be public or private
+ we can only access methods of struct ,when all values are assigned.
+ cannot have null reference,unless nullable
+ do not have memory overhead per new instance unlike class

#### 4. Enums
+ these are constants used in case of integers for better readability

#### 5. Math class
```c#
  Console.WriteLine("Ceiling 15.6 : " + Math.Ceiling(15.6));
            Console.WriteLine("Floor 15.6 : " + Math.Floor(15.6));

            int num1 = 13;
            int num2 = 9;

            Console.WriteLine($"lower of {num1} and {num2} is {Math.Min(num1,num2)}");
            Console.WriteLine($"higher of {num1} and {num2} is {Math.Max(num1,num2)}");

            Console.WriteLine("3 to the power 5 is {0}",Math.Pow(3,5));

            Console.WriteLine("PI is : {0:0.0000}",Math.PI);

            Console.WriteLine("Square root of 25 is {0}",Math.Sqrt(25));
            Console.WriteLine("Always positive is {0}",Math.Abs(-123));

            Console.WriteLine("cos of 1 : {0}",Math.Cos(1));

```

#### 6. Random
+ it used to get a random value based on a range 
```c#   
  Random dice = new Random();

            int numEyes;

            for (int i = 0; i < 10; i++)
            {
                numEyes = dice.Next(1, 7);
                Console.WriteLine(numEyes);


            }
```        

####   <a href="https://docs.microsoft.com/en-us/dotnet/standard/base-types/regular-expression-language-quick-reference">7.Regular Expression </a>
+ Regular expressions provide a powerful, flexible, and efficient method for processing text. 
+ The extensive pattern-matching notation of regular expressions enables you to quickly parse large amounts of text to:
1. Find specific character patterns.
2. Validate text to ensure that it matches a predefined pattern (such as an email address).
3. Extract, edit, replace, or delete text substrings.
4. Add extracted strings to a collection in order to generate a report.

* the regular expression engine, which is represented by the
> System.Text.RegularExpressions.Regex object in .NET


+ **snippet of escape character**
```c#  
CHARACTER ESCAPES
\t 		- Matches a tab
\n 		- Matches a new line

CHARACTER CLASSES
.       - Wildcard: Matches any single character except \n.
\d      - Matches any decimal digit. (0-9)
\D      - Matches any character other than a decimal digit. (0-9)
\w      - Word Character (a-z, A-Z, 0-9, _)
\W      - Not a Word Character
\s      - Matches any white-space character. (space, tab, newline)
\S      - Matches any non-white-space character (space, tab, newline)
[character_group]     - Matches any single character in character_group. By default, the match is case-sensitive.
[^character_group]    - Negation: Matches any single character that is not in character_group. By default, characters in character_group are case-sensitive.

ANCHORS
^       - The match must start at the beginning of the string or line.
$       - The match must occur at the end of the string or before \n at the end of the line or string.
\A		- The match must occur at the start of the string.
\Z 		- The match must occur at the end of the string or before \n at the end of the string.
\b      - Word Boundary
\B      - Not a Word Boundary

ALTERNATION CONSTRUCTS
|       - Either Or

GROUPING CONSTRUCT
( )     - Group

Quantifiers:
*       - Matches the previous element zero or more times.
+       - Matches the previous element one or more times.
?       - Matches the previous element zero or one time.
{n}     - Matches the previous element exactly n times.
{n,m}   - Matches the previous element at least n times, but no more than m times.

```

+ Meta character need to be escaped
> .[{()\^$|?*+


+ Examples
```c#
1. How to get
202-555-0102
202-555-0196
> \d{3}-\d{3}-\d{4}

2. How to get 
202-555-0102
202-555-0196
202.555.0196
202#555#0196
> \d{3}[.#-]\d{3}[.#-]\d{4}

3. How to get 
0175/12345678
+49165/12312347
0049165/12312347
> \+?\d{4,7}/\d{8}
> (\+49)|(0049)|0?1(6|7)\d/\d{8} [tutor solution]

4. How to get
Indian mobile no
09881327553
+918668951369
+0253 2376923
> (0)|\+91|\+\d{4}|\d{7,10}

5. How to get

Mr. Panjuta
Mr Muller
Mr Robertson
Mr. G
> Mr.?\s\w+

6. How to get
// Challenge - find website links
https://www.tutorials.eu
https://tutorials.eu
http://www.tutorials.eu
http://tutorials.eu

> https?://(www.)?\w{9}.eu
> https?://(www.)?(\w+)(\.\w+)              [tutor solution]
```
+ se the System.Net.Mail.MailAddress class. To determine whether an email address is valid, pass the email address to the MailAddress.MailAddress(String) class constructor.
+ regex for email
```bash
^(?(")(".+?(?<!\\)"@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$
```
+ regex in c#
```c#
           string pattern = @"\d{7}";
            Regex regex = new Regex(pattern);

            string text = "Hi , my number is 1321424";
            MatchCollection matchCollection = regex.Matches(text);
            Console.WriteLine("{0} hits found : {1}",matchCollection.Count,text);

            foreach (Match match in matchCollection)
            {
                GroupCollection group = match.Groups;


                Console.WriteLine($"{group[0].Value} found at {group[0].Index} ");


            }

```
#### 7. DateTIme

```c#
 static void Main(string[] args)
        {
            DateTime dateTime = new DateTime(1994, 1, 1);
           

            Console.WriteLine("My birthday is {0}",dateTime);

            // todays date
            Console.WriteLine(DateTime.Today);
            // todays time
            Console.WriteLine(DateTime.Now);

            DateTime tommorrow = GetTommorrow();
            Console.WriteLine("Tommorow will be  "+ tommorrow);

            DayOfWeek dayOfWeek = DateTime.Now.DayOfWeek;
            Console.WriteLine("today is {0} ",dayOfWeek);
            Console.WriteLine("first day of year 1994 is {0}",FirstDayOfAYear(1994).DayOfWeek);


            int days = DateTime.DaysInMonth(2000, 2);
            Console.WriteLine("Days in Feb,2000 are {0}",days);
            days = DateTime.DaysInMonth(2001, 2);
            Console.WriteLine("Days in Feb,2001 are {0}", days);

            DateTime now = DateTime.Now;
            Console.WriteLine("Minutes : {0}",now.Minute);

            // display time in x o'clock and y minutes and z seconds 


            Console.WriteLine($"{now.Hour} o'clock and {now.Minute} minutes and {now.Second} seconds");

            // time between two dates
            Console.WriteLine("Enter your BirthDate  in this format: yyyy-mm-dd");
            string input = Console.ReadLine();

            if(DateTime.TryParse(input,out dateTime))
            {
                Console.WriteLine(dateTime);
                TimeSpan daysPassed = DateTime.Now.Subtract(dateTime);
                Console.WriteLine("Days passed Since : {0}",daysPassed.Days);
            }else
            {
                Console.WriteLine("Wrong input");
            }
            Console.ReadLine();
        }

        static DateTime GetTommorrow()
        {
            return DateTime.Today.AddDays(1);
                
        }

        static DateTime FirstDayOfAYear(int year)
        {
            return new DateTime(year, 1, 1);
        }

```

#### 8. Nullable
+ it is a datatype ,which can store null values,used while dealing with database as we can get null values , for empty entries in database
+ we can convert nullable to value type using casting , but preferred way is using "??" null coleasing operator 

```c#
 int? num1 = null;
            // error as value type cant store null
            //  int num2 = null;

            double? num3 = new double?();
            double? num4 = 3.14;
            bool? boolval = new bool?();
            int num5;
            Console.WriteLine($"our nullable numbers are {num1},{num3},{num4}, bool value: {boolval}");

            bool? isMale = null;

            if(isMale == true)
            {
                Console.WriteLine("User is male");

            }else if(isMale == false)
            {
                Console.WriteLine("user is female");
            }else
            {
                Console.WriteLine("No gender choosen");
            }

            //convert nullable to non -nullable

            double? num6 = 13.1;
            double? num7 = null;

            double num8;

            if (num6 == null)
            {

                num8 = 0.0;
            }else
            {
                num8 = (double)num6;

            }

            Console.WriteLine("value of num8 is : {0}",num8);
            
            // from null to non-nullable type 
            // null coleasing operator ??
            num8 = num6 ?? 8.53;
            Console.WriteLine("value of num8 is : {0}", num8);
            num8 = num7 ?? 10;
            Console.WriteLine("value of num8 is : {0}", num8);

            Console.WriteLine(" hi \n hello ");
            Console.WriteLine(@" hi \n hello ");

```

#### 9. Garbage Collection
+ .NET provides automatic memory management.
+ we create object in our program , which occupy memory on system.memory pool,
+  and in our program we use reference to access that memory , so if we set the reference as null, the memory becomes inaccessible , so 
+  now we need garbage collection to happen, in .NET it takes place automatically
+  we can implement finalizer method to execute code just before an object is released from memory by the GC.

* When GC run?
 1. when system has low physical memory
 2. when memory allocated exceed a pre-set threshold
 3. when GC.Collect() is called

#### 10. Main Args
+ used to pass arguements to program before execution starts
```c#
 static void Main(string[] args)
        {
            if(args.Length == 0)
            {
                Console.WriteLine("no args passed to program,pass Help to get detail");
            }else
             Console.WriteLine("Hello {0}", args[0]);

            

            if(args[0].ToLower() == "help")
              Console.WriteLine("*************Instructions: ");
            bool isNum1Parsed = float.TryParse(args[1], out float num1);
            bool isNum2Parsed = float.TryParse(args[2], out float num2);

            float result = 0;
            if(isNum1Parsed && isNum2Parsed)
            {
                switch (args[0])
                {
                    case "add":
                        result = num1 + num2;
                        break;
                    case "sub":
                        result =  num1 - num2;
                        break;
                    default:
                        break;
                }

           Console.WriteLine($"the {args[0]} of {num1} and {num2} = {result}");

            }
           
```

### Section 11: Event and Delegates 

1. Delegate
+ A delegate is a type that can hold a reference to a method
+ when you call delegate, the method it is referencing get called

```c#
class SendButton
{

//property
 public string text

//delegate:
private delegate void OnCLickDelegate();
}


void SendButtonClick()
{
    // code to execute
}
static void Main(string[] args)
{
 SendButton.OnCLick = SendButtonCLick; // delegate store reference of method 

 if(isMouseHovering && isLeftClickPressed)
 {
    SendButton.OnClick(); // delegate call method
 }
}



```

+ using given delegate
```c#
         static void Main(String[] args)
         {  List<string> names = new List<string>() { "suraj", "raj", "elon", "steve jobs" };

        
            // calling RemoveAll and passsing a method Filter we created as a method reference 
            names.RemoveAll(FilterMethod);
        }
         static bool FilterMethod(string name)
        {
            return name.Contains("o");
        }

```
2. Creating and using delegate

```c#
 }

        //defining a delegate type Filter with return type bool and Person as method argument
        public delegate bool FilterPersonDelegate(Person P);
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>
            {
                new Person{Name="Suraj",Age=27},
                new Person{Name="raj",Age=12}
            };
          // we can directly pass a method of delegate type as argument , rather than passing a delegate instance
            DisplayPeople("Kids", people,IsMinor);
            DisplayPeople("Adult", people,IsAdult);
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
     // methods to pass to delegate
        static bool IsMinor(Person p)
        {
            return p.Age < 18;
        }

        static bool IsAdult(Person p)
        {
            return p.Age > 18 ;
        }
          

```

3. Anonymous Method 
+ a method without a name, can be defined with a delegate keyword and assigned to a delegate type 
+ use for one time use delegate method
+ + so we can use A M , to write methods inline 
```c#
  // creating anonymous method and assigning to delegate.
            FilterPersonDelegate filter = delegate (Person p)
            {
                return p.Age >= 18 && p.Age <= 65;
            };
            Console.WriteLine("using anonymous method");

            DisplayPeople("Adults anonymous ", people, filter);

            DisplayPeople("All : ",people, delegate(Person p) { return true;});
            
```
4. Lambda Expression
+  simple and compact function syntex to write anonymous methods
+ lambda declaration operator : =>
+ it is called as "goes into" or "goes to"
+ there are 2 types of lambda
 1. Expression Lambda 
 2.  Statement Lambda
+ syntax 
```c#
//Expression Lambda 
(input-parameters) => expression

// Statement Lambda 
(input-parameters) => { // sequence of statements
                      }

```
+ example
```c#

    // method we use 
  private static void DisplayPeople(string title, List<Person> people, FilterPersonDelegate filter);

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
            DisplayPeople("exactly 25 ", people, p => p.Age == 25);


```
+ Delegate allows a direct assignment 
> myDelegate = myMethod
+ Delegate can be triggered from outside the class that defines it . 


1. Event and MultiCast Delegate
+ Multi cast Delegate are delegate which work as a list which  can store a list of reference to methods  
+ creating a delegate in a class and subscribing it in to a number of method creates a multicast delegate 
+ use when we have multiple methods having same signature run at same time like GameStart and GameOver
```c#



// here game class has one delegate GameEvent and 2 variable of it , to which we can add methods
class GameEventManager
    {

        // create a new delegate
        public delegate void GameEvent();

        // create two variable of delegate
      public static  GameEvent OnGameStart, OnGameOver;

     // a static method to trigger OnGameStart
   // here we check if event is subscribed to , if yes we run all the method subscribed
        public static void TriggerGameStart()
        {
            // check if the OnGameStart event is not empty, meaning the other methods already subscribed
            if(OnGameStart != null)
            {
                Console.WriteLine("the game has started...");

                // call the OnGameStart that will trigger all the methods subscribed to this event
                OnGameStart();
            }
        }

        public static void TriggerGameOver()
        {
            if(OnGameOver != null)
            {
                Console.WriteLine("the game is over");
                OnGameOver();

            }
        }
    }

  class Player
    {
        public string PlayerName { get; set; }

        public Player(string playerName)
        {
            PlayerName = playerName;
            // subscribing method to delegate 
            GameEventManager.OnGameStart += StartGame;

            GameEventManager.OnGameOver += GameOver;
        }
        
        publc void GameStart() {}
        publc void GameOver() {}
     }


```

* **Events:**
+ if we dont want any way to override subscirbe methods , then we can use Event instead of delegate
+ it is done by using event keyword instead of delegate keyword in program
+ Event is a special type of delegate , on which we can only subcribe to event using +=  so no way to override previous subscription
+ so events are forced to behave like a list by += / -= 
+ ***Events can't be triggered from outside the class that defines them.***
  
```c#
 class GameEventManager
    {

        // create a  delegate to show signature of  what type of method can be subscribed 
        public delegate void GameEvent();

        // create two event variable of delegate to provide isntance to subscibe to 
      public static event  GameEvent OnGameStart, OnGameOver;
   public static void TriggerGameStart()
        {
            // check if the OnGameStart event is not empty, meaning the other methods already subscribed
            if(OnGameStart != null)
            {
                Console.WriteLine("the game has started...");

                // call the OnGameStart that will trigger all the methods subscribed to this event
                OnGameStart();
            }
        }

        public static void TriggerGameOver()
        {
            if(OnGameOver != null)
            {
                Console.WriteLine("the game is over");
                OnGameOver();

            }
        }
    } 

```

+ how to use events
```c#
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

            Console.WriteLine("Using Multicast Delegate");

            GameEventManager.TriggerGameStart();

            Console.WriteLine("Game is running, press any key to end the game");
            Console.ReadLine();

            GameEventManager.TriggerGameOver();

            Console.ReadLine();
        }


```


### Section 16. Threads

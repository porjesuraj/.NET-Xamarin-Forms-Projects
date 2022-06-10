using _9.Polymorphism.AbsractClasses;
using _9.Polymorphism.Inheritence_Challenge_Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9.Polymorphism
{
    class Program
    {

        /* #region Polymorphism 1: 

static void Main(string[] args)
{

Console.ReadLine();
}


#endregion*/
        #region Polymorphism 6: FIle IO write Operation 
        private const string Path2 = @"C:\Users\surajpor\Desktop\DotNet_Course\Assets\textFile2.txt";
        private const string Path3 = @"C:\Users\surajpor\Desktop\DotNet_Course\Assets\HighScores.txt";
        private const string HalfPath = @"C:\Users\surajpor\Desktop\DotNet_Course\Assets\";
        static void Main(string[] args)
        {
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

        }


        #endregion
        #region Polymorphism 5: File IO Read Operation 
        private const string Path = @"C:\Users\surajpor\Desktop\DotNet_Course\Assets\textFile.txt";

        static void Main5(string[] args)
        {
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
            Console.ReadLine();
        }


        #endregion



        #region Polymorphism 4: Abstract classes 

        static void Main4(string[] args)
        {
            Cube cube = new Cube(10);
            Shape cubeShape = new Cube(20);
            Sphere sphere = new Sphere(20);

            cube.GetInfo();

            cubeShape.GetInfo();


            sphere.GetInfo();

            Console.WriteLine("Array of Shapes \n");

            Shape[] shapes = { new Sphere(5), new Cube(3) };

            foreach (Shape s in shapes)
            {
                s.GetInfo();

                Cube iceCube = s as Cube;
                if(iceCube == null)
                    Console.WriteLine("This shape is no cube");
                else if(s is Cube)
                    Console.WriteLine("Shape is a cube");


                object cube1 = new Cube(7);
                Cube cube2 = (Cube) cube1;



                cube2.GetInfo();

            }

            Console.ReadLine();
        }
        #endregion
        #region Polymorphism 3: Has-A Relationship 

        static void Main3(string[] args)
        {
            Car bmw = new BMW(200, "black", "SX-100");
            bmw.SetCarIDInfo(123, "Suraj");

            bmw.GetCarIdInfo();

            Console.ReadLine();
        }
        #endregion

        #region Polymorphism 2: Sealed keyword 

        static void Main2(string[] args)
        {

            M3 myM3 = new M3(270, "gray", "SuperTurbo");

            myM3.Repair();
            Console.ReadLine();
        }
        #endregion
        #region Polymorphism 1: Inheritence Challenge

        static void Main1(string[] args)
        {
            Car car = new Car(100,"Red");

            BMW bmw = new BMW(200, "Black", "SX-400");

            Audi audi = new Audi(200, "White", "AUX-2020");

            Console.WriteLine(car.ShowDetails());
            car.Repair();

            Console.WriteLine(bmw.ShowDetails());
            bmw.Repair();

            Console.WriteLine(audi.ShowDetails());
            audi.Repair();

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

            Console.WriteLine("\n\n use of new keyword on bmw method \n");

            Car bmw2 = new BMW(300, "Brown", "Z-100");

            Car audi2 = new Audi(300, "light brown", "Y-100");

            BMW bmw3 = new BMW(350, "green", "Z-10");
            Console.WriteLine("Car reference BMW  : " + bmw2.ShowDetails());
          
            Console.WriteLine("Car reference audi : " + audi2.ShowDetails());

            Console.WriteLine("BMW ref and obj : " + bmw3.ShowDetails());

            Console.ReadLine();
        }
        #endregion

    }
}

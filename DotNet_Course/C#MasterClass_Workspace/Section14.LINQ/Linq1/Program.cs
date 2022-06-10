using Linq1.LinqClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq1
{
    class Program
    {


        #region UniversityManager Class Methods 

        #endregion
        static void Main(string[] args)
        {
            UniversityManager universityManager = new UniversityManager();
            universityManager.MaleStudents();
            universityManager.GetFemaleStudents();
            universityManager.SortStudentByAge();


            universityManager.AllStudentFromYale();

            Console.WriteLine();

            universityManager.GetAllStudentFromUniversityId(1);
            Console.WriteLine();
            universityManager.GetAllStudentFromUniversityId(2);
            Console.WriteLine();
            universityManager.GetAllStudentFromUniversityId(3);

            Console.WriteLine("Another way to sort");

            int[] someInts = { 30, 10, 20, 4, 5, 50 };
            IEnumerable<int> sortInts = from i in someInts orderby i select i;
            Console.WriteLine("Array sorted in asc order : ");

            foreach (int i in sortInts)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();


            IEnumerable<int> reverseInts = sortInts.Reverse();
           // IEnumerable<int> reverseInts = from i in someInts orderby i descending select i;

            Console.WriteLine("Array sorted in desc order : ");
            foreach (int i in reverseInts)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();


            Console.WriteLine("List Student and University");

            universityManager.StudentAndUniversityNameCollection();

            Console.ReadLine();
        }






        #region Find Odd Number from a Array
        static void Main1(string[] args)
        {
            int[] numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            OddNumbers(numbers);

            Console.ReadLine();
        }

        static void OddNumbers(int[] numbers)
        {
            Console.WriteLine("Odd Numbers :");
            IEnumerable<int> oddNumbers = from number in numbers
                                          where number % 2 != 0
                                          select number;
            foreach (var i in oddNumbers)
            {
                Console.WriteLine(i);
            }


        }

        #endregion

    }
}

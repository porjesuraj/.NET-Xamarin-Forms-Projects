using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq1.LinqClasses
{
    class UniversityManager
    {
        public List<University> universities { get; set; }
        public List<Student> students { get; set; }

        public UniversityManager()
        {
            universities = new List<University>()
                {
                    new University{Id = 1, Name = "Yale"},
                    new University{Id = 2, Name = "Oxford"},
                };
            students = new List<Student>()
                {
                    new Student{Id = 1, Name = "Ajay",Gender = "male",Age = 24, UniversityId = 1},
                    new Student{Id = 2, Name = "Raj",Gender = "male",Age = 25, UniversityId = 1},
                    new Student{Id = 3, Name = "Shiv",Gender = "male",Age = 24, UniversityId = 2},
                    new Student{Id = 4, Name = "Krishna",Gender = "male",Age = 26, UniversityId = 2},
                    new Student{Id = 5, Name = "Tej",Gender = "male",Age = 23, UniversityId = 1},
                    new Student{Id = 5, Name = "Tejashri",Gender = "female",Age = 23, UniversityId = 2},
                    new Student{Id = 5, Name = "James",Gender = "trans-gender",Age = 23, UniversityId = 2},

                };




        }

        public void MaleStudents()
        {
            IEnumerable<Student> maleStudents = from student in students
                                                where student.Gender == "male"
                                                select student;
            Console.WriteLine("Male Students : ");

            foreach (Student student in maleStudents)
            {
                student.Print();
            }
            Console.WriteLine();
        }


        public void GetFemaleStudents()
        {
            IEnumerable<Student> femaleStudents = from student in students
                                                  where student.Gender == "female"
                                                  select student;
            Console.WriteLine("Female Students : ");
            foreach (Student student in femaleStudents)
            {
                student.Print();
            }
        }
     
        public void SortStudentByAge()
        {
            var sortStudents = from student in students orderby student.Age select student;
            Console.WriteLine("Students sorted by age : ");

            foreach (Student student in sortStudents)
            {
                student.Print();
            }
        }


        public void AllStudentFromYale()
        {

            IEnumerable<Student> yaleStudents = from student in students
                                                join university in universities
                                                on student.UniversityId equals university.Id
                                                where university.Name == "Yale"
                                                select student;

            Console.WriteLine("Yale Students : ");

            foreach (Student s in yaleStudents)
            {
                s.Print();
            }
        }


        public void GetAllStudentFromUniversityId(int id)
        {

            IEnumerable<Student> uniStudents = from student in students
                                                join university in universities
                                                on student.UniversityId equals university.Id
                                                where university.Id == id
                                                select student;

            string universityName = String.Empty;

            if (id == 1)
                universityName = "Yale";
            else if (id == 2)
                universityName = "Oxford";
            else
            {
                Console.WriteLine("Wront input");
                return;
            }    


            Console.WriteLine("{0} University  student : ", universityName);

            foreach (Student s in uniStudents)
            {
                s.Print();
            }
        }
    
        public void StudentAndUniversityNameCollection()
        {
            var newCollection = from s in students
                                join u in universities
                                 on s.UniversityId equals u.Id
                                orderby s.Name
                                select new { StudentName = s.Name, UniversityName = u.Name };

            Console.WriteLine("new Collection of student and university");

            foreach (var col in newCollection)
            {
                Console.WriteLine($"Student {col.StudentName} from University {col.UniversityName}");

            }
        }

    }
}

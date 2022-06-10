using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LinqWithXML
{
    class Program
    {
        static void Main(string[] args)
        {
            string studentsXMl =
 @"<Students>
	<Student>
		<Name>Toni</Name>
		<Age>23</Age>
		<University>Yale</University>
		<SportsPlayed>Football</SportsPlayed>
	</Student>
	<Student>
		<Name>Jake</Name>
		<Age>25</Age>
		<University>Oxford</University>
		<SportsPlayed>Cricket</SportsPlayed>

	</Student>
	<Student>
		<Name>Rice</Name>
		<Age>26</Age>
		<University>Carla</University>
		<SportsPlayed>BasketBall</SportsPlayed>

	</Student>

	<Student>
		<Name>Shanaracharya</Name>
		<Age>56</Age>
		<University>TakshaShila</University>
		<SportsPlayed>Chess</SportsPlayed>

	</Student>
</Students>";
			// create an XML document 
			XDocument studentsXDoc = new XDocument();
			studentsXDoc = XDocument.Parse(studentsXMl);
			// create Student object from xml
			var students = from student in studentsXDoc.Descendants("Student")
						   select new
						   {
							   Name = student.Element("Name").Value,
							   Age = student.Element("Age").Value,
							   University = student.Element("University").Value,
							   SportsPlayed =student.Element("SportsPlayed").Value

						   };

            foreach (var i in students)
            {
                Console.WriteLine($"Student {i.Name} , Age {i.Age} in {i.University} University, Plays  {i.SportsPlayed}");
            }

            Console.WriteLine("Student Sorted By Age");
			var SortedByAge = from student in studentsXDoc.Descendants("Student")
							  orderby student.Element("Age").Value
							  select new
							  {
								  Name = student.Element("Name").Value,
								  Age = student.Element("Age").Value,
								  University = student.Element("University").Value,
								  SportsPlayed = student.Element("SportsPlayed").Value

							  };

			foreach (var i in SortedByAge)
			{
				Console.WriteLine($"Student {i.Name} , Age {i.Age} in {i.University} University, Plays  {i.SportsPlayed}");

			}

			Console.ReadLine();

        }
    }
}

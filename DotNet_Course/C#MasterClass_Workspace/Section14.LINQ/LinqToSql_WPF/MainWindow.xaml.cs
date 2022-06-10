using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LinqToSql_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        LinqToSqlDataClassesDataContext dataContext;

        public MainWindow()
        {
            InitializeComponent();

            string connectionString = ConfigurationManager.ConnectionStrings["LinqToSql_WPF.Properties.Settings.SurajTrainingDBConnectionString"].ConnectionString;

            dataContext = new LinqToSqlDataClassesDataContext(connectionString);

            // InsertUniversities();
            //InsertStudents();

            //InsertLecture();
            //InsertStudentLectureAssociations();
            // GetUniversityOfStudent();/
            //GetStudentLectures();
            //GetAllStudentFromYaleUniversity();
            //GetAllStudentFromOxfordUniversity();

            // GetAllLecutresTaughtAtUniversity();
            //UpdateRaj();
            DeleteAjay();
        }
        public void InsertUniversities()
        {

            dataContext.ExecuteCommand("delete from University");

            University yale = new University();
            University oxford = new University();

            oxford.Name = "Oxford";

            yale.Name = "Yale";

            
            dataContext.Universities.InsertOnSubmit(yale);
            dataContext.Universities.InsertOnSubmit(oxford);


            dataContext.SubmitChanges();

            MainDataGrid.ItemsSource = dataContext.Universities;
        }
        public void InsertStudents()
        {
            dataContext.ExecuteCommand("delete from  Student");

            University yale = dataContext.Universities.First(un => un.Name.Equals("Yale"));
            University oxford= dataContext.Universities.First(un => un.Name.Equals("Oxford"));

            List<Student> studentList = new List<Student>()
            {
                 new Student() {Name = "Raj",Gender = "Male",UniversityId = yale.Id,University = yale },
                 new Student() {Name = "Ajay",Gender = "Male",UniversityId = yale.Id,University = yale },
                 new Student() {Name = "Suraj",Gender = "Male",UniversityId = oxford.Id,University = oxford },
                 new Student() {Name = "Dhiraj",Gender = "Male",UniversityId = oxford.Id,University = oxford },
                 new Student() {Name = "jame",Gender = "trans-gender",UniversityId = oxford.Id,University = oxford }
            };
           

            dataContext.Students.InsertAllOnSubmit(studentList);

            dataContext.SubmitChanges();

            MainDataGrid.ItemsSource = dataContext.Students;



        }

        public void InsertLecture()
        {
            dataContext.ExecuteCommand("delete from Lecture");
            List<Lecture> lecutes = new List<Lecture>
            {
                new Lecture{Name = "Finance"},
                new Lecture{Name = "Maths"},
                new Lecture{Name = "DSA"},
                new Lecture{Name = "Project Building"},
                new Lecture{Name = "Communication Skill"}
            };

            dataContext.Lectures.InsertAllOnSubmit(lecutes);

            dataContext.SubmitChanges();
            MainDataGrid.ItemsSource = dataContext.Lectures;
            
        }
    
        public void InsertStudentLectureAssociations()
        {
            Student Raj = dataContext.Students.First(st => st.Name.Equals("Raj"));
            Student Ajay = dataContext.Students.First(st => st.Name.Equals("Ajay"));
            Student Suraj = dataContext.Students.First(st => st.Name.Equals("Suraj"));
            Student Dhiraj = dataContext.Students.First(st => st.Name.Equals("Dhiraj"));
            Student Jame= dataContext.Students.First(st => st.Name.Equals("jame"));

            Lecture Finance = dataContext.Lectures.First(l => l.Name.Equals("Finance"));
            Lecture Maths = dataContext.Lectures.First(l => l.Name.Equals("Maths"));
            Lecture DSA = dataContext.Lectures.First(l => l.Name.Equals("DSA"));
            Lecture ProjectBuilding = dataContext.Lectures.First(l => l.Name.Equals("Project Building"));
            Lecture CommunicationSkill = dataContext.Lectures.First(l => l.Name.Equals("Communication Skill"));


            List<StudentLecture> studentLectures = new List<StudentLecture>()
            {
                new StudentLecture{Lecture = Finance,LectureId = Finance.Id,Student = Raj,StudentId = Raj.Id},
                new StudentLecture{Lecture = Finance,LectureId = Finance.Id,Student = Suraj,StudentId = Suraj.Id},
                new StudentLecture{Lecture = Finance,LectureId = Finance.Id,Student = Dhiraj,StudentId = Dhiraj.Id},

                new StudentLecture{Lecture = Maths,Student = Raj},
                new StudentLecture{Lecture = Maths,Student = Suraj},
                new StudentLecture{Lecture = Maths,Student = Dhiraj},
                new StudentLecture{Lecture = Maths,Student = Jame}
            };

            dataContext.StudentLectures.InsertAllOnSubmit(studentLectures);

            dataContext.SubmitChanges();

            MainDataGrid.ItemsSource = dataContext.StudentLectures;

        
        }
    

        public void GetUniversityOfStudent()
        {
            Student Raj = dataContext.Students.First(St => St.Name.Equals("Raj"));

            University RajUniversity = Raj.University;
           
            List<University> universities = new List<University>();
            universities.Add(RajUniversity);
            MainDataGrid.ItemsSource = universities;
        }

       public void GetStudentLectures()
        {
            Student Raj = dataContext.Students.First(st => st.Name.Equals("Raj"));

            var rajLectures = from s in Raj.StudentLectures select s.Lecture;

            MainDataGrid.ItemsSource = rajLectures;

        }
    
        public void  GetAllStudentFromYaleUniversity()
        {
            var students = dataContext.Students.Where(s => s.University.Name == "Yale").ToList();

            MainDataGrid.ItemsSource = students;
        }

        public void GetAllStudentFromOxfordUniversity()
        {
            var students = from s in dataContext.Students
                           where s.University.Name == "Oxford"
                           select s;

            MainDataGrid.ItemsSource = students;
        }

        public void GetAllUniversitiesWithTransgenders()
        {
            var uniWithTrans = from s in dataContext.Students
                               join u in dataContext.Universities
                               on s.University equals u
                               where s.Gender == "trans-gender"
                               select u;

            MainDataGrid.ItemsSource = uniWithTrans;
        }

        public void GetAllLecutresTaughtAtUniversity()
        {
            var lectureTaughtAtYale = from s in dataContext.Students
                                      join sl in dataContext.StudentLectures
                                      on s.Id equals sl.StudentId
                                      where s.University.Name =="Yale"
                                      select sl.Lecture;
            MainDataGrid.ItemsSource = lectureTaughtAtYale;

        }


        public void UpdateRaj()
        {
            Student Raj = dataContext.Students.FirstOrDefault(st => st.Name == "Raj");

            Raj.Name = "Rajkumar";

            dataContext.SubmitChanges();

            MainDataGrid.ItemsSource = dataContext.Students;
        }

        public void DeleteAjay()
        {
            Student Ajay = dataContext.Students.FirstOrDefault(st => st.Name == "Ajay");

            dataContext.Students.DeleteOnSubmit(Ajay);

            dataContext.SubmitChanges();
            MainDataGrid.ItemsSource = dataContext.Students;

        }
    }
}

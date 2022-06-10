using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.OOPS.Members_Basics
{
    class Members
    {

        // member private field 
        private string memberName;
        private string jobTitle;

        // member public field 
        public int age;


        //member property - exposes jobTitle safely - properties srtart with capital letter
        public string JobTitle
        {
            get
            {
                return jobTitle;
            }
            set
            {
                jobTitle = value;
            }
        }

        private int salary ;

        // member Constructor 
        public Members()
        {
            age = 27;
            memberName = "Suraj";
            salary = 1000000;
            jobTitle = "Developer";


            Console.WriteLine("Object Created");
        }

        // member - finalizer - destructor 
        // we can create only one destructor per class
        // desctructor cannot be overloaded, inherited, or called

        ~Members()
        {
            //cleanup statement 
          
            Debug.Write("Destruction of Members Object");

        }


        //public member Method - can be called from other classes
        public void Introducing (bool isFriend)
        {
      
            if(isFriend)
            {
                SharingPrivateInfo();
            }
            else
            {
                Console.WriteLine("Hi,my Name is {0},my jobtitle is {1},I'm {2} years old",memberName,JobTitle,age);
            }
        }

        private void SharingPrivateInfo()
        {
            Console.WriteLine("My salary is {0}",salary);
        }
         

    }
}

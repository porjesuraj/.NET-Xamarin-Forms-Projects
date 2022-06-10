using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.OOPS.Classes_Basics
{
    class Human
    {
        //member variable 

       public string firstName ;

        public string lastName  ;

        private string eyeColor ;

        private int age;

        public Human()
        {
            Console.WriteLine("Default Constructor called,Object Created");
        }

        // parameterized constructor 
        public Human(string firstName,string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;

        }

        public Human(string firstName)
        {
            this.firstName = firstName;
           

        }


        public Human(string firstName, string lastName, string eyeColor, int age) : this(firstName, lastName)
        {
            this.eyeColor = eyeColor;
            this.age = age;
        }

        //member 
        public void IntroduceMyself()
        {
            if(string.IsNullOrEmpty(eyeColor))
                 Console.WriteLine("Hi, I'm {0} {1}",firstName,lastName);
            else if(string.IsNullOrEmpty(lastName))
                   Console.WriteLine("Hi, I'm {0}", firstName);
            else
                Console.WriteLine("Hi, I'm {0} {1}, my  age is {2} and my eyecolor is {3}", firstName, lastName,age,eyeColor);

        }
    }
}

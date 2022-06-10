using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace _8.Inheritence.AnimalClasses
{
    class Animal
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public bool IsHungry { get; set; }

        public Animal(string name, int age)
        {
            Name = name;
            Age = age;
            IsHungry = true;
        }

        public virtual void MakeSound()
        {
            if(IsHungry)
            {
                Console.WriteLine($"{Name} is Hungry and Making Sound");
                MessageBox.Show($"{Name} is Hungry");

            }else
            {
                Console.WriteLine($"{Name} is not Hungry and not  Making Sound");
                MessageBox.Show($"{Name} is not Hungry");
            }
        }

        public virtual void Eat()
        {

            if (IsHungry)
            {
                Console.WriteLine($"{Name} is Eating ");
                MessageBox.Show($"{Name} is Eating");

            }
            else
            {
                Console.WriteLine($"{Name} is not Hungry ");
                MessageBox.Show($"{Name} is not hungry");
            }
        }

        public virtual void Play()
        {
            Console.WriteLine($"{Name} is Playing");
        }
    }
}

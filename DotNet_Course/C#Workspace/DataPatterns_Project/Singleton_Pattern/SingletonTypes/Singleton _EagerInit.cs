using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton_Pattern
{

    /// <summary>
    /// creating singleton class using the class Property, its good for working with single thread,
    /// if used in  multi-threads application , it result in race condition 
    /// </summary>
    /// 

    // sealed restricts the inheritence 
   public sealed class Singleton_Eager
    {

        private static int counter = 0;

     

        /// <summary>
        /// public property is used to return only one instance of the class
        /// levereging on the private property
        /// as we instantiate the variable at start using readonly keyword so its eager loading 
        /// as its static readonly we cannot assign a new value to it, so no new instance can be created
        /// </summary>
        private static readonly Singleton_Eager instance = new Singleton_Eager();

        /// <summary>
        /// here no lock is needed as CLR takes care of variable initialization and thread safety
        /// </summary>

        public static Singleton_Eager GetInstance
        {
            get
            {
                
                return instance;
            }
        }


        /// <summary>
        /// private constructor ensures that object is not created outside the class
        /// </summary>
        private Singleton_Eager()
        {
            counter++;
            Console.WriteLine("insance of class are {0}",counter);
        }



        /// <summary>
        /// Public method which can be invoked through the singleton instance
        /// </summary>
        /// <param name="message"></param>
        public void PrintDetials(string message)
        {
            Console.WriteLine(message);
        }

        #region Inner class to show what if class is not sealed
        /*public class DerivedSingleton : Singleton
      {

      }*/
        #endregion

    }



}

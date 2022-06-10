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
   public sealed class Singleton_Lazy
    {

        private static int counter = 0;

     

        /// <summary>
        /// public property is used to return only one instance of the class
        /// levereging on the private property,
        /// as lazy<> objects are thread safe, so we dont need to use lock here even in lazy loading
        /// </summary>
        private static readonly Lazy<Singleton_Lazy> instance = new Lazy<Singleton_Lazy>(() => new Singleton_Lazy());

        public static Singleton_Lazy GetInstance
        {
            get
            {
                
                return instance.Value;
            }
        }


        /// <summary>
        /// private constructor ensures that object is not created outside the class
        /// </summary>
        private Singleton_Lazy()
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

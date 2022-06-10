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
   public sealed class Singleton
    {

        private static int counter = 0;

        private static readonly object obj = new object();

        /// <summary>
        /// public property is used to return only one instance of the class
        /// levereging on the private property
        /// </summary>
        private static Singleton instance = null;

        public static Singleton GetInstance
        {
            get
            {
                // double check locking ,as lock checking is a heavy process
                if (instance == null)
                {

                    // lock object so that only one thread can access the code at a time 
                    lock (obj)
                    {
                        if (instance == null)
                            instance = new Singleton();
                    }
                }
                return instance;
            }
        }


        /// <summary>
        /// private constructor ensures that object is not created outside the class
        /// </summary>
        private Singleton()
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

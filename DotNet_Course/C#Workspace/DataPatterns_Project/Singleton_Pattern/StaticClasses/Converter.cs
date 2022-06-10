using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton_Pattern.StaticClasses
{

    
    
   public static class Converter 
    {

       
        public static double ToFarenheit(double celcius)
        {
            return (celcius * 9 / 5) + 32; 
        }

        public static double ToCelcius(double farenheit)
        {
            return (farenheit - 32) * 5 / 9;
        }
    }
}

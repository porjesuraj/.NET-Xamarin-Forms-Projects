using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static SingletonDemo_Web.Factory.AbstractFactory.Enumerations;

namespace SingletonDemo_Web.Factory.AbstractFactory
{
    public class MAC : IBrand
    {
        public string GetBrand()
        {
            return Brands.APPLE.ToString();
        }
    }
}
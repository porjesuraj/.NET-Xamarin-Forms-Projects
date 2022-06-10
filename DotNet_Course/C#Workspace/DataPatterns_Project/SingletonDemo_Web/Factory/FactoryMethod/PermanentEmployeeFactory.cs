using SingletonDemo_Web.Managers;
using SingletonDemo_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SingletonDemo_Web.Factory.FactoryMethod
{
    public class PermanentEmployeeFactory : BaseEmployeeFactory
    {
        public PermanentEmployeeFactory(Employee emp) : base(emp)
        {

        }

        public override iEmployeeManager Create()
        {
            PermanentEmployeeManager manager = new PermanentEmployeeManager();
            _emp.HouseAllowance = manager.GetHouseAllowance();
            return manager;
        }
    }
}
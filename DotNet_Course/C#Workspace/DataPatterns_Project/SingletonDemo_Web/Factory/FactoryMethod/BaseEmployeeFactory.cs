using SingletonDemo_Web.Managers;
using SingletonDemo_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SingletonDemo_Web.Factory.FactoryMethod
{
    public abstract  class BaseEmployeeFactory
    {
        protected Employee _emp;


        public BaseEmployeeFactory(Employee emp)
        {
            _emp = emp;
        }

        public abstract iEmployeeManager Create();


        public Employee ApplySalary()
        {
            iEmployeeManager manager = this.Create();

            _emp.Bonus = manager.GetBonus();

            _emp.HourlyPay = manager.GetPay();

            return _emp;
        }
    }
}
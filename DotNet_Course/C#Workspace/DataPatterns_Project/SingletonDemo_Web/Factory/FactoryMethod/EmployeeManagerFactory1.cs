using SingletonDemo_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SingletonDemo_Web.Factory.FactoryMethod
{
    public class EmployeeManagerFactory1
    {

        public BaseEmployeeFactory CreateFactory(Employee employee)
        {
            BaseEmployeeFactory returnValue = null;
            if (employee.EmployeeTypeId == 1)
                returnValue = new PermanentEmployeeFactory(employee);
            else if (employee.EmployeeTypeId == 2)
                returnValue = new ContractEmployeeFactory(employee);

            return returnValue;
        }
    }
}
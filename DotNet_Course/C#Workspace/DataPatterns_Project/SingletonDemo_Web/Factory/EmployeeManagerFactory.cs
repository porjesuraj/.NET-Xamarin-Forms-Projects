using SingletonDemo_Web.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SingletonDemo_Web.Factory
{
    public class EmployeeManagerFactory
    {

        public iEmployeeManager GetEmployeeManager(int employeeTypeId)
        {
            iEmployeeManager returnValue = null;
            // here we can use a if- else or switch case  
            // with an enum of employeeTypeId
            if (employeeTypeId == 1)
                returnValue = new PermanentEmployeeManager();
            else if (employeeTypeId == 2)
                returnValue = new ContractEmployeeManager();

            return returnValue;

        }
    }
}
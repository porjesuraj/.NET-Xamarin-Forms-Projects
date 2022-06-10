using SingletonDemo_Web.Managers;
using SingletonDemo_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SingletonDemo_Web.Factory.FactoryMethod
{
    public class ContractEmployeeFactory : BaseEmployeeFactory
    {
        public ContractEmployeeFactory(Employee emp) : base(emp)
        {
        }

        public override iEmployeeManager Create()
        {
            ContractEmployeeManager manager = new ContractEmployeeManager();

            _emp.MedicalAllowance = manager.GetMedicalAllowance();

            return manager;
        }
    }
}
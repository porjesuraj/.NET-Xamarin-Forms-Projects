using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SingletonDemo_Web.Managers
{
    public class ContractEmployeeManager : iEmployeeManager
    {
        public decimal GetBonus()
        {
            return 5;
        }

        public decimal GetPay()
        {
            return 12; 
        }

        public decimal GetMedicalAllowance()
        {
            return 100;
        }
    }
}
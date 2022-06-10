using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SingletonDemo_Web.Managers
{
   public class PermanentEmployeeManager : iEmployeeManager
    {
        public decimal GetBonus()
        {
            return 10;
        }

        public decimal GetPay()
        {
             return 8;
        }

        public decimal GetHouseAllowance()
        {
            return 150;
        }
    }
}
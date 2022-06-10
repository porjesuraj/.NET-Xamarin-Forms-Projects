using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpApp2.Classes
{
   class BankAccount
    {

        #region fields
        private float balance;

        public float Balance
        {
            get
            {
                return balance;
            }
            private set
            {
                if (value >= 0)
                    balance = value;
                else
                    balance = 0;

            }
        }
        private string owner;
        #endregion

        #region Constructor
        public BankAccount()
        {

        }

        public BankAccount(float bal, string own)
        {
            this.balance = bal;
            this.owner = own;

        }

        #endregion

        #region Member Function
        public virtual float AddBalance(float balanceToBeAdded)
        {
            return balance = balance + balanceToBeAdded;
        }


        public virtual float AddBalance(float balanceToBeAdded, bool balanceCanBeNegative)
        {
            if (balanceCanBeNegative)
                Balance = Balance - balanceToBeAdded;
            else
                Balance = balance + balanceToBeAdded;

            return Balance;
        }

        public async Task<string> GetData()
        {
            Thread.Sleep(2000);

            return "Completed";
        }

        #endregion



    }

    class ChildBankAccount : BankAccount
    {

        public string Parent { get; set; }

        public ChildBankAccount(float bal, string own,string parent) : base(bal,own)
        {

            Parent = parent;

        }


        public override float AddBalance(float balanceToBeAdded, bool balanceCanBeNegative)
        {
            if(balanceToBeAdded <= 10)
            return base.AddBalance(balanceToBeAdded, balanceCanBeNegative);

            return Balance;

        }


        public override float AddBalance(float balanceToBeAdded)
        {
            if (balanceToBeAdded <= 10)
                return base.AddBalance(balanceToBeAdded);

            return Balance;
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankProgram.BL
{

    public class Account
    {
        private Owner _owner;
        private decimal _balance;
        private decimal _withdrawalLimit;        

        public Account(Owner owner, decimal balance)
        {
            _owner = owner;
            _balance = balance;
         
        }

        public Owner Owner
        {
            get
            {
                return _owner;
            }

            set
            {
                _owner = value;
            }

        }

        public decimal Balance
        {
            get
            {
                return _balance;

            }
            set
            {
                _balance = value;
            }
        }

        

    }
}

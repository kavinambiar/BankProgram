﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankProgram.BL
{
    public class CheckingAccount : Account
    {
        public CheckingAccount(Owner owner, decimal balance) : base(owner, balance)
        {

        }
    }
}

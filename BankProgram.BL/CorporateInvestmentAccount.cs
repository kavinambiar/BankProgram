using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankProgram.BL
{
    public class CorporateInvestmentAccount : InvestmentAccount
    {
        public CorporateInvestmentAccount(Owner owner, decimal balance) : base(owner, balance)
        {

        }

    }
    
}

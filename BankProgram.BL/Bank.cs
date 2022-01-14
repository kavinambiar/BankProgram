using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankProgram.BL
{
    public class Bank
    {        
        public Bank(string bankName)
        {
            BankName = bankName;            

        }

        public string BankName { get; private set; }
        
        public Account CreateBankAccount(Owner owner, decimal initialDeposit)
        {
            if (initialDeposit <= 0)
            {
                throw new ArgumentException("Amount cannot be negative.");
            }

            var newAccount = new Account(owner, initialDeposit);                
            owner.AddAccounts(newAccount);
            return newAccount;
        }

        public List<Account> GetOwnerAccounts(Owner owner)
        {
            return owner.OwnerAccounts;
        }

        public void Deposit(Account toAccount, decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Amount cannot be negative.");
            }
            toAccount.Balance = toAccount.Balance + amount;
        }

        public void Withdraw(Account fromAccount, decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Amount cannot be negative.");
            }
            if (fromAccount.Balance - amount < 0)
            {                
                throw new ArgumentException("Insufficient funds.");
            }
            
            fromAccount.Balance = fromAccount.Balance - amount;
        }

        public void Transfer(Account toAccount, Account fromAccount, decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Amount cannot be negative.");
            }
            if (fromAccount.Balance - amount < 0)
            {
                throw new ArgumentException("Insufficient funds.");
            }
            if (amount > 0 && (fromAccount.Balance - amount) > 0)
            {
                Withdraw(fromAccount, amount);
                Deposit(toAccount, amount);
            }
        }


    }
}

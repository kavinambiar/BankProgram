using System;
using BankProgram.BL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BankProgram.BLTest
{
    [TestClass]
    public class BankTest
    {
        string bankNameTest = "ABC Bank";
        string Owner1Test = "Owner 1";
        string Owner2Test = "Owner 2";
        decimal Owner1AccountBalanceTest = 3000;
        decimal Owner2AccountBalanceTest = 1000;

        [TestMethod]
        public void BankConstructor()
        {
            var testBank = new Bank(bankNameTest);

            Assert.AreEqual(bankNameTest, testBank.BankName);
        }

        [TestMethod]
        public void CreateBankAccountPass()
        {
            decimal initialDepositTest = 1600;

            var testBank = new Bank(bankNameTest);
            var testOwner1 = new Owner(Owner1Test);            
            var testAccount = new Account(testOwner1, initialDepositTest);
          
            testBank.CreateBankAccount(testOwner1, initialDepositTest);

            int testOwner1AccountsIndex = testOwner1.OwnerAccounts.Count - 1;            
            Assert.AreEqual(testAccount.Balance, testOwner1.OwnerAccounts[testOwner1AccountsIndex].Balance);            
            Assert.AreEqual(initialDepositTest, testOwner1.OwnerAccounts[testOwner1AccountsIndex].Balance);                                           
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateBankAccountNegativeValue()
        {           
            decimal testAmount = -1000;
           
            var testBank = new Bank(bankNameTest);
            var testOwner1 = new Owner(Owner1Test);

            testBank.CreateBankAccount(testOwner1, testAmount);
        }

        [TestMethod]
        public void GetOwnerBankAccounts()
        {
            var testBank = new Bank(bankNameTest);
            var testOwner1 = new Owner(Owner1Test);
            var testAccount = new Account(testOwner1, Owner1AccountBalanceTest);

            Assert.AreEqual(testBank.GetOwnerAccounts(testOwner1).Count, 0);

            testOwner1.AddAccounts(testAccount);

            int testOwner1AccountsIndex = testOwner1.OwnerAccounts.Count - 1;

            Assert.AreEqual(testAccount, testBank.GetOwnerAccounts(testOwner1)[testOwner1AccountsIndex]);
        }

        [TestMethod]
        public void WithdrawPass()
        {
            decimal testAmount = 500;

            var testBank = new Bank(bankNameTest);
            var testOwner1 = new Owner(Owner1Test);
            var testAccount = new Account(testOwner1, Owner1AccountBalanceTest);

            testBank.Withdraw(testAccount, testAmount);

            Assert.AreEqual(testAccount.Balance, Owner1AccountBalanceTest - testAmount);               
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void WithdrawNegativeValue()
        {
            decimal testAmount = -500;

            var testBank = new Bank(bankNameTest);
            var testOwner1 = new Owner(Owner1Test);
            var testAccount = new Account(testOwner1, Owner1AccountBalanceTest);

            testBank.Withdraw(testAccount, testAmount);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void WithdrawInsufficientFunds()
        {
            decimal testAmount = 3500;

            var testBank = new Bank(bankNameTest);
            var testOwner1 = new Owner(Owner1Test);
            var testAccount = new Account(testOwner1, Owner1AccountBalanceTest);

            testBank.Withdraw(testAccount, testAmount);
        }

        [TestMethod]
        public void DepositPass()
        {
            decimal testAmount = 500;

            var testBank = new Bank(bankNameTest);
            var testOwner1 = new Owner(Owner1Test);
            var testAccount = new Account(testOwner1, Owner1AccountBalanceTest);
            testBank.Deposit(testAccount, testAmount);

            Assert.AreEqual(testAccount.Balance, Owner1AccountBalanceTest + testAmount);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DepositNegativeValue()
        {
            decimal testAmount = -500;

            var testBank = new Bank(bankNameTest);
            var testOwner1 = new Owner(Owner1Test);
            var testAccount = new Account(testOwner1, Owner1AccountBalanceTest);

            testBank.Deposit(testAccount, testAmount);
        }

        [TestMethod]
        public void TransferPass()
        {
            decimal testAmount = 500;

            var testBank = new Bank(bankNameTest);
            var testOwner1 = new Owner(Owner1Test);
            var testOwner2 = new Owner(Owner2Test);
            var testAccount1 = new Account(testOwner1, Owner1AccountBalanceTest);
            var testAccount2 = new Account(testOwner2, Owner2AccountBalanceTest);

            testBank.Transfer(testAccount2, testAccount1, testAmount);

            Assert.AreEqual(testAccount2.Balance, Owner2AccountBalanceTest + testAmount);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TransferNegativeValue()
        {
            decimal testAmount = -500;

            var testBank = new Bank(bankNameTest);
            var testOwner1 = new Owner(Owner1Test);
            var testOwner2 = new Owner(Owner2Test);
            var testAccount1 = new Account(testOwner1, Owner1AccountBalanceTest);
            var testAccount2 = new Account(testOwner2, Owner2AccountBalanceTest);

            testBank.Transfer(testAccount2, testAccount1, testAmount);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TransferInsufficientFunds()
        {

            decimal testAmount = 3500;


            var testBank = new Bank(bankNameTest);
            var testOwner1 = new Owner(Owner1Test);
            var testOwner2 = new Owner(Owner2Test);
            var testAccount1 = new Account(testOwner1, Owner1AccountBalanceTest);
            var testAccount2 = new Account(testOwner2, Owner2AccountBalanceTest);

            testBank.Transfer(testAccount2, testAccount1, testAmount);
        }
    }
}

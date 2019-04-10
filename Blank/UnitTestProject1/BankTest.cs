/*Ethan Seiber
 * Date: 4/10/2019
 * File: BankTest.cs
 * Description: The test file for the BankAccountNS class
 */

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankAccountNS;

namespace UnitTestProject1
{
    [TestClass]
    public class BankTest
    {
        // unit test code  
        [TestMethod]
        public void Debit_WithValidAmount_UpdatesBalance()
        {
            // arrange  
            double beginningBalance = 11.99;
            double debitAmount = 4.55;
            double expected = 7.44;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // act  
            account.Debit(debitAmount);

            // assert  
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");
        }
        
        //unit test method  
        [TestMethod]
        //[ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Debit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange()
        {
            //When debit amount is less than zero an exception is thrown or if valid input is provided then an exception is thrown because this tests whether
            //the debit amount is less than zero
            // arrange  
            double beginningBalance = 11.99;
            double debitAmount = 10.00;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // act  
            try
            {
                account.Debit(debitAmount);
            }
            catch (ArgumentOutOfRangeException e)
            {
                StringAssert.Contains(e.Message, BankAccount.DebitAmountLessThanZeroMessage);
                return;
            }

            Assert.Fail("No exception was thrown");
            // assert is handled by ExpectedException  
        }

        [TestMethod]
        //[ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Debit_WhenAmountIsMoreThanBalance_ShouldThrowArgumentOutOfRange()
        {
            //When the debit amount is more than what is within the account an exception is thrown or if it is valid data an exception is thrown

            // arrange  
            double beginningBalance = 11.99;
            double debitAmount = 10.00;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // act  
            try
            {
                account.Debit(debitAmount);
            }
            catch (ArgumentOutOfRangeException e)
            {
                // assert  
                StringAssert.Contains(e.Message, BankAccount.DebitAmountExceedsBalanceMessage);
                return;
            }

            Assert.Fail("No exception was thrown.");
            // assert is handled by ExpectedException 
        }

        [TestMethod]
        public void Credit_AccountFrozen()
        {
            //When the account is frozen an exception is thrown

            double BeginningBalance = 500.00;
            double CreditAmount = 600;
            BankAccount account = new BankAccount("Dr. Watson", BeginningBalance);//Sherlock Holmes character
            account.ToggleFreeze();

            account.Credit(CreditAmount);

            Assert.Fail("No exception was thrown");
        }

        [TestMethod]
        public void Credit_CreditIsNegativeShouldThrowAn_OutOfRangeException()
        {
            //when the credit amount is negative an exception is thrown

            double BeginningBalence = 500.00;
            double CreditAmount = -100;
            BankAccount account = new BankAccount("Mr. Holmes", BeginningBalence);//Sherlock Holmes character

            account.Credit(CreditAmount);

            Assert.Fail("No exception was thrown");
        }

        [TestMethod]
        public void Credit_UpdateAcountBecauseEverythingIsHunkyDory()
        {
            //when everything is hunky dory the funds are added to the account

            double BeginningBalance = 500.00;
            double CreditAmount = 100.00;
            BankAccount account = new BankAccount("Mrs. Adler", BeginningBalance);//Sherlock Holmes character

            account.Credit(CreditAmount);
        }
    }
}

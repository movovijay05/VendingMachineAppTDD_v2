using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VndingMachineAppTDD_v2.Models;
using VndingMachineAppTDD_v2.Functions;
using System.Collections.Generic;
using VndingMachineAppTDD_v2.Constants;

namespace VndingMachineAppTDD_v2.Tests
{
    [TestClass]
    public class TransactionTests
    {
        TransactionValidator tv = new TransactionValidator();
        VendingMachineCashEnum vCEnum = new VendingMachineCashEnum();
        GenericDictionaryFunctions genFun = new GenericDictionaryFunctions();

        [TestMethod]
        public void testTotalPriceOfASingleUserTransactionInTermsOfProducts()
        {
            Dictionary<string, int> checkTotalPriceOfUserRequestedItems = new Dictionary<string, int>();
            checkTotalPriceOfUserRequestedItems.Add("Cola", 3);   // 1 * 3 = 3
            checkTotalPriceOfUserRequestedItems.Add("Chips", 1); // 0.50 * 1 = 0.50
            checkTotalPriceOfUserRequestedItems.Add("Candy", 5); // 0.65 * 5 = 3.25
            Assert.AreEqual(6.75, tv.calculateTotalPriceOfASingleUserTransaction(checkTotalPriceOfUserRequestedItems, 1));
        }

        [TestMethod]
        public void testTotalPriceOfASingleUserTransactionInTermsOfCoins()
        {
            Dictionary<string, int> checkTotalPriceOfUserInputCoins = new Dictionary<string, int>();
            checkTotalPriceOfUserInputCoins.Add("QUARTERS", 4);   // 0.25 * 4 = 1
            checkTotalPriceOfUserInputCoins.Add("DIMES", 1); // 0.10 * 1 = 0.10
            checkTotalPriceOfUserInputCoins.Add("NICKELS", 1); // 0.05 * 1 = 0.05
            double coinValue = 1.15;
            Assert.AreEqual(coinValue, tv.calculateTotalPriceOfASingleUserTransaction(checkTotalPriceOfUserInputCoins, 2));
        }

        [TestMethod]
        public void testTheNumberOfNickelsDimesAndQuartersRequiredToMakeChange()
        {
            vCEnum.numberOfNickelsDimesAndQuartersRequiredToMakeChange = new Dictionary<string, int>();
            vCEnum.totalRemainingCashInVM = new Dictionary<string, int>();
            vCEnum.totalRemainingCashInVM.Add(CoinDetailsEnum.QuartersName, 20);
            vCEnum.totalRemainingCashInVM.Add(CoinDetailsEnum.DimesName, 10);
            vCEnum.totalRemainingCashInVM.Add(CoinDetailsEnum.NickelsName, 10);

            Dictionary<string, int> checkTheNumberOfNickelsDimesAndQuartersRequired = new Dictionary<string, int>();
            // order of the below items is important
            checkTheNumberOfNickelsDimesAndQuartersRequired.Add("QUARTERS", 10);
            checkTheNumberOfNickelsDimesAndQuartersRequired.Add("DIMES", 1);
            checkTheNumberOfNickelsDimesAndQuartersRequired.Add("NICKELS", 1);
            vCEnum.changeToBeGivenToTheUser = 2.65;

            vCEnum.numberOfNickelsDimesAndQuartersRequiredToMakeChange = tv.calculateTheNumberOfNickelsDimesAndQuartersRequiredToMakeChange(vCEnum);
            Assert.IsTrue(genFun.checkIfTwoStringIntDictionariesAreIdenticalWithoutSorting(checkTheNumberOfNickelsDimesAndQuartersRequired, vCEnum.numberOfNickelsDimesAndQuartersRequiredToMakeChange));
        }

        [TestMethod]
        public void testMessageToBeDisplayOnTheVM()
        {
            vCEnum.totalPriceOfTransaction = 2.40;
            vCEnum.totalValueOfCoinsInsertedByTheUser = 3.00;
            String messageToBeDisplayed;
            messageToBeDisplayed = "Thanks for paying!!! Dispensing change to the amount of $" + vCEnum.balanceToBeDisplayed;//+ "\n Remaining Cash in VM:" + genFun.printAStringIntDictionary(vCEnum.totalRemainingCashInVM);
            //messageToBeDisplayed = "Please tend exact change. Please collect all the coins you deposited";
            //messageToBeDisplayed = "Thanks for paying!!! Please collect the product";

            Assert.AreEqual(messageToBeDisplayed, tv.checkIfChangeNeedsToBeProvidedByVMOrUserNeedsToInputMoreCoins(vCEnum));
        }
    }
}

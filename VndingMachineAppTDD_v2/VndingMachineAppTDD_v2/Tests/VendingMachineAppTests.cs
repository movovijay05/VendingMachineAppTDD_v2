using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VndingMachineAppTDD_v2.Models;
using VndingMachineAppTDD_v2.Functions;
using System.Collections.Generic;

namespace VendingMachineAppTDD_v2
{
    [TestClass]
    public class VendingMachineAppTests
    {
        CoinValidator cv = new CoinValidator();
        TransactionValidator tv = new TransactionValidator();

        [TestMethod]
        public void testifVMAcceptsOnlyNickelsDimesAndQuarters()
        {
            Assert.IsTrue(cv.isValidCoinType(2));
            Assert.IsTrue(cv.isValidCoinType(3));
            Assert.IsTrue(cv.isValidCoinType(4));
        }
        [TestMethod]
        public void testifVMAcceptsOnlyCoinsWithValidDimensions()
        {
            Assert.IsTrue(cv.isValidCoinDimensions(5.00, "Weight", "grams"));
            Assert.IsTrue(cv.isValidCoinDimensions(1.75, "Thickness", "mm"));
            Assert.IsTrue(cv.isValidCoinDimensions(0.71, "Diameter", "inches"));
        }

        GenericDictionaryFunctions genFun = new GenericDictionaryFunctions();
        [TestMethod]
        public void testIfAStringDictionaryPrintsCorrectly()
        {
            Dictionary<string, int> checkStringDictOutput = new Dictionary<string, int>();
            checkStringDictOutput.Add("Cola", 3);
            Assert.AreEqual("Cola:3", genFun.printAStringIntDictionary(checkStringDictOutput));
        }
        [TestMethod]
        public void testingIfTwoStringIntDictionariesAreEqualFunction()
        {
            Dictionary<string, int> checkStringDict1 = new Dictionary<string, int>();
            checkStringDict1.Add("Cola", 3);
            checkStringDict1.Add("Chips", 2);

            Dictionary<string, int> checkStringDict2 = new Dictionary<string, int>();
            checkStringDict2.Add("Cola", 3);
            checkStringDict2.Add("Chips", 2);

            Assert.IsTrue( genFun.checkIfTwoStringIntDictionariesAreIdenticalWithoutSorting(checkStringDict1, checkStringDict2));
        }

        [TestMethod]
        public void testingIfTwoStringDoubleDictionariesAreEqualFunction()
        {
            Dictionary<string, Double> checkStringDict1 = new Dictionary<string, Double>();
            checkStringDict1.Add("Cola", 3.10);
            checkStringDict1.Add("Chips", 2.25);

            Dictionary<string, Double> checkStringDict2 = new Dictionary<string, Double>();
            checkStringDict2.Add("Cola", 3.10);
            checkStringDict2.Add("Chips", 2.25);

            Assert.IsTrue(genFun.checkIfTwoStringDoubleDictionariesAreIdenticalWithoutSorting(checkStringDict1, checkStringDict2));
        }

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
    }
}

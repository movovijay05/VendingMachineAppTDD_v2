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
        public void testIfTwoDictionariesAreEqual()
        {
            Dictionary<string, int> checkStringDict1 = new Dictionary<string, int>();
            checkStringDict1.Add("Cola", 3);
            checkStringDict1.Add("Chips", 2);

            Dictionary<string, int> checkStringDict2 = new Dictionary<string, int>();
            checkStringDict2.Add("Cola", 3);
            checkStringDict2.Add("Chips", 2);

            Assert.IsTrue( genFun.checkIfTwoStringIntDictionariesAreIdenticalWithoutSorting(checkStringDict1, checkStringDict2));
        }
    }
}

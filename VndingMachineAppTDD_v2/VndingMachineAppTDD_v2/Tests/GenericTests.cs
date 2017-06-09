using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VndingMachineAppTDD_v2.Models;
using VndingMachineAppTDD_v2.Functions;
using System.Collections.Generic;
using VndingMachineAppTDD_v2.Constants;

namespace VendingMachineAppTDD_v2
{
    [TestClass]
    public class VendingMachineAppTests
    {
        GenericDictionaryFunctions genFun = new GenericDictionaryFunctions();
        [TestMethod]
        public void testIfAStringDictionaryPrintsCorrectly()
        {
            Dictionary<string, int> checkStringDictOutput = new Dictionary<string, int>();
            checkStringDictOutput.Add("TestData", 3);
            Assert.AreEqual("TestData:3", genFun.printAStringIntDictionary(checkStringDictOutput));
        }
        [TestMethod]
        public void testingIfTwoStringIntDictionariesAreEqualFunction()
        {
            Dictionary<string, int> checkStringDict1 = new Dictionary<string, int>();
            checkStringDict1.Add("TestData1", 3);
            checkStringDict1.Add("TestData2", 2);

            Dictionary<string, int> checkStringDict2 = new Dictionary<string, int>();
            checkStringDict2.Add("TestData1", 3);
            checkStringDict2.Add("TestData2", 2);

            Assert.IsTrue( genFun.checkIfTwoStringIntDictionariesAreIdenticalWithoutSorting(checkStringDict1, checkStringDict2));
        }

        [TestMethod]
        public void testingIfTwoStringDoubleDictionariesAreEqualFunction()
        {
            Dictionary<string, Double> checkStringDict1 = new Dictionary<string, Double>();
            checkStringDict1.Add("TestData1", 3.10);
            checkStringDict1.Add("TestData2", 2.25);

            Dictionary<string, Double> checkStringDict2 = new Dictionary<string, Double>();
            checkStringDict2.Add("TestData1", 3.10);
            checkStringDict2.Add("TestData2", 2.25);

            Assert.IsTrue(genFun.checkIfTwoStringDoubleDictionariesAreIdenticalWithoutSorting(checkStringDict1, checkStringDict2));
        }

       
    }
}

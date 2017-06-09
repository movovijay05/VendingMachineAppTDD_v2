using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VndingMachineAppTDD_v2.Models;
using VndingMachineAppTDD_v2.Functions;
using System.Collections.Generic;
using VndingMachineAppTDD_v2.Constants;

namespace VndingMachineAppTDD_v2.Tests
{
    [TestClass]
    public class CoinTests
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
    }
}

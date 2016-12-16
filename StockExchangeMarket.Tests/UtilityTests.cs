using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StockExchangeMarket.Controller;

namespace StockExchangeMarket.Tests
{
    [TestClass]
    public class UtilityTests
    {
        [TestMethod]
        public void IsNull_NullData_ReturnsChangeValue()
        {
            string lcChangeValue = "ChangeValue";
            string lcValue = (string)Utility.IsNull(null, lcChangeValue);
            Assert.AreEqual(lcValue, lcChangeValue);
        }

        [TestMethod]
        public void IsNull_ValidData_ReturnsValue()
        {
            string lcValidValue = "ValidValue";
            string lcChangeValue = "ChangeValue";
            string lcValue = (string)Utility.IsNull(lcValidValue, lcChangeValue);
            Assert.AreEqual(lcValue, lcValidValue);
        }
    }
}

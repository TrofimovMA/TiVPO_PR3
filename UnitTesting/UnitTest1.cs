using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BirthdayReminder;

namespace UnitTesting
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var expected = "TDD_Test";
            var result = BirthdayReminder.BirthdayReminder.TDD_Test();
            Assert.AreEqual(expected, result);
        }
    }
}

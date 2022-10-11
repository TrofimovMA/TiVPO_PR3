using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using BirthdayReminder;

namespace UnitTesting
{
    [TestClass]
    public class UnitTest
    {
        static readonly string inputFile = Directory.GetCurrentDirectory() + @"\database.txt";

        [TestInitialize]
        public void TestInitialization()
        {
            File.WriteAllText(inputFile, "");
        }

        [TestCleanup]
        public void TestCleaningUp()
        {
            File.Delete(inputFile);
        }

        [TestMethod]
        public void TestAddSingleRecord()
        {
            // Arrange
            File.WriteAllText(inputFile, "");

            // Act
            string name = "John";
            string date = "11.10";
            BirthdayReminder.BirthdayReminder.AddRecord(name, date, inputFile);

            // Assert
            var expected = "\"John\" \"11.10\"\n";
            var result = File.ReadAllText(inputFile);
            Assert.AreEqual(expected, result);
        }
    }
}

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

        [TestMethod]
        public void TestAddRecordRules()
        {
            // Arrange
            File.WriteAllText(inputFile, "");

            // Act
            string name1 = @"""John""""";
            string date1 = "11.10";
            BirthdayReminder.BirthdayReminder.AddRecord(name1, date1, inputFile);
            string name2 = @"Jane";
            string date2 = @"11"".10""""""";
            BirthdayReminder.BirthdayReminder.AddRecord(name2, date2, inputFile);

            // Assert
            var expected = @"";
            var result = File.ReadAllText(inputFile);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestGetRecordsOnDate()
        {
            // Arrange
            File.WriteAllText(inputFile, "");
            BirthdayReminder.BirthdayReminder.AddRecord("John", "12.10", inputFile);
            BirthdayReminder.BirthdayReminder.AddRecord("Jane", "12.10", inputFile);

            // Act
            var result = BirthdayReminder.BirthdayReminder.GetRecords("12.10", inputFile);

            // Assert
            var expected = "\"John\" \"12.10\"\n\"Jane\" \"12.10\"\n";
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestExecuteCommands()
        {
            // Arrange
            File.WriteAllText(inputFile, "");
            string s1 = "Add <John> <12.10>";
            string s2 = "Add <Jane> <12.10>";

            // Act
            BirthdayReminder.BirthdayReminder.ExecuteCmd(s1, inputFile);
            BirthdayReminder.BirthdayReminder.ExecuteCmd(s2, inputFile);

            // Assert
            var result = BirthdayReminder.BirthdayReminder.GetRecords("12.10", inputFile);
            var expected = "\"John\" \"12.10\"\n\"Jane\" \"12.10\"\n";
            Assert.AreEqual(expected, result);
        }
    }
}

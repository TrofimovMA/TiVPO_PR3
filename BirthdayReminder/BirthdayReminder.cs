using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BirthdayReminder
{
    public class BirthdayReminder
    {
        public static void AddRecord(string name, string date, string database)
        {
            if (name.Contains(@"""") || date.Contains(@""""))
                return;

            string txt = String.Format($"\"{name}\" \"{date}\"\n");
            File.AppendAllText(database, txt);
        }

        public static string GetRecords(string date, string database)
        {
            // TDD - GetRecordsOnDate - Refactor Stage

            string[] records = File.ReadAllLines(database);
            string relevantRecords = "";
            foreach (string record in records)
            {
                if (!record.EndsWith($"\"{date}\""))
                    continue;

                    relevantRecords += record + "\n";
            }

            return relevantRecords;
        }
    }
}

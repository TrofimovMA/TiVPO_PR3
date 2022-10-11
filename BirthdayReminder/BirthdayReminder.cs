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
            // TDD - AddRecordRules - Red Stage

            string txt = String.Format($"\"{name}\" \"{date}\"\n");
            File.AppendAllText(database, txt);
        }
    }
}

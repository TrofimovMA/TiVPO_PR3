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
            // TDD - AddSingleRecord - Green Stage

            File.AppendAllText(database, $"\"{name}\" \"{date}\"\n");
        }
    }
}

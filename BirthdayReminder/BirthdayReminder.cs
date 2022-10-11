using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using System.Runtime.CompilerServices;

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

        public static string ExecuteCmd(string command, string database)
        {
            Regex regex = new Regex(@"(?<cmd>\S+)(\s*<(?<pars>.*?)>\s*)*");
            Match match = regex.Match(command);
            string cmd = match.Groups["cmd"].Value.ToLower();
            string[] pars = match.Groups["pars"].Captures.Cast<Capture>().Select(x => x.Value).ToArray();

            switch (cmd)
            {
                case "add":
                    AddRecord(pars[0], pars[1], database);
                    break;
                case "get":
                    return GetRecords(pars[0], database);
                default:
                    return string.Format("Invalid command: \"{0}\".", command);
            }

            return "";
        }
    }
}

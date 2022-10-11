using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BirthdayReminder
{
    public class UserInterface
    {
        // База данных
        static readonly string inputFile = Directory.GetCurrentDirectory() + @"\database.txt";

        // Точка входа
        public static void Main()
        {
            Console.WriteLine("Welcome to BirthdayReminder!!!");
            Console.WriteLine("---");
            // TO DO: Вывод Сегодняшних Дней Рождений Здесь
            Console.WriteLine("---");
            Console.WriteLine("1. Type \"Get <Date>\" to get notifications about birthdays on this day.");
            Console.WriteLine("2. Type \"Add <Name> <Date>\" to add a birthday to the list.");
            Console.WriteLine("To quit the application type \"Exit\" or just press Enter.");
            Console.WriteLine("---");

            while (1 > 0)
            {
                Console.Write("> ");
                string input = Console.ReadLine();

                Regex regex = new Regex(@"(?<cmd>\S+)(\s*<(?<pars>.*?)>\s*)*");
                Match match = regex.Match(input);
                string cmd = match.Groups["cmd"].Value.ToLower();
                string[] pars = match.Groups["pars"].Captures.Cast<Capture>().Select(x => x.Value).ToArray();
                //Console.WriteLine(cmd);
                //Console.WriteLine(string.Join(", ", pars));

                switch (cmd)
                {
                    // Команда Выхода из Приложения
                    case "exit":
                    case "":
                        Console.WriteLine("Goodbye!!!");
                        return;
                    // Остальные команды
                    default:

                        switch(input)
                        {
                            // TO DO: Обработка Остальных Команд
                            // Некорректная Команда
                            default:
                                Console.WriteLine("Invalid Command: \"{0}\".", input);
                                break;
                        }
                        break;
                }
            }
        }
    }
}

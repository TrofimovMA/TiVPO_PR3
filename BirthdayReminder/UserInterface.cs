using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BirthdayReminder
{
    // Интерфейс Взаимодействия с Классом BirthdayReminder
    public class UserInterface
    {
        // База данных
        static readonly string inputFile = Directory.GetCurrentDirectory() + @"\database.txt";

        // Точка входа
        public static void Main()
        {
            if (!File.Exists(inputFile))
                File.WriteAllText(inputFile, "");

            Console.WriteLine("Welcome to BirthdayReminder!!!");
            Console.WriteLine("---");
            // Сегодняшние Дни Рождения
            Console.WriteLine("Today Birthdays:");
            var records = BirthdayReminder.GetRecords(DateTime.Today.ToString("dd.MM"), inputFile);
            Console.WriteLine(records == "" ? "-" : records.Trim());
            Console.WriteLine("---");
            // Инструкция Пользователя
            Console.WriteLine("1. Type \"Get <Date>\" to get notifications about birthdays on this day.");
            Console.WriteLine("2. Type \"Add <Name> <Date>\" to add a birthday to the list.");
            Console.WriteLine("To quit the application type \"Exit\" or just press Enter.");
            Console.WriteLine("---");

            // Обработка Команд Пользователя
            while (1 > 0)
            {
                Console.Write("> ");
                string input = Console.ReadLine();

                switch (input.Trim().ToLower())
                {
                    // Команда Выхода из Приложения
                    case "exit":
                    case "":
                        Console.WriteLine("Goodbye!!!");
                        return;
                    // Остальные команды пересылаются классу BirthdayReminder
                    default:
                        var result = BirthdayReminder.ExecuteCmd(input, inputFile);
                        if (result != "")
                            Console.Write(result);
                        break;
                }
            }
        }
    }
}

using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;


namespace ChallengeApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            var EM = new EmployeeManager();
            Boolean isProceed = true;

            while (isProceed)
            {
                string inputData;
                
                Console.Clear();
                do
                {
                    Console.WriteLine("(1) Dodaj pracownika");
                    Console.WriteLine("(2) Wyświetl listę pracowników");
                    Console.WriteLine("(3) Wyświetl statystyki pracownika");
                    Console.WriteLine("(4) Wyjdź z programu");

                    inputData = Console.ReadLine();
                    string newLine = Regex.Replace(inputData, @"\s+", "");

                    switch (newLine)
                    {
                        case "1":
                            EM.BuildEmployee();
                            break;
                        case "2":
                            EM.EmployeeList();
                            break;
                        case "3":
                            EM.EmployeeStats();
                            break;
                        case "4":
                            isProceed = false;
                            break;
                    }
                }
                while (inputData != "4");

            }

            Console.WriteLine("Program został zakończony");
        }
    }
}

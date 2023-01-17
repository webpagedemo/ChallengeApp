using System;
using System.Collections;
using System.Linq;

namespace ChallengeApp
{
    public class EmployeeManager
    {
        private ArrayList employees;
        public EmployeeManager()
        {
            this.employees = new ArrayList();
        }

        public void BuildEmployee()
        {
            Boolean isAddProceed = true;
            while (isAddProceed)
            {
                Console.Clear();
                int emplyeeId = this.AddEmployee();
                this.AddGrade(emplyeeId);

                Console.WriteLine("Wciśnij cokolwiek żeby dodać kolejnego pracownika lub `q` żeby wyjść do głównego menu.");

                string isQuit = Console.ReadLine();
                if (isQuit == "q")
                {
                    isAddProceed = false;
                    Console.Clear();
                }
            }
        }

        public void EmployeeStats()
        {
            Boolean isAddProceed = true;
            while (isAddProceed)
            {
                Console.Clear();
                Console.WriteLine($"Podaj id pracownika:");
                var idEmployee = Console.ReadLine();
                int findEmployee = 0;
                Console.Clear();
                foreach (IEmployee employee in this.employees)
                {
                    if (employee.Id == int.Parse(idEmployee))
                    {
                        if (employee.Grades.Count > 0)
                        {
                            var statistics = GenerateStatistics(employee);
                            Console.WriteLine($"Średnia ocen pracownika: {statistics.Avarage}");
                            Console.WriteLine($"Najniższa ocena: {statistics.Min}");
                            Console.WriteLine($"Najniższa ocena: {statistics.Max}");
                        }
                        else
                        {
                            Console.WriteLine($"Pracownik {employee.Name} o id {employee.Id} nie ma jeszcze ocen.");
                        }

                        findEmployee = 1;
                    }
                }

                if (findEmployee == 0)
                {
                    Console.WriteLine($"Nie znaleziono pracownika o id {idEmployee}");
                }

                Console.WriteLine("Wciśnij cokolwiek aby zobaczyć kolejne statystyki lub `q` żeby wyjść do głównego menu.");

                string isQuit = Console.ReadLine();
                if (isQuit == "q")
                {
                    isAddProceed = false;
                    Console.Clear();
                }
            }


        }

        public void EmployeeList()
        {
            Boolean isAddProceed = true;
            while (isAddProceed)
            {
                Console.Clear();
                foreach (IEmployee employee in this.employees)
                {
                    Console.WriteLine($"{employee.Id} {employee.Name} {employee.DateAt}");
                }

                Console.WriteLine("Wciśnij cokolwiek aby zobaczyć ponownie listę pracowników lub `q` żeby wyjść do głównego menu.");

                string isQuit = Console.ReadLine();
                if (isQuit == "q")
                {
                    isAddProceed = false;
                    Console.Clear();
                }
            }
        }

        private int AddEmployee()
        {
            Console.Clear();
            Console.WriteLine("Podaj imię nowego pracownika:");
            string name = Console.ReadLine();
            int id = 0;

            Boolean isTypeProceed = true;
            do
            {
                Console.Clear();
                Console.WriteLine("Czy zapisać go do pliku? (y/n)");
                string intoFileInput = Console.ReadLine();

                if (intoFileInput != "y" && intoFileInput != "n") continue;
                IEmployee employee = intoFileInput == "y" ? new SaveEmployee() : new Employee();

                employee.Id = this.employees.Count + 1;
                employee.AddName(name);
                id = this.employees.Add(employee);

                isTypeProceed = false;
            } while (isTypeProceed);

            return id;
        }

        private void AddGrade(int emplyeeId)
        {
            Boolean isTypeProceed = true;

            var employee = this.SearchEmployee(emplyeeId);

            while (isTypeProceed)
            {
                Console.Clear();

                Console.WriteLine($"Dodać Ocenę dla pracownika {employee.Name} ? (y/n)'");

                var questionInput = Console.ReadLine();

                if (questionInput == "y")
                {
                    Console.Clear();
                    var inputAddGrade = Console.ReadLine();
                    employee.AddGrade(inputAddGrade);
                    ReplaceEmployee(emplyeeId, employee);
                }
                else
                {
                    isTypeProceed = false;
                    Console.Clear();
                }
            }
        }

        private IEmployee SearchEmployee(int id)
        {
            int i = 0;
            foreach (IEmployee employee in this.employees)
            {
                if (i == id)
                {
                    return employee;
                }
                i++;
            }

            return null;
        }

        private void ReplaceEmployee(int id, IEmployee newEmployee)
        {
            int i = 0;
            foreach (IEmployee employee in this.employees)
            {
                if (i == id)
                {
                    this.employees[id] = newEmployee;
                    break;
                }
                i++;
            }
        }

        public Statistics GenerateStatistics(IEmployee employee)
        {
            var statistics = new Statistics();
            statistics.Max = double.MinValue;
            statistics.Min = double.MaxValue;
            statistics.Avarage = 0.0;

            if (employee.Grades.Count > 0)
            {
                foreach (double grade in employee.Grades)
                {
                    statistics.Avarage += grade;
                    statistics.Max = Math.Max(grade, statistics.Max);
                    statistics.Min = Math.Min(grade, statistics.Min);
                }

                statistics.Avarage = statistics.Avarage / employee.Grades.Count;
            }

            return statistics;
        }
    }
}
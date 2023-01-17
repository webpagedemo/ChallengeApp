using System;
using System.IO;
using System.Collections;

namespace ChallengeApp
{
    public class SaveEmployee : EmployeeBase
    {
        const string FILENAME = "employee.csv";
        const string FILEGRADE = "employee-grades.csv";


        public override void AddName(string name)
        {
            this.Name = name;
            this.DateAt = DateTime.UtcNow;
            if (!File.Exists(FILENAME))
            {
                using (StreamWriter sw = File.CreateText(FILENAME))
                {
                    sw.WriteLine($"{Id};{name};{DateAt}");
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(FILENAME))
                {
                    sw.WriteLine($"{Id};{name}");
                }
            }
        }

        public override void AddGrade(string grade)
        {
            var calculateGrade = this.CalculateGrade(grade);

            if (!this.CheckNumberRange(calculateGrade))
            {
                throw new Exception("Ocena jest poza zakresem od 1-6");
            }

            if (!File.Exists(FILEGRADE))
            {
                using (StreamWriter sw = File.CreateText(FILEGRADE))
                {
                    sw.WriteLine($"{Id};{grade};{DateAt}");
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(FILEGRADE))
                {
                    sw.WriteLine($"{Id};{grade};{DateAt}");
                }
            }
            if (this.Grades == null)
            {
                this.Grades = new ArrayList();
            }
            this.Grades.Add(calculateGrade);
        }
    }
}
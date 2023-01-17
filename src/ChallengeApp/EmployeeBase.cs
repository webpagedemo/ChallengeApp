using System;
using System.Collections;

namespace ChallengeApp
{
    public abstract class EmployeeBase : IEmployee
    {
        public double currentGrade;
        public ArrayList Grades { get; set; }

        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime DateAt { get; set; }

        public abstract void AddGrade(string grade);

        public abstract void AddName(string name);

        public Boolean CheckNumberRange(double currentGrade)
        {
            double min = 1.0;
            double max = 6.0;

            return (currentGrade >= min && currentGrade <= max) ? true : false;
        }

        public double ParseToNumber(char testChar)
        {
            double output = 0.0;
            try
            {
                output = double.Parse(testChar.ToString());
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"{ex.Message}");
            }

            return output;
        }

        public double CalculateGrade(string grade)
        {
            double currentGrade = 0.0;

            if (IsCorrectGradeLength(grade))
            {
                const char plus = '+';
                const char minus = '-';
                const char dot = '.';
                Boolean isDecimal = false;

                for (int index = 0; index < grade.Length; index++)
                {
                    char charGrade = grade[index];
                    switch (charGrade)
                    {
                        case plus:
                            currentGrade += 0.5;
                            break;
                        case minus:
                            currentGrade -= 0.25;
                            break;
                        case dot:
                            isDecimal = true;
                            break;
                        default:
                            currentGrade += isDecimal ? (this.ParseToNumber(charGrade) / 10) : this.ParseToNumber(charGrade);
                            break;
                    }
                }
            }

            return currentGrade;
        }

        public Boolean IsCorrectGradeLength(string grade)
        {
            return (grade.Length > 0 && grade.Length <= 3) ? true : false;
        }
    }
}
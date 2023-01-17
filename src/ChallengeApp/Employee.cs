using System;
using System.Collections;
using System.Collections.Generic;

namespace ChallengeApp
{
    public class Employee : EmployeeBase
    {
        public override void AddName(string name)
        {
            this.Name = name;
            this.DateAt = DateTime.UtcNow;
        }

        public override void AddGrade(string grade)
        {
            var calculateGrade = this.CalculateGrade(grade);

            if (!this.CheckNumberRange(calculateGrade))
            {
                throw new Exception("Ocena jest poza zakresem od 1-6");
            }

            if (this.Grades == null)
            {
                this.Grades = new ArrayList();
            }

            this.Grades.Add(calculateGrade);
        }
    }
}
using System;
using System.Collections;

namespace ChallengeApp
{
    public interface IEmployee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateAt { get; set; }
        public void AddGrade(string grade);
        public void AddName(string name);
        public ArrayList Grades { get; set; }
    }
}
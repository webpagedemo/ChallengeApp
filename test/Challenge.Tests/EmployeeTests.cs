using ChallengeApp;
using Xunit;
using System.Collections.Generic;


namespace Challenge.Tests
{
    public class EmployeeTests
    {
        [Fact]
        public void Test1()
        {
            // arrange
            var employeeManager = new EmployeeManager();
            employeeManager.AddEmployee(new Employee("Adam", 1732.32));
            employeeManager.AddEmployee(new Employee("Ewa", 3232.01));
            employeeManager.AddEmployee(new Employee("Bartek", 3421.5));

            // act
            var statistics = employeeManager.GenerateStatistics();

            // assert
            Assert.Equal(1732.32, statistics.Min);
            Assert.Equal(3421.5, statistics.Max);
            Assert.Equal(2795.3, statistics.Avarage, 1);
        }
    }
}

using System;
using ChallengeApp;
using Xunit;


namespace Challenge.Tests
{
    public class TypeTests
    {
        private Employee emp1;
        private Employee emp2;
        private Employee emp3;
        private int counter = 0;

        public delegate string WriteMessage(string message);

        public TypeTests()
        {
            this.emp1 = GetEmployee("Basia", 2343.12);
            this.emp2 = GetEmployee("Kasia", 5232.22);
            this.emp3 = this.emp2;
        }

        [Fact]
        public void WriteMessageDelegateCanPointToMethod()
        {
            WriteMessage del = ReturnMessage;
            del += ReturnMessage;
            del += ReturnMessage2;

            var result = del("This is message from delegate");


            Assert.Equal(3, counter);
        }

        private string ReturnMessage(string message)
        {
            counter++;
            return message;
        }

        private string ReturnMessage2(string message)
        {
            counter++;
            return message;
        }

        [Fact]
        public void GetEmployeeReturnsNotSameObjects()
        {
            Assert.NotSame(this.emp1, this.emp2);
        }

        [Fact]
        public void GetEmployeeReturnsNotSameByRefObjects()
        {
            Assert.False(Object.ReferenceEquals(this.emp1, this.emp2));
        }

        [Fact]
        public void GetEmployeeReturnsSameObjects()
        {
            Assert.Same(this.emp2, this.emp3);
        }

        [Fact]
        public void GetEmployeeReturnsEqualsObjects()
        {
            Assert.Equal(this.emp2, this.emp3);
        }

        public void CanSetNameFromReference()
        {
            //var emp1 = GetEmployee("Zygmunt", 2343.22); 
            this.SetName(out emp1, "Zachary");
            Assert.Equal("Zachary", emp1.Name);
        }

        private Employee GetEmployee(string name, double earn)
        {
            return new Employee(name, earn);
        }

        private void SetName(out Employee emp, string name)
        {
            emp = new Employee(name, 12143);
        }
    }
}

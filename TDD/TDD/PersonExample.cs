using Xunit;

namespace TDD
{
    public class PersonExample
    {
        [Fact]
        public void Person_toString_should_return_Name_and_Surname()
        {
            var person = new Person
            {
                Name = "Jan",
                Surname = "Kowalski"
            };

            var result = person.ToString();

            Assert.Equal("Jan Kowalski", result);
        }

        [Fact]
        public void Person_toString_without_name_returns_surname()
        {
            var person = new Person
            {
                Surname = "Kowalski"
            };

            var result = person.ToString();

            Assert.Equal("Kowalski" , result);

        }

        [Fact]
        public void Person_toString_without_surname_returns_name()
        {
            var person = new Person
            {
                Name = "Jan"
            };

            var result = person.ToString();

            Assert.Equal("Jan", result);

        }

    }
          
    public class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public override string ToString()
        {
            return $"{Name} {Surname}".TrimStart().TrimEnd();
        }
    }
}

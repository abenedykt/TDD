using Xunit;

namespace TDD
{
    public class FizzBuzzGameTests
    {
        [Fact]
        public void When_input_is_1_should_return_one()
        {
            // arrange
            var game = new FizzBuzzGame();
            // act
            var result = game.Play(1);

            // assert
            Assert.Equal("1", result);
        }

        [Fact]
        public void When_input_is_2_should_return_two()
        {
            // arrange
            var game = new FizzBuzzGame();
            // act
            var result = game.Play(2);

            // assert
            Assert.Equal("2", result);
        }

        [Fact]
        public void When_input_is_3_should_return_Fizz()
        {
            // arrange
            var game = new FizzBuzzGame();
            // act
            var result = game.Play(3);

            // assert
            Assert.Equal("Fizz", result);
        }

        [Fact]
        public void When_input_is_5_should_return_Buzz()
        {
            // arrange
            var game = new FizzBuzzGame();
            // act
            var result = game.Play(5);

            // assert
            Assert.Equal("Buzz", result);
        }

        [Fact]
        public void When_input_is_15_should_return_Fizz_Buzz()
        {
            // arrange
            var game = new FizzBuzzGame();
            // act
            var result = game.Play(15);

            // assert
            Assert.Equal("Fizz Buzz", result);
        }
    }

    public class FizzBuzzGame
    {
        public string Play(int value)
        {
            if (value < 1) throw new InvalidArgumentException();

            if (DivisibleBy15(value)) return "Fizz Buzz";
            if (DivisibleBy3(value)) return "Fizz";
            if (DivisibleBy5(value)) return "Buzz";
            return value.ToString();
        }

        private static bool DivisibleBy5(int value)
        {
            return Divisible(value, 5);
        }

        private static bool DivisibleBy3(int value)
        {
            return Divisible(value, 3);
        }

        private static bool DivisibleBy15(int value)
        {
            return Divisible(value, 15);
        }

        private static bool Divisible(int value, int divisor)
        {
            return value % divisor == 0;
        }

    }
}

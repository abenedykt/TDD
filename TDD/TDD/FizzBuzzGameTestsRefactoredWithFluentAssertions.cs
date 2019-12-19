using FluentAssertions;
using Xunit;

namespace TDD
{
    public class FizzBuzzGameRefactoredWithFluentAssertionsTests
    {
        [Theory,
        InlineData(1, "1"),
        InlineData(2, "2"),
        InlineData(3, "Fizz"),
        InlineData(5, "Buzz"),
        InlineData(15, "Fizz Buzz")]
        public void Should_return_values_according_to_FizzBuzz_game_rulez(int input, string expected)
        {

            // arrange
            var game = new FizzBuzzGame();
            
            // act
            var result = game.Play(input);

            // assert
            result.Should().Be(expected);
        }

        [Fact]
        public void Should_throw_invalid_argument_exception_when_input_is_lower_than_1()
        {
            var game = new FizzBuzzGame();

            Assert.Throws<InvalidArgumentException>(()=> game.Play(-1));
        }
    }
}

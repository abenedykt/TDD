using System;
using Xunit;

namespace TDD
{
    public class XunitExampleTests : IDisposable
    {
        public XunitExampleTests()
        {
        }
                
        [Fact]
        public void Unit_test_example()
        {
            // arrange

            // act

            // assert
            Assert.True(true);
        }

        public void Dispose()
        {
        }

    }
}

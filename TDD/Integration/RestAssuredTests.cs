using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Newtonsoft.Json.Linq;
using RA;
using Xunit;

namespace Integration
{
    public class RestAssuredTests
    {
        [Fact]
        public void Testing_api_example_with_restassured()
        {
            var json = new RestAssured()
                .Given()
                    .Name("fetching posts")
                .When()
                    .Get("https://jsonplaceholder.typicode.com/posts")
                .Then()
                .Retrieve(x => x) as JArray;

            var result = json.ToObject<IEnumerable<Post>>();

            Assert.Equal(100, result.Count());
        }

        [Fact]
        public void Testing_api_example_with_restassured_and_fluent_assertions()
        {
            var json = new RestAssured()
                .Given()
                    .Name("fetching posts")
                .When()
                    .Get("https://jsonplaceholder.typicode.com/posts")
                .Then()
                .Retrieve(x => x) as JArray;

            var result = json.ToObject<IEnumerable<Post>>();

            result.Should().HaveCount(100);
        }

    }
}

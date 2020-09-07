using FluentAssertions;
using System.Net;
using System.Threading.Tasks;
using MyApi.Integration.Fixtures;
using Xunit;
using Microsoft.EntityFrameworkCore;
using MyApi.Data;

namespace MyApi.Integration.Scenarios
{

    public class ValuesTest
    {
        private readonly TestContext _testContext;
        private readonly MyApiContext contextMemory;
        public ValuesTest()
        {
            _testContext = new TestContext();

            var optionsBuilder = new DbContextOptionsBuilder<MyApiContext>();
            optionsBuilder.UseInMemoryDatabase("MemoryDB");
            contextMemory = new MyApiContext(optionsBuilder.Options);
        }


        [Fact]
        public async Task Values_Get_ReturnsOkResponse()
        {

            var response = await _testContext.Client.GetAsync("/api/values");
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Values_GetById_ValuesReturnsOkResponse()
        {
            var response = await _testContext.Client.GetAsync("/api/values/5");
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Values_GetById_ReturnsBadRequestResponse()
        {
            var response = await _testContext.Client.GetAsync("/api/values/XXX");
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task Values_GetById_CorrectContentType()
        {
            var response = await _testContext.Client.GetAsync("/api/values/5");
            response.EnsureSuccessStatusCode();
            response.Content.Headers.ContentType.ToString().Should().Be("text/plain; charset=utf-8");
        }
    }
}

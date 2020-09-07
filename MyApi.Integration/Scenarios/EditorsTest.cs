using FluentAssertions;
using System.Net;
using System.Threading.Tasks;
using MyApi.Integration.Fixtures;
using Xunit;

namespace MyApi.Integration.Scenarios
{
    public class EditorsTest
    {
        private readonly TestContext _testContext;
        public EditorsTest()
        {
            _testContext = new TestContext();
        }

        [Fact]
        public async Task Editors_Get_ReturnsOkResponse()
        {

            var response = await _testContext.Client.GetAsync("/api/editors");
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

    }
}

using Xunit;
using FluentAssertions;

namespace TestAspnetWebAPI
{
    public class DummyFacts
    {
        [Fact]
        public void should_do_something()
        {
            var client1 = new SelfHostServer(9998).CreateJsonClient();
            var client2 = new SelfHostServer(9997).CreateJsonClient();
            const string payload = @"{""Name"": ""John""}";
            var message1 = client1.Post("staff", payload);
            var result1 = message1.Content.ReadAsStringAsync().Result;
            result1.Should().BeEquivalentTo(payload);
            var message2 = client2.Post("staff", payload);
            var result2 = message2.Content.ReadAsStringAsync().Result;
            result2.Should().BeEquivalentTo(result1);
        }
    }
}
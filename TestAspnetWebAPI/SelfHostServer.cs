using System.Web.Http.SelfHost;
using System.Web.Http;

namespace TestAspnetWebAPI
{
    public class SelfHostServer
    {
        private readonly HttpSelfHostServer _server;

        public SelfHostServer(int port = 9999)
        {
            Address = string.Format("http://localhost:{0}", port);
            var configuration = new HttpSelfHostConfiguration(Address);
            configuration.Routes.MapHttpRoute("default", "{controller}/{id}", new {id = RouteParameter.Optional});
            _server = new HttpSelfHostServer(configuration);
            _server.OpenAsync().Wait();
        }

        protected string Address { get; set; }

        public JsonClient CreateJsonClient()
        {
            return new JsonClient(Address);
        }
    }

    public class StaffController : ApiController
    {
        public Staff Post(Staff staff)
        {
            return staff;
        }
    }

    public class Staff
    {
        public string Name { get; set; }
    }
}

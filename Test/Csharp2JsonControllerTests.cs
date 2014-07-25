using csharp2json;
using Ploeh.AutoFixture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Hosting;
using Xunit;

namespace Test
{
    public class Csharp2JsonControllerTests
    {
        private Csharp2JsonController sut;
        private IFixture fixture;

        public Csharp2JsonControllerTests()
        {
            fixture = new Fixture();
            sut = new Csharp2JsonController(fixture);

            sut.Request = new HttpRequestMessage();
            sut.Request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration());
        }

        [Fact]
        public async Task Can_generate_json()
        {
            HttpResponseMessage result = sut.Post(Source.VALID_CLASS1);
            var json = await result.Content.ReadAsStringAsync();

            json = json.TrimStart('[').TrimEnd(']');

            var type = Types.From(Source.VALID_CLASS1).First();
            var instance = JsonConvert.DeserializeObject(json, type);
        }
    }
}

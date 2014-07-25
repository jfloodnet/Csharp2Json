using Ploeh.AutoFixture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Net.Http;
using Ploeh.AutoFixture.Kernel;

namespace csharp2json
{
    public class Csharp2JsonController : ApiController
    {
        private readonly IFixture fixture;

        public Csharp2JsonController(IFixture fixture)
        {
            this.fixture = fixture;
        }
        public HttpResponseMessage Post(string source)
        {
            var types = Types.From(source);
            var data = MakeData(types).ToArray();
            return Request.CreateResponse(data);      
        }

        private IEnumerable<object> MakeData(Type[] types)
        {            
            foreach (var item in types)
                yield return fixture.Create(item, new SpecimenContext(fixture));           
        }
    }
}
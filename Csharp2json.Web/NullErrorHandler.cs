using Nancy.ErrorHandling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Csharp2json.Web
{
    public class NullErrorHandler : IStatusCodeHandler
    {
        public void Handle(Nancy.HttpStatusCode statusCode, Nancy.NancyContext context)
        {
            
        }

        public bool HandlesStatusCode(Nancy.HttpStatusCode statusCode, Nancy.NancyContext context)
        {
            return true;
        }
    }
}

namespace Csharp2json.Web
{
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.IO;
    using Microsoft.CSharp;
    using Nancy;
    using Nancy.ModelBinding;
    using Ploeh.AutoFixture;
    using Ploeh.AutoFixture.Kernel;
    using System.Linq;
    using Csharp2json.Core;

    public class IndexModule : NancyModule
    {
        public IndexModule()
        {
            Get["/"] = parameters =>
            {
                return View["index"];
            };

            Post["/"] = parameters =>
            {
                string source = this.Bind();
                return TryMakeJsonFrom(source);        
            };
        }

        private Response TryMakeJsonFrom(string source)
        {
            try
            {
                var types = MakeTypes.From(source);
                var data = MakeObjects.From(types).ToArray();
                return Response.AsJson(data);
            }
            catch (TypeGeneratorException ex)
            {
                return Response.AsJson(Display(ex.Errors), 
                    HttpStatusCode.BadRequest);
            }            
        }

        private string[] Display(CompilerErrorCollection errors)
        {             
            return Enumerable.Range(0, errors.Count)
                .Select(i => 
                {
                    return string.Format(
                        "Error {0}: {1}, Line: {2},  Column: {3}", 
                        errors[i].ErrorNumber, 
                        errors[i].ErrorText, 
                        errors[i].Line, 
                        errors[i].Column);
                }               
                ).ToArray();
        }
    }
}
using Nancy;
using Nancy.ModelBinding;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Csharp2json.Web
{
    public class BodyAsStringModelBinder : IModelBinder
    {
        public bool CanBind(Type modelType)
        {
            return modelType == typeof(string);
        }

        public object Bind(NancyContext context, Type modelType, object instance, BindingConfig configuration, params string[] blackList)
        {
            StreamReader reader = new StreamReader(context.Request.Body);
            return reader.ReadToEnd();
        }
    }
}
namespace Csharp2json.Web
{
    using Nancy;
    using Nancy.Bootstrapper;
    using Nancy.Conventions;
    using System;
    using System.Collections.Generic;

    public class Bootstrapper : DefaultNancyBootstrapper
    {
        // The bootstrapper enables you to reconfigure the composition of the framework,
        // by overriding the various methods and properties.
        // For more information https://github.com/NancyFx/Nancy/wiki/Bootstrapper

        protected override void ConfigureConventions(NancyConventions nancyConventions)
        {
            nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("Static", @"Static"));
            base.ConfigureConventions(nancyConventions);
        }

        protected override NancyInternalConfiguration InternalConfiguration
        {
            get
            {
                return NancyInternalConfiguration.WithOverrides(
                    builder => builder.StatusCodeHandlers = new List<Type>() {
                typeof(NullErrorHandler)
            });
            }
        }
    }
}
using csharp2json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Should;
using System.Net.Http;
using System.Web.Http.Hosting;
using System.Web.Http;
using Ploeh.AutoFixture;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Test
{
    public static class Source
    {
        public static readonly string VALID_CLASS1 = @"
public class Test1
{
    public string TestString {get;set;}
    public int TestInteger {get;set;}
}
";

        public static readonly string VALID_CLASS2 = @"
public class Test2
{
    public string TestString {get;set;}
    public int TestInteger {get;set;}
}
";

        public static readonly string INVALID_CLASS = @"
public { Test class

    public string TestString {get;set;}
    public int TestInteger {get;set;}
}
";
    }
}

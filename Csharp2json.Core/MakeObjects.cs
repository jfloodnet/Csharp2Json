using Ploeh.AutoFixture;
using Ploeh.AutoFixture.Kernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp2json.Core
{
    public static class MakeObjects
    {
        public static IEnumerable<object> From(Type[] types)
        {
            return MakeData(types);
        }

        private static IEnumerable<object> MakeData(Type[] types)
        {
            var fixture = new Fixture();
            var context = new SpecimenContext(fixture);
            foreach (var item in types)
                yield return fixture.Create(item, context);
        }
    }
}

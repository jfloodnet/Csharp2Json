using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp2json.Core
{
    public static class MakeTypes
    {
        public static Type[] From(string source)
        {
            CodeDomProvider codeProvider = new CSharpCodeProvider();

            CompilerParameters parameters = new CompilerParameters();

            parameters.GenerateInMemory = true;
            parameters.GenerateExecutable = false;
            parameters.IncludeDebugInformation = false;

            CompilerResults results = codeProvider.CompileAssemblyFromSource(parameters, source);

            if (results.Errors.HasErrors)
            {
                throw new TypeGeneratorException(results.Errors);
            }

            return results.CompiledAssembly.GetTypes();
        }
    }

    public class TypeGeneratorException : Exception
    {
        public readonly CompilerErrorCollection Errors;

        public TypeGeneratorException(CompilerErrorCollection errors)
        {
            this.Errors = errors;
        }
    }
}

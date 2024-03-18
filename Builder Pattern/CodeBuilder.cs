using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Builder_Pattern
{
    public interface ICodeBuilder
    {
        public ICodeBuilder AddField(string feildName, string feildType);
    }
    public class CodeBuilder : ICodeBuilder
    {
        string className;
        List<Tuple<string, string>> lt = new List<Tuple<string, string>>();
        public CodeBuilder(string className)
        {
            this.className = className;
        }

        public ICodeBuilder AddField(string feildName, string feildType)
        {
            lt.Add(Tuple.Create(feildName, feildType));
            return this;
        }

        override public string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine("public class " + this.className);
            sb.AppendLine("{");
            foreach (var tup in lt)
            {
                sb.AppendLine("public " + tup.Item2 + " " + tup.Item1 + ";");
            }
            sb.AppendLine("}");
            return sb.ToString();
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.Serialization;

namespace Engine.Parser
{
    class Variable
    {
        //[YamlMember(typeof(Variable), Alias = "Name")]
        public string Name { get; set; }
        public string Type { get; set; }
        public bool OverWrite { get; set; }
        public Object Value { get; set; }

        public dynamic getValue()
        {
            Type t1 = System.Type.GetType(Type);
            return Convert.ChangeType(Value, t1);
        }
    }
}

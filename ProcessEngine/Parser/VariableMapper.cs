using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Parser
{
    class VariableMapper : BaseMapper<Variable>
    {
        public VariableMapper() : base()
        {
            mapperDictionary.Add("ClassID", "Engine.Parser.Variable");
            mapperDictionary.Add("Name", "Name");
            mapperDictionary.Add("Type", "Type");
            mapperDictionary.Add("OverWrite", "OverWrite");
            mapperDictionary.Add("Value", "Value");
        }

        public override Variable mapperMethod(Object variableDictionary)
        {
            deserializedYaml = (Dictionary<object, object>)variableDictionary;
            Variable obj = (Variable)Assembly.GetExecutingAssembly().CreateInstance(mapperDictionary.ElementAt(0).Value);

            //Setting Variable properties
            for (int i = 1; i < 5; i++)
                setNormalProperty(obj, i);

            return obj; 
        } 
    }
}

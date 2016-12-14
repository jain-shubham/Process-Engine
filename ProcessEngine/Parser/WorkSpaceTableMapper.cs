using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Parser
{
    class WorkSpaceTableMapper : BaseMapper<WorkSpaceTable>
    {
        public WorkSpaceTableMapper() : base()
        {
            mapperDictionary.Add("ClassID", "WorkSpaceTable");
            mapperDictionary.Add("WorkSpaceTables", "Name");
        }

        public override WorkSpaceTable mapperMethod(object tableYaml)
        {
            string s1 = (string)tableYaml;
            this.mapperDictionary["ClassID"] = "Engine.Parser." +mapperDictionary["ClassID"];
            deserializedYaml = new Dictionary<object, object>();
            deserializedYaml.Add(mapperDictionary.ElementAt(1).Key, s1);
            WorkSpaceTable obj = (WorkSpaceTable)Assembly.GetExecutingAssembly().CreateInstance(mapperDictionary.ElementAt(0).Value);
            // Setting properties
            setNormalProperty(obj, 1);

            return obj;
        }
    }
}

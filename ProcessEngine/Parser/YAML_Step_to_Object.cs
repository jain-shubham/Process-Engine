using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.Serialization;

namespace Engine.Parser
{
    class YAML_Step_to_Object
    {
        public static void execute()
        {
            var Step = new
            {
                StepID = "StepID01",
                StepName = "LoadEmployeeAttendance ",
                StepType = "FileToTable",
                Attributes = new[]
                {
                    "EmployeeID",
                    "DepartmentID",
                    "Status",
                    "InTime",
                    "OutTime"
                }
            };

            //Serialization
            var serializer = new Serializer();
            string serializedString = serializer.Serialize(Step);

            //Deserialization to Dictionary<>
            var serializedString_TextReader = new StringReader(serializedString);
            var deserializer = new Deserializer();
            Dictionary<object, object> step1Dictionary = (Dictionary<object, object>)deserializer.Deserialize(serializedString_TextReader);

            StepMapper stepMapper = new StepMapper();
            //IStep step1 = (IStep)stepMapper.mapper(step1Dictionary);

        }
    }
}

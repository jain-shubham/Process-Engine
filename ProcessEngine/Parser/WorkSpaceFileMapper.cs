using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Parser
{
    class IWorkSpaceFileMapper : BaseMapper<IWorkSpaceFile>
    {
        public IWorkSpaceFileMapper() : base()
        {
            mapperDictionary.Add("ClassID", "");
            mapperDictionary.Add("FileFormat", "FileType");
            mapperDictionary.Add("Name", "Name");
            mapperDictionary.Add("RowDelimeter", "RowDelimeter");
            mapperDictionary.Add("ColumnDelimeter", "ColumnDelimeter");
            mapperDictionary.Add("Path", "Path");
        }

        public override IWorkSpaceFile mapperMethod(Object deserializedYamlFiles)
        {
            deserializedYaml = (Dictionary<object, object>)deserializedYamlFiles;

            this.mapperDictionary["ClassID"] = "Engine.Parser." + this.deserializedYaml[mapperDictionary.ElementAt(1).Key];

            IWorkSpaceFile obj = (IWorkSpaceFile)Assembly.GetExecutingAssembly().CreateInstance(mapperDictionary.ElementAt(0).Value);

            // Setting properties
            for (int i = 1; i < 6; i++)
                setNormalProperty(obj, i);

            return obj;
        }
    }
}

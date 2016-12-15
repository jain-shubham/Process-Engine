using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Parser
{
    class JobMapper : BaseMapper<JobModel>
    {
        public JobMapper() : base()
        {
            mapperDictionary.Add("ClassID", "Engine.Parser.JobModel");
            mapperDictionary.Add("JobName", "Name");
            mapperDictionary.Add("JobID", "ID");
            mapperDictionary.Add("JobState", "State");
            mapperDictionary.Add("JobStatus", "Status");
            mapperDictionary.Add("Parameters", "Parameters");
            mapperDictionary.Add("LocalVariables", "LocalVariables");
            mapperDictionary.Add("Steps", "Steps");
            mapperDictionary.Add("WorkSpaceTables", "WorkSpaceTables");
            mapperDictionary.Add("WorkSpaceFiles", "WorkSpaceFiles");
        }

        public override JobModel mapperMethod(Object deserializedYamlJob)
        {
            this.deserializedYaml = (Dictionary<object,object>)deserializedYamlJob;
            
            JobModel obj = (JobModel)Assembly.GetExecutingAssembly().CreateInstance(mapperDictionary.ElementAt(0).Value);

            // Setting JobName, JobID, JobState, JobStatus
            for (int i = 1; i < 5; i++)
                setNormalProperty(obj, i);

            // Setting LocalVariables and Parameters
            for (int i = 5; i < 7; i++)
                setNestedListProperty<Variable>(obj, i);

            // Setting WorkSpaceTables
            setListProperty<WorkSpaceTable>(obj, 8);

            // Setting WorkSpaceFiles
            setNestedListProperty<IWorkSpaceFile>(obj, 9);

            // Setting Steps
            setNestedListProperty<IStep>(obj, 7);

            return obj;
        }
    }
}

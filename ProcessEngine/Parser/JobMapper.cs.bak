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

        //private Dictionary<string, string> mapperDictionary;
        //private Dictionary<object, object> deserializedYamlJobDic;

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

        //private void setProperty(JobModel obj, int index)
        //{
        //    string propName;
        //    PropertyInfo propInfo;
        //    Type type = Type.GetType(obj.ToString());
        //    try
        //    {
        //        propName = mapperDictionary.ElementAt(index).Value;
        //        propInfo = type.GetProperty(propName);
        //        Type propTargetType = propInfo.PropertyType;
        //        var value = Convert.ChangeType(deserializedYamlJobDic[mapperDictionary.ElementAt(index).Key], propTargetType);
        //        propInfo.SetValue(obj, value, null);
        //    }
        //    catch(Exception e)
        //    {
        //        return;
        //    }

        //}

        //private void setVariableLists(JobModel obj, int index)
        //{
        //    string propName;
        //    PropertyInfo propInfo;
        //    Type type = Type.GetType(obj.ToString());
        //    try
        //    {
        //        propName = mapperDictionary.ElementAt(index).Value;
        //        propInfo = type.GetProperty(propName);
        //        Type propTargetType = propInfo.PropertyType.GetGenericArguments().Single();

        //        var variableList = deserializedYamlJobDic[mapperDictionary.ElementAt(index).Key];

        //        //var listType = typeof(List<>);
        //        //var constructedListType = listType.MakeGenericType(propTargetType);
        //        //var list = Activator.CreateInstance(constructedListType);
        //        List<object> varDictionaryList = (List<object>)variableList;
        //        List<Variable> variables = new List<Variable>();
        //        foreach (Dictionary<object, object> variable in varDictionaryList)
        //        {
        //            VariableMapper varMapper = new VariableMapper();
        //            Object innerObj = varMapper.mapper(variable);
        //            variables.Add((Variable)innerObj);
        //        }
        //        //var value = Convert.ChangeType(variables, propTargetType);
        //        propInfo.SetValue(obj, variables, null);
        //    }
        //    catch (Exception e)
        //    {
        //        return;
        //    }          
        //}

        private void setStepLists(JobModel obj, int index)
        {
            string propName;
            PropertyInfo propInfo;
            Type type = Type.GetType(obj.ToString());
            try
            {
                propName = mapperDictionary.ElementAt(index).Value;
                propInfo = type.GetProperty(propName);
                Type propTargetType = propInfo.PropertyType.GetGenericArguments().Single();

                var stepList = deserializedYaml[mapperDictionary.ElementAt(index).Key];

                //var listType = typeof(List<>);
                //var constructedListType = listType.MakeGenericType(propTargetType);
                //var list = Activator.CreateInstance(constructedListType);
                List<object> stepDictionaryList = (List<object>)stepList;
                List<IStep> steps = new List<IStep>();
                foreach (Dictionary<object, object> step in stepDictionaryList)
                {
                    StepMapper mapper = new StepMapper();
                    IStep innerObj = mapper.mapper(step, obj);

                    steps.Add((IStep)innerObj);
                }
                //var value = Convert.ChangeType(variables, propTargetType);
                propInfo.SetValue(obj, steps, null);
            }
            catch (Exception e)
            {
                return;
            }
        }

        //private void setWorkSpaceTables(JobModel obj, int index)
        //{
        //    string propName;
        //    PropertyInfo propInfo;
        //    Type type = Type.GetType(obj.ToString());
        //    try
        //    {
        //        propName = mapperDictionary.ElementAt(index).Value;
        //        propInfo = type.GetProperty(propName);
        //        Type propTargetType = propInfo.PropertyType;

        //        List<object> tableList = (List<object>)deserializedYamlJobDic[mapperDictionary.ElementAt(index).Key];
        //        //var tableValue = tableList.ConvertAll(x => x.ToString());
        //        List<WorkSpaceTable> tables = new List<WorkSpaceTable>();
        //        foreach (object tableYaml in tableList)
        //        {
        //            WorkSpaceTableMapper mapper = new WorkSpaceTableMapper();
        //            tables.Add(mapper.map(tableYaml));
        //        }
        //        propInfo.SetValue(obj, tables, null);
        //    }
        //    catch (Exception e)
        //    {
        //        return;
        //    }
        //}

        //private void setWorkSpaceFiles(JobModel obj, int index)
        //{
        //    string propName;
        //    PropertyInfo propInfo;
        //    Type type = Type.GetType(obj.ToString());
        //    try
        //    {
        //        propName = mapperDictionary.ElementAt(index).Value;
        //        propInfo = type.GetProperty(propName);
        //        Type propTargetType = propInfo.PropertyType.GetGenericArguments().Single();

        //        var stepList = deserializedYamlJobDic[mapperDictionary.ElementAt(index).Key];

        //        //var listType = typeof(List<>);
        //        //var constructedListType = listType.MakeGenericType(propTargetType);
        //        //var list = Activator.CreateInstance(constructedListType);
        //        List<object> fileDictionaryList = (List<object>)stepList;
        //        List<IWorkSpaceFile> files = new List<IWorkSpaceFile>();
        //        foreach (Dictionary<object, object> file in fileDictionaryList)
        //        {
        //            WorkSpaceFileMapper mapper = new WorkSpaceFileMapper();
        //            IWorkSpaceFile innerObj = mapper.map(file);
        //            files.Add((IWorkSpaceFile)innerObj);
        //        }
        //        //var value = Convert.ChangeType(variables, propTargetType);
        //        propInfo.SetValue(obj, files, null);
        //    }
        //    catch (Exception e)
        //    {
        //        return;
        //    }
        //}

        private void setVersionTableInStep(JobModel job)
        {
            IStep step = job.Steps.ElementAt(0);
            //WorkSpaceTableVersion versionTable = new WorkSpaceTableVersion();
            //versionTable.initialize(job.WorkSpaceTables.ElementAt(0), null);
            //step.setInputData(versionTable);

            IStep step1 = job.Steps.ElementAt(1);
            WorkSpaceTableVersion versionTable1 = new WorkSpaceTableVersion();
            versionTable1.initialize(job.WorkSpaceTables.ElementAt(0), job.Steps.ElementAt(0).ID);
            step1.setInputData(versionTable1);

            IStep step2 = job.Steps.ElementAt(2);
            WorkSpaceTableVersion versionTable2 = new WorkSpaceTableVersion();
            versionTable2.initialize(job.WorkSpaceTables.ElementAt(0), job.Steps.ElementAt(0).ID);
            step2.setInputData(versionTable2);
        }

        public override JobModel mapperMethod(Object deserializedYamlJob)
        {
            this.deserializedYaml = (Dictionary<object,object>)deserializedYamlJob;
            
            JobModel obj = (JobModel)Assembly.GetExecutingAssembly().CreateInstance(mapperDictionary.ElementAt(0).Value);

            // Setting JobName, JobID, JobState, JobStatus
            for (int i = 1; i < 5; i++)
            {
                setNormalProperty(obj, i);
            }

            // Setting LocalVariables and Parameters
            for (int i = 5; i < 7; i++)
            {
                setNestedListProperty<Variable>(obj, i);
            }

            // Setting WorkSpaceTables
            setListProperty<WorkSpaceTable>(obj, 8);

            // Setting WorkSpaceFiles
            setNestedListProperty<IWorkSpaceFile>(obj, 9);
            this.setStepLists(obj, 7);
            this.setVersionTableInStep((JobModel)obj);

            return obj;
        }
    }
}

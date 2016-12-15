using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Parser
{
    class StepMapper
    {
        private Dictionary<string, string> stepMapperDictionary;
        private Dictionary<object, object> deserializedStepYamlDic;

        private void initialize()
        {
            stepMapperDictionary = new Dictionary<string, string>();
            stepMapperDictionary.Add("ClassID", "Engine.Parser");
            stepMapperDictionary.Add("StepID", "ID");
            stepMapperDictionary.Add("StepName", "Name");
            stepMapperDictionary.Add("StepType", "Type");
            stepMapperDictionary.Add("Attributes", "Attributes");
            stepMapperDictionary.Add("InputData", "InputData");
            stepMapperDictionary.Add("OutputData", "OutputData");
        }

        private void setProperty(Object obj, int index)
        {
            string propName;
            PropertyInfo propInfo;
            Type type = Type.GetType(obj.ToString());
            try
            {
                propName = stepMapperDictionary.ElementAt(index).Value;
                propInfo = type.GetProperty(propName);
                Type propTargetType = propInfo.PropertyType;
                var value = Convert.ChangeType(deserializedStepYamlDic[stepMapperDictionary.ElementAt(index).Key], propTargetType);
                propInfo.SetValue(obj, value, null);
            }
            catch (Exception e)
            {
                return;
            }

        }

        private void setListProperty(Object obj, int index)
        {
            string propName;
            PropertyInfo propInfo;
            Type type = Type.GetType(obj.ToString());
            try
            {
                propName = stepMapperDictionary.ElementAt(index).Value;
                propInfo = type.GetProperty(propName);
                Type propTargetType = propInfo.PropertyType;

                List<object> attList = (List<object>)deserializedStepYamlDic[stepMapperDictionary.ElementAt(index).Key];
                //var attListString = attList.ConvertAll(x => x.ToString());
                List<string> value = new List<string>();
                foreach (string s in attList)
                {
                    value.Add(s);
                }
                propInfo.SetValue(obj, value, null);
            }
            catch (Exception e)
            {
                return;
            }
        }

        private void setInputs(Object obj, JobModel job, int index)
        {
            string propName;
            PropertyInfo propInfo;
            Type type = Type.GetType(obj.ToString());
            try
            {
                propName = stepMapperDictionary.ElementAt(index).Value;
                propInfo = type.GetProperty(propName);
                Type propTargetType = propInfo.PropertyType;
                Dictionary<object, object> inputDic = new Dictionary<object, object>();
                inputDic = (Dictionary<object, object>)deserializedStepYamlDic[stepMapperDictionary.ElementAt(index).Key];

                List<IWorkSpaceFile> inputFiles = new List<IWorkSpaceFile>();
                List<object> inputFilesYaml = (List<object>)inputDic.ElementAt(0).Value;
                foreach (string s in inputFilesYaml)
                {
                    IWorkSpaceFile file = job.WorkSpaceFiles.First(x => x.Name == s);
                    inputFiles.Add(file);
                }

                string versionIDYaml = (string)inputDic.ElementAt(1).Value;

                WorkSpaceFileVersion inputData = new WorkSpaceFileVersion(inputFiles, versionIDYaml);

                propInfo.SetValue(obj, inputData, null);
            }
            catch (Exception e)
            {
                return;
            }
        }

        public IStep mapper(Dictionary<object, object> deserializedStepYaml, JobModel job)
        {
            this.deserializedStepYamlDic = deserializedStepYaml;
            this.initialize();

            this.stepMapperDictionary["ClassID"] = stepMapperDictionary["ClassID"] + "." + this.deserializedStepYamlDic["StepType"];

            IStep obj = (IStep)Assembly.GetExecutingAssembly().CreateInstance(stepMapperDictionary.ElementAt(0).Value);

            // Setting properties
            for (int i = 1; i < 4; i++)
                this.setProperty(obj, i);

            for (int i = 4; i < 5; i++)
                this.setListProperty(obj, i);

            this.setInputs(obj, job, 5);

            return obj;
        }

    }
}

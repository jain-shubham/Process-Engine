using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Parser
{
    class Trash
    {
        // Method that maps Yaml key-value pair to Job class. Method called is written at the end
        //private static Job jobObjectMapper(Dictionary<object, object> deserializedYamlJob)
        //{
        //    Job job1 = new Job();

        //    //Job Name
        //    job1.Name = (string)deserializedYamlJob.ElementAt(0).Value;

        //    //Job JobID
        //    job1.ID = Convert.ToInt32(deserializedYamlJob.ElementAt(1).Value);

        //    //Job JobState
        //    job1.State = (string)deserializedYamlJob.ElementAt(2).Value;

        //    //Parameters
        //    List<object> parametersList = (List<object>)deserializedYamlJob.ElementAt(3).Value;
        //    job1.Parameters = new List<Variable>();
        //    Variable v = new Variable();
        //    foreach (Dictionary<object, object> parameter in parametersList)
        //    {
        //        int i = 0;

        //        v.Name = (string)parameter.ElementAt(0).Value;
        //        v.Type = (string)parameter.ElementAt(1).Value;
        //        v.OverWrite = Convert.ToBoolean(parameter.ElementAt(2).Value);
        //        v.Value = parameter.ElementAt(3).Value;
        //        job1.Parameters.Add(v);
        //        i++;
        //    }

        //    //Local Variables
        //    List<object> localVariables = (List<object>)deserializedYamlJob.ElementAt(4).Value;
        //    job1.LocalVariables = new List<Variable>();
        //    v = new Variable();
        //    foreach (Dictionary<object, object> localVariabl in localVariables)
        //    {
        //        int i = 0;

        //        v.Name = (string)localVariabl.ElementAt(0).Value;
        //        v.Type = (string)localVariabl.ElementAt(1).Value;
        //        v.OverWrite = Convert.ToBoolean(localVariabl.ElementAt(2).Value);
        //        v.Value = localVariabl.ElementAt(3).Value;
        //        job1.LocalVariables.Add(v);
        //        i++;
        //    }
        //    return job1;

        //    //Method 2 
        //    //Job job1 = jobObjectMapper(job1Dictionary);

        //    //Method 1
        //    //Job newJob = (Job)deserializer.Deserialize(serializedString_TextReader, typeof(Job));
        //    //Variable v1 = newJob.LocalVariables[0];
        //    //Console.WriteLine(v1.getValue());



        //    // From JobMapper class, when reusable code applied 

        //    // Job.Name
        //    //var name = (string)deserializedYamlJob[jobMapperDictionary.ElementAt(0).Key];
        //    //propName = jobMapperDictionary.ElementAt(0).Value;
        //    //propInfo = type.GetProperty(propName);
        //    //propInfo.SetValue(j, name, null);
        //    //this.setProperty(j,0);


        //    // Job.ID
        //    //var id = Convert.ToInt32(deserializedYamlJob[jobMapperDictionary.ElementAt(1).Key]);
        //    //propName = jobMapperDictionary.ElementAt(1).Value;
        //    //propInfo = type.GetProperty(propName);
        //    //propInfo.SetValue(j, id, null);
        //    //this.setProperty(j, 1);

        //    // Job.State
        //    //var state = (string)deserializedYamlJob[jobMapperDictionary.ElementAt(2).Key];
        //    //propName = jobMapperDictionary.ElementAt(2).Value;
        //    //propInfo = type.GetProperty(propName);
        //    //propInfo.SetValue(j, state, null);
        //    //this.setProperty(j, 2);


        //    // Job.State
        //    //var status = (string)deserializedYamlJob[jobMapperDictionary.ElementAt(3).Key];
        //    //if(!status.Equals(null))
        //    //{

        //    //}
        //    //propName = jobMapperDictionary.ElementAt(2).Value;
        //    //propInfo = type.GetProperty(propName);
        //    //propInfo.SetValue(j, state, null);


        //    // Job.Parameters
        //    //var parameterList = deserializedYamlJob[jobMapperDictionary.ElementAt(4).Key];
        //    //propName = jobMapperDictionary.ElementAt(4).Value;
        //    //propInfo = type.GetProperty(propName);
        //    //List<Variable> parameters = new List<Variable>();
        //    //if(!parameterList.Equals(null))
        //    //{
        //    //    List<object>paramDictionaryList = (List<object>)parameterList;
        //    //    foreach (Dictionary<object, object> parameter in paramDictionaryList)
        //    //    {
        //    //        VariableMapper varMapper = new VariableMapper();
        //    //        Variable v = varMapper.mapper(parameter);
        //    //        parameters.Add(v);
        //    //    }
        //    //    propInfo.SetValue(j, parameters, null);
        //    //}
        //    //this.setListProperty(j, 4);

        //    // Job.LocalVariables
        //    //var localVarList = deserializedYamlJob[jobMapperDictionary.ElementAt(5).Key];
        //    //propName = jobMapperDictionary.ElementAt(5).Value;
        //    //propInfo = type.GetProperty(propName);
        //    //List<Variable> localVariables = new List<Variable>();
        //    //if (!parameterList.Equals(null))
        //    //{
        //    //    List<object> localVarDictionaryList = (List<object>)localVarList;
        //    //    foreach (Dictionary<object, object> localVariable in localVarDictionaryList)
        //    //    {
        //    //        VariableMapper varMapper = new VariableMapper();
        //    //        Variable v = varMapper.mapper(localVariable);
        //    //        localVariables.Add(v);
        //    //    }
        //    //    propInfo.SetValue(j, localVariables, null);
        //    //}
        //    //this.setListProperty(j, 5);

        //}

    }
}

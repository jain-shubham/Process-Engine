using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.Serialization;

namespace Engine.Parser
{
    class YAML_Parse_2
    {
        public static JobModel execute()
        {

            var Job = new
            {
                JobName = "Job1",
                JobID = 1,
                JobState = "Draft",
                JobStatus = false,
                Parameters = new[]
                {
                    new
                    {
                        Name = "Variable1",
                        Type = "System.Int32",
                        OverWrite = true,
                        Value = 10
                    },
                    new
                    {
                        Name = "Variable2",
                        Type = "System.Int32",
                        OverWrite = true,
                        Value = 20
                    }
                   
                },
                LocalVariables = new[]
                {
                    new
                    {
                        Name = "Variable3",
                        Type = "System.Int32",
                        OverWrite = "true",
                        Value = 30
                    }
                },
                Steps = new[]
                {
                    new
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
                    },
                    new
                    {
                        StepID = "StepID02",
                        StepName = "LoadEmployeeAttendance2 ",
                        StepType = "FileToTable",
                        Attributes = new[]
                        {
                            "EmployeeID",
                            "DepartmentID",
                            "Status",
                            "InTime",
                            "OutTime"
                        }
                    },
                    new
                    {
                        StepID = "StepID03",
                        StepName = "LoadEmployeeAttendance3 ",
                        StepType = "FileToTable",
                        Attributes = new[]
                        {
                            "EmployeeID",
                            "DepartmentID",
                            "Status",
                            "InTime",
                            "OutTime"
                        }
                    }
                },
                WorkSpaceTables = new[]
                {
                    "Table1",
                    "Table2"
                },
                WorkSpaceFiles = new[]
                {
                    new
                    {
                        Name = "File1",
                        FileFormat = "CSV",
                        ColumnDelimeter = ",",
                        RowDelimeter = "\n",
                        Path = ""
                    },
                    new
                    {
                        Name = "File2",
                        FileFormat = "Excel",
                        ColumnDelimeter = ",",
                        RowDelimeter = "\n",
                        Path = ""
                    }
                }
            };

            var serializer = new Serializer();
            string serializedString = serializer.Serialize(Job);
            var serializedString_TextReader = new StringReader(serializedString);
            var deserializer = new Deserializer();

            Dictionary<object, object> job1Dictionary = (Dictionary<object, object>)deserializer.Deserialize(serializedString_TextReader);

            JobMapper j1 = new JobMapper();
            JobModel job2 = (JobModel)j1.mapperMethod(job1Dictionary);

            //CSVFile file1 = new CSVFile();


            return job2;
        }
    }
}

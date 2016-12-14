using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Engine;

namespace Engine.JobScheduler
{
    /// <summary>
    /// Main class to demonsrate the scheduling.
    /// </summary>
    class Program
    {
        static void Main2(string[] args)
        {
            
            // Creating JobParameter Instances.
            JobParameters jobParam1=new JobParameters{
                JobType=JobTypeCatalogueEnum.FixedJob1, 
                Id=1, 
                Title="Job1",
                // Setting the start time as (current time + n seconds)
                StartTime=DateTime.Now.AddSeconds(2)    
            };
     

            JobParameters jobParam2 = new JobParameters
            {
                JobType = JobTypeCatalogueEnum.FixedJob1,
                Id = 2,
                Title = "Job2",
                StartTime = DateTime.Now.AddSeconds(20)
            };

            JobParameters jobParam3 = new JobParameters
            {
                JobType = JobTypeCatalogueEnum.DynamicJobCreater,
                Id = 3,
                Title = "Job3",
                StartTime = DateTime.Now.AddSeconds(7)
            };

            JobParameters jobParam4 = new JobParameters
            {
                JobType = JobTypeCatalogueEnum.FixedJob1,
                Id = 4,
                Title = "Job4",
                StartTime = DateTime.Now.AddSeconds(25)
            };

            JobParameters jobParam5 = new JobParameters
            {
                JobType = JobTypeCatalogueEnum.FixedJob1,
                Id = 5,
                Title = "Job5",
                StartTime = DateTime.Now.AddSeconds(25)
            };

            // Creating Scheduler.
            Scheduler scheduler = Scheduler.Create();


            // Adding job parameters.
            scheduler.jobParametersTable.Add(jobParam1);
            scheduler.jobParametersTable.Add(jobParam2);
            scheduler.jobParametersTable.Add(jobParam3);
            scheduler.jobParametersTable.Add(jobParam4);
            scheduler.jobParametersTable.Add(jobParam5);


            // Starting scheduling.
            scheduler.Start();

            // To hold the main thread.
            scheduler.WaitTillAllTasksComplete();
            Console.WriteLine("All tasks completed. Good Bye !!");
           
            // Console.ReadKey();  
            

        }
    }
}

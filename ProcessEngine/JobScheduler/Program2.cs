using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Engine;

namespace Engine.JobScheduler
{
    class Program2
    {
        static void Main0(string[] args)
        {

            // Job Parameter Instances
            JobParameters jobParam1 = new JobParameters
            {
                JobType = JobTypeCatalogueEnum.FixedJob1,
                Id = 1,
                Title = "Job1",
                StartTime = DateTime.Now.AddSeconds(2)
            };


            JobParameters jobParam2 = new JobParameters
            {
                JobType = JobTypeCatalogueEnum.FixedJob1,
                Id = 2,
                Title = "Job2",
                StartTime = DateTime.Now.AddSeconds(10)
            };

            //JobParameters jobParam3 = new JobParameters
            //{
            //    JobType = JobTypeCatalogue.DynamicJobCreater,
            //    Id = 3,
            //    Title = "Job3",
            //    StartTime = DateTime.Now.AddSeconds(6)
            //};

            JobParameters jobParam4 = new JobParameters
            {
                JobType = JobTypeCatalogueEnum.FixedJob1,
                Id = 4,
                Title = "Job4",
                StartTime = DateTime.Now.AddSeconds(16)
            };

            JobParameters jobParam5 = new JobParameters
            {
                JobType = JobTypeCatalogueEnum.FixedJob2,
                Id = 99999,
                Title = "Time Eater Job",
                StartTime = DateTime.Now.AddSeconds(1)
            };

            // Scheduler 
            Scheduler scheduler = Scheduler.Create();


            // Adding job parameters
            scheduler.jobParametersTable.jobParams.Add(jobParam1);
            scheduler.jobParametersTable.jobParams.Add(jobParam2);
            //scheduler.jobParametersTable.jobParams.Add(jobParam3);
            scheduler.jobParametersTable.jobParams.Add(jobParam4);
            scheduler.jobParametersTable.jobParams.Add(jobParam5);


            // Starting scheduling
            scheduler.Start();

            // 
            Console.ReadKey();  // to hold the main thread


        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Engine;

namespace Engine.JobScheduler.AllJobs
{

    /* For the demonstration of adding a new job to the scheduler. */
    /// <summary>
    /// This job is creating a new Job(Print job) 
    /// and giving it to the scheduler to schedule it at a particular time.
    /// </summary>
    class DynamicJobCreater : AcyclicJobModel
    {
        public DynamicJobCreater(int id, string title, DateTime startTime)
            : base(id, title, startTime)
        {

        }

        public override void ExecuteAsync()
        {
            base.ExecuteAsync();
            Console.WriteLine(" -> Dyanmic Job creater executed (creating print job) ");
            
            // Getting the scheduler instance.
            Scheduler scheduler = Scheduler.Create();

            // Creating a new job parameter object.
            JobParameters jobParamD = new JobParameters
            {
                JobType = JobTypeCatalogueEnum.PrintJob,
                Id = 111,
                Title = "Runtime Job",
                StartTime = DateTime.Now.AddSeconds(6)
            };

            // Scheduling the new job.
            scheduler.AddJob(jobParamD);

            Console.WriteLine("Job Completed with Id = {0}", this.Id);
        }

        // overriding and overloading !!
        public void ExecuteAsync(string message)
        {
            base.ExecuteAsync();
            Console.WriteLine(" Print Job -> " + message);
        }
    }
}

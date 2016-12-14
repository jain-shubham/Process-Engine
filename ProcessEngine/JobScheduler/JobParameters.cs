using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.JobScheduler
{
    /// <summary>
    /// Class to encapsulate essential attributes(which are required by the Scheduler)
    /// of a job to be scheduled.
    /// </summary>
    class JobParameters                 // struct should be used instead of class !
    {
        public JobTypeCatalogueEnum JobType { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime StartTime { get; set; }

        public JobParameters()
        {
        }

        public JobParameters(JobTypeCatalogueEnum jobType, int id, string title, DateTime startTime)
        {
            this.JobType = jobType;
            this.Id = id;
            this.Title = title;
            this.StartTime = startTime;
        }

    }
}

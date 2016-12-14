using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.JobScheduler
{
    /// <summary>
    /// Class to encapsulate collection of jobparameters objects.
    /// <see cref="JobParameters"/>
    /// </summary>
    class JobParametersTable       
    {
        // List
        public List<JobParameters> jobParams;   // public 

        public JobParametersTable()
        {
            jobParams = new List<JobParameters>();
        }

        public void Add(JobParameters jobParameters)
        {
            this.jobParams.Add(jobParameters);
        }

    }
}

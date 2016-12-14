using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Engine;

namespace Engine.JobScheduler
{
    /// <summary>
    /// Class responsible for getting the instance of the job,
    /// using JobRepsitory class <see cref="JobRepository"/> and executing the job.
    /// </summary>
    /// -krishan
    class JobRunner
    {

        
        // Job Repository 
        JobsRepository jobsRepository; 
        
        
        public JobRunner()
        {
            jobsRepository = new JobsRepository();
        }
        
        /// <summary>
        /// Gets the instance of the job and executes it.
        /// </summary>
        /// <param name="jobParameters"></param>
        public void Run(JobParameters jobParameters)
        {
            // Getting instance of the particular job.
            AcyclicJobModel job = jobsRepository.GetInstance(jobParameters);
            
            // Executing the job.
            job.ExecuteAsync();             /* await ?? */
        }
    }
}

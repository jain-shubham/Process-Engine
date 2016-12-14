using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine;

namespace Engine.JobScheduler
{
    
    
    /// <summary>
    /// Class responsible for
    /// (1) Creation and retrieval of the instance of the 'Pre-defined' job 
    ///     based on the Job parameters(JOB ID).
    /// (2) Storage and retrieval for the instances of the job (jobs which are already in the memory).
    /// </summary>
    /// -Krishan
    class JobsRepository
    {

        /// <summary>
        /// List of job instances.
        /// </summary>
        public List<AcyclicJobModel> jobs = new List<AcyclicJobModel>();        // pubilc or private ?

        
        /// <summary>
        /// Adds or registers a new job.
        /// </summary>
        /// <param name="job"></param>
        public void Add(AcyclicJobModel job)
        {
            this.jobs.Add(job);
        }


        /// <summary>
        /// Returns the instance of the job based on the Job parameters(JOB ID).
        /// </summary>
        /// <param name="jobParameters"></param>
        /// <returns>Job object</returns>
        /// 
        public AcyclicJobModel GetInstance(JobParameters jobParameters)
        {

            if (jobParameters.JobType == JobTypeCatalogueEnum.FixedJob1)
            {
                // In case of Fixed type job : instantiating the fixed job instance.

                return new AllJobs.FixedJob1( jobParameters.Id, jobParameters.Title, 
                    jobParameters.StartTime);

            }
            else if (jobParameters.JobType == JobTypeCatalogueEnum.Specimen)   /***Specimen**/
            {
                // In case of Specimen type job : getting the job from the list.

                return GetJobById(jobParameters.Id);
                
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// Returns the job from the list, with the gievn id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private AcyclicJobModel GetJobById(int id)                  // private method.
        {
            // Linear search.
            foreach (var job in jobs)
            {
                if (job.Id == id)
                {
                    return job;
                }
            }
            // Failure case : when job with given id not found.     // raise exception
            return null;
        }




    }
}



 
 //else if (jobParameters.JobType == JobTypeCatalogueEnum.FixedJob2)   /***TimeEater**/
            //{
            //    return new AllJobs.TimeEater(jobParameters.Id, jobParameters.Title,
            //        jobParameters.StartTime);
            //}
            //else if (jobParameters.JobType == JobTypeCatalogueEnum.FixedJob3)
            //{
            //    return new AllJobs.FixedJob3(jobParameters.Id, jobParameters.Title,
            //        jobParameters.StartTime);
            //}
            //else if (jobParameters.JobType == JobTypeCatalogueEnum.PrintJob)
            //{
            //    return new AllJobs.PrintJob(jobParameters.Id, jobParameters.Title,
            //        jobParameters.StartTime);
            //}
            //else if (jobParameters.JobType == JobTypeCatalogueEnum.DynamicJobCreater)
            //{
            //    return new AllJobs.DynamicJobCreater(jobParameters.Id, jobParameters.Title,
            //        jobParameters.StartTime);
            //}
 

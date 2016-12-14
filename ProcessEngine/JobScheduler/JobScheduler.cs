using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Threading;
using Engine;

namespace Engine.JobScheduler
{
    /// <summary>
    /// Prime class to schedule the jobs.
    /// (Singleton)
    /// </summary>
    /// -krishan
    class Scheduler      // Singleton class.
    {               
        
        /// <summary>
        /// Static instance of this class.
        /// </summary>
        private static Scheduler instance;

        /// <summary>
        /// JobRunner
        /// </summary>
        private JobRunner jobRunner;
        
        /// <summary>
        /// List of tasks.
        /// </summary>
        private List<Task> taskList; 
        
        /// <summary>
        /// Collection for holding Job Parameters (Job Id).
        /// </summary>
        public JobParametersTable jobParametersTable;


        // private constructor
        private Scheduler()
        {
            taskList = new List<Task>();
            jobParametersTable = new JobParametersTable();
            jobRunner = new JobRunner();
        }



        /// <summary>
        /// Static method to create instance of this class.
        /// </summary>
        /// <returns>The reference for the Job Scheduler instance</returns>
        public static Scheduler Create()
        {
            if (instance == null)
            {
                instance= new Scheduler();
                return instance;
            }
            else
            {
                return instance;
            }
        }



        /// <summary>
        /// Adds a job to the scheduler and schedules it (instantly).
        /// </summary>
        /// <param name="jobParameters">jobParameter object (Job ID)</param>
        /// <returns></returns>
        public bool AddJob(JobParameters jobParameters)
        {
            // Adding the job parameters to the table jobParametersTable.
            jobParametersTable.jobParams.Add(jobParameters);
            
            // Scheduling the job.
            ScheduleJob(jobParameters);

            // Logs
            Console.WriteLine("\nNew Job scheduled successfully..");
            Console.WriteLine("\t Job id = {0}, Tilte = {1}", jobParameters.Id, jobParameters.Title);

            return true;
        }


        
        /// <summary>
        /// Schedules a job by setting an asynchronoues time delay.
        /// </summary>
        /// <param name="jobParameters"></param>
        public void ScheduleJob(JobParameters jobParameters)
        {
            
            // Setting a async. delay timer for all the jobs referenced in the job parameters table.
            // Creates a new task that runs on separate background thread.
            Task task = Task.Run(async delegate
                {
                    // Async time delay.
                    await Task.Delay(Util.TimeSpanFromNow(jobParameters.StartTime));
                    
                    // Awaited operation, runnning job after completion of the time delay.
                    jobRunner.Run(jobParameters);

                    return;
                }
             );
            this.taskList.Add(task);
        }




        /// <summary>
        /// Prime method to start the scheduling process.
        /// Schedules all the jobs referenced by the job parameters
        /// already present in the parameters table
        /// </summary>
        public void Start()
        {
            Console.WriteLine("Scheduling all jobs");

            // Scheduling all the jobs referenced by the job parameters table
            foreach (var jobParameter in jobParametersTable.jobParams)
            {
                ScheduleJob(jobParameter);
            }

        }


     


        /// <summary>
        /// Method to hold the main thread untill all tasks thread completes.
        /// </summary>
        public void WaitTillAllTasksComplete()
        {
            
            Task.WaitAll(this.taskList.ToArray());

        }

    }
}



/*

        /// <summary>
        /// Method to schedule a New job 
        /// i.e. job registered on runtime (after the scheduler has started).
        /// </summary>
        /// <param name="jobParameters"></param>
        /// <returns></returns>
        public bool ScheduleNewJob(JobParameters jobParameters)
        {
            // Adding the job parameters to the table jobParametersTable.
            jobParametersTable.jobParams.Add(jobParameters);
            // Scheduling the job.
            ScheduleJob(jobParameters);
            
            //
            Console.WriteLine("\nNew Job scheduled successfully..");
            Console.WriteLine("\t job id = {0} job Tilte = {1}", jobParameters.Id, jobParameters.Title);
            
            return true;
        }
*/
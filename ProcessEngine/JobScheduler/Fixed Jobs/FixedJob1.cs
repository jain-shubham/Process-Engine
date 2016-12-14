using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Engine;

namespace Engine.JobScheduler.AllJobs
{
    class FixedJob1:AcyclicJobModel
    {
        public FixedJob1(int id, string title, DateTime startTime)
            : base(id, title, startTime)
        {
             
        }

        public override void ExecuteAsync()
        {
            base.ExecuteAsync();
            
            // A simple async delay to consume time.
            Task task = Task.Run(async delegate
            {
                await Task.Delay(10000);    // 10 secc
                Console.WriteLine("Job Completed with Id = {0}", this.Id);
                return;

            });
        }
    }
}

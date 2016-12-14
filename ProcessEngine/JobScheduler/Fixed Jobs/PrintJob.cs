using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Engine;


namespace Engine.JobScheduler.AllJobs
{
    class PrintJob : AcyclicJobModel
    {
        public PrintJob(int id, string title, DateTime startTime)
            : base(id, title, startTime)
        {

        }

        public override void ExecuteAsync()
        {
            base.ExecuteAsync();
            Console.WriteLine(" -> Print Job ");
            Console.WriteLine("Job Completed with Id = {0}", this.Id);
        }

        // overriding and overloading
        public  void ExecuteAsync(string message)
        {
            base.ExecuteAsync();
            Console.WriteLine(" Print Job -> " + message);
        }
    }
}

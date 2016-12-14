using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Engine;

namespace Engine.JobScheduler.AllJobs
{
    class FixedJob3 : AcyclicJobModel
    {
        public FixedJob3(int id, string title, DateTime startTime)
            : base(id, title, startTime)
        {
             
        }
        
        public override void ExecuteAsync()
        {
            base.ExecuteAsync();
            //Console.WriteLine(" -> Fixed-Job-3.");
        }
    }
}

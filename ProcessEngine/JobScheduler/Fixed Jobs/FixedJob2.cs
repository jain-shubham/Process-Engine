using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Engine;

namespace Engine.JobScheduler.AllJobs
{
    class TimeEater : AcyclicJobModel
    {
        public TimeEater(int id, string title, DateTime startTime)
            : base(id, title, startTime)
        {
             
        }

        public override void ExecuteAsync()
        {
            base.ExecuteAsync();
            // A simple SYNCHRONOUS delay to consume time
            //Task task = Task.Run(async delegate
            //{
            //    await Task.Delay(10000);    // 10 secc
            //    Console.WriteLine("Time Eater Job Completed with Id = {0}", this.Id);
            //    //

            //    return;

            //});
            while (true) 
            { 
                Console.ReadKey(); 
            }
            
        }
    }
}

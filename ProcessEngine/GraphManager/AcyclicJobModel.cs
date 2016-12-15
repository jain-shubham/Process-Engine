using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    class AcyclicJobModel
    {

        Object scope;
        
        
        Dictionary<int, List<GraphStepNode>> dictAcyclicJob = null;

        // kk by Jitendra131

        /// <summary>
        /// Job Id
        /// </summary>
          public int Id { get; set; }

        /// <summary>
        /// Job Title
        /// </summary>
        public string Title { get; set; }


        /// <summary>
        /// Start time of job. 
        /// </summary>
        public DateTime StartTime { get; set; }     // validations required


        /// <summary>
        /// Time taken by the job to complete. 
        /// </summary>
        public DateTime ExecutionTime { get; set; }     // validations required


        public AcyclicJobModel()
        {}


        public AcyclicJobModel(int id, string title, DateTime startTime)
        {
            this.Id = id;
            this.Title = title;
            this.StartTime = startTime;

            //Console.WriteLine("\nJob Object instantiated with "
            //+"\n\t id = {0} \n\t Title = {1} \n\t StartTime = {2}", Id, Title,StartTime);

        }


        /// <summary>
        /// Operation to be performed by the job. 
        /// </summary>
        public virtual void ExecuteAsync()             // Asynchrony ??
        {
            Console.WriteLine("Job executed with id = " + Id + "\n");
            Console.WriteLine();
        }
    }
}

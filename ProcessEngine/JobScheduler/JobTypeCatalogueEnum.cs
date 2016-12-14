using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.JobScheduler
{


    /**
     * 'Fixed Job' are one which are pre-defined in form of class, whose instance can be created
     * at the time when it is needed to be executed. 
     * 'Specimen' type is for job for which we have the instance of the job already 
     * present in the memeory. 
     * -krishan
     */

    /// <summary>
    /// Enum to store the name for the JobType (will be used by the JobRepository)
    /// </summary>
    public enum JobTypeCatalogueEnum 
    { 
        // Fixed Jobs.
        FixedJob1, 
        FixedJob2, 
        FixedJob3, 
        PrintJob, 
        DynamicJobCreater,

        // 
        Specimen
 
    };
}



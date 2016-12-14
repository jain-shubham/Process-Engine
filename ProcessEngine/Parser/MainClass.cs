using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Parser
{
    class MainClass
    {
        // Main method.
        public static void Main()
        {
            //BasicExample.execute();
            JobModel objJob = YAML_Parse_2.execute();
            //-ProcessModel model = new ProcessModel();
            //model.RunModel();

            GraphManager objGraphManager = new GraphManager();
            objGraphManager.GetAcyclicJobModel(objJob);
            //YAML_Step_to_Object.execute();
            Console.ReadLine();
        }

    }
}

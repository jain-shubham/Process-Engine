using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Parser
{
    class WorkSpaceTableVersion
    {
        public WorkSpaceTable permTable;
        public string versionID;

        public void initialize(WorkSpaceTable table, string stepID)
        {
            this.permTable = table;
            this.versionID = stepID;
        }

    }
}

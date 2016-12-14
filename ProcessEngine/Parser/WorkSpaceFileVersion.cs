using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Parser
{
    class WorkSpaceFileVersion
    {
        private List<IWorkSpaceFile> files;
        private string versionID;

        public WorkSpaceFileVersion(List<IWorkSpaceFile> files, string stepID)
        {
            this.files = files;
            this.versionID = stepID;
        }
    }
}

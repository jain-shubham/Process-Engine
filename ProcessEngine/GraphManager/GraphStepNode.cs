using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Engine.Parser;

namespace Engine
{
    class GraphStepNode
    {
        public string nodeID;
        public IStep objStep;
        public List<string> parents;
        public List<string> children;
        public bool isProcessed;
        public int currentLevel = -1;

        public GraphStepNode(IStep objStep)
        {
            this.objStep = objStep;
            this.nodeID = objStep.ID;
            parents = new List<string>();
            children = new List<string>();
            isProcessed = false;
        }

    }
}

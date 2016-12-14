using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Engine.Parser;

namespace Engine
{
    class ComponentRunner
    {
        Dictionary<int, NodeList> lvlNodesMap = new Dictionary<int, NodeList>();
        public void UpdateStatus()
        { }

        public void ProcessGraph(Dictionary<int, NodeList> lvlNodesMap)
        {
            NodeList rootNodes = lvlNodesMap[1];
            foreach (IStep n in rootNodes)
            {
                n.ExecuteNode();
            }
        }

        public static void ExecutionCompleted(IStep node)
        {
            NodeList children = node.Children;
            foreach(IStep step in children)
            {
                IStep notProcessed = step.Parents.Where(m => m.isProcessed == false).FirstOrDefault<IStep>();
                if(notProcessed == null)
                {
                    step.ExecuteNode();
                }
            }
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Engine.Parser;

namespace Engine
{
    class GraphManager
    {
        //stores all the nodes present in Job graph till now --
        
        List<GraphStepNode> lstGraphNodes = new List<GraphStepNode>();
        List<GraphStepNode> lstRootNodes = new List<GraphStepNode>();
        Dictionary<int, List<GraphStepNode>> lvlNodesMap = new Dictionary<int, List<GraphStepNode>>();

        #region Factory Methods

        ///<summary>
        ///Method to create a Acyclic job Model which contains a scope object and a dictionary
        ///to store graph node list according to their level in Graph.
        /// </summary>
        public AcyclicJobModel GetAcyclicJobModel(JobModel jobModel)
        {
            GraphStepNode graphStepNode = null;
            foreach (IStep step in jobModel.Steps)
            {
                graphStepNode = CreateGraphStepNode(step);
                if (graphStepNode != null)
                    lstGraphNodes.Add(graphStepNode);
            }

            lstRootNodes = GetRootNodes(lstGraphNodes);
            CreateGraphEdges();

            TopologicalSort(lstRootNodes);
            
            return new AcyclicJobModel();
        }

        ///<summary>
        ///This Method create a Graph node from the step pass to it.
        ///</summary>
        public GraphStepNode CreateGraphStepNode(IStep step)
        {
            return new GraphStepNode(step);
        }

        ///<summary>
        ///Method to get root nodes of the graph.
        ///</summary>
        public List<GraphStepNode> GetRootNodes(List<GraphStepNode> lstGraphNodes)
        {
            foreach(GraphStepNode objStepNode in lstGraphNodes)
            {
                if (objStepNode.objStep.InputData == null || objStepNode.objStep.InputData.Count == 0)
                    lstRootNodes.Add(objStepNode);
            }
            return lstRootNodes;
        }

        public void CreateGraphEdges()
        {
            foreach(GraphStepNode node in lstGraphNodes)
            {
                if(node.objStep.InputData!=null && node.objStep.InputData.Count>0)
                {
                    foreach(object obj in node.objStep.InputData)
                    {
                        if (obj is WorkSpaceTableVersion)
                        {
                            WorkSpaceTableVersion tabl = obj as WorkSpaceTableVersion;
                            node.parents.Add(tabl.versionID);
                            GraphStepNode parentNode = lstGraphNodes.Where(m => m.nodeID == tabl.versionID).FirstOrDefault();
                            if (parentNode != null)
                                parentNode.children.Add(node.nodeID);
                        }
                         //-------------
                        //code to be written for other type of input.
                    }
                }
            }
        }
        
        ///<summary>
        ///Method for topological sort to get the the dictionary object which contains level of each node.
        ///</summary>
        public Dictionary<int, List<GraphStepNode>> TopologicalSort(List<GraphStepNode> lstRootNodes)
        {
            
            Dictionary<string, bool> visited = new Dictionary<string, bool>();
            Dictionary<string, int> arrLevel = new Dictionary<string, int>();

            Stack stack = new Stack();
            Stack stackLevel = new Stack();
            int level = 0;

            foreach(GraphStepNode stepNode in lstGraphNodes)
            {
                visited[stepNode.nodeID] = false;
                arrLevel[stepNode.nodeID] = -1;
            }

            foreach (GraphStepNode node in lstRootNodes)
            {
                topologicalSortUtil(node.nodeID, visited, stack, stackLevel, level, arrLevel);
            }
            //
            Console.WriteLine("Printing the Level Dictionary:");
            foreach (KeyValuePair<int, List<GraphStepNode>> o in lvlNodesMap.OrderBy(m => m.Key))
            {
                Console.Write(o.Key + ": ");
                foreach (GraphStepNode n in o.Value)
                    Console.Write("  " + n.nodeID + "  ");
                Console.WriteLine();
            }

            return lvlNodesMap;
        }

        ///<summary>
        ///Method runs topological sort for each root node.
        ///</summary>
        public int topologicalSortUtil(string v, Dictionary<string, bool> visited,
                            Stack stack, Stack stackLevel, int level, Dictionary<string, int> arrLevel)
        {
            // Mark the current node as visited.

            int i;
            List<GraphStepNode> lstNodes = new List<GraphStepNode>();
            bool isExists = false;
           
            level += 1;
            int leveli = 0;
            bool isParentProcessed = true;
            foreach (var it in GetChildren(v))
            {
                List<string> lstParents = GetParents(it);
                
                foreach(string nodeID in lstParents)
                {
                    GraphStepNode objNode = GetNodeFromID(nodeID);
                    if (objNode.isProcessed == false)
                        isParentProcessed = false;
                }
                //IStep tempNode = GetParents(it).Where(m => m.isProcessed == false).ToList().FirstOrDefault();

                if (isParentProcessed)
                {
                    visited[v] = true;
                    leveli = topologicalSortUtil(it, visited, stack, stackLevel, level, arrLevel);
                    //it.IsProcessed = true;
                }
                else
                    leveli = topologicalSortUtil(it, visited, stack, stackLevel, level, arrLevel);
            }
            //level += 1;
            if (arrLevel[v] < level)
            {
                arrLevel[v] = level;
                GraphStepNode nd = lstGraphNodes.Where(m => m.nodeID == v).FirstOrDefault<GraphStepNode>();
                if (nd.currentLevel > -1)
                {
                    isExists = lvlNodesMap.TryGetValue(nd.currentLevel, out lstNodes);
                    if (lstNodes != null && lstNodes.Contains(nd))
                        lstNodes.Remove(nd);

                    lvlNodesMap.Remove(nd.currentLevel);
                    lvlNodesMap.Add(nd.currentLevel, lstNodes);
                }

                nd.currentLevel = level;

                if (lvlNodesMap.ContainsKey(level))
                {
                    lstNodes = new List<GraphStepNode>();
                    isExists = lvlNodesMap.TryGetValue(level, out lstNodes);
                    if (lstNodes != null && !lstNodes.Contains(nd))
                        lstNodes.Add(nd);

                    lvlNodesMap.Remove(level);
                    lvlNodesMap.Add(level, lstNodes);
                }
                else
                {
                    lstNodes = new List<GraphStepNode>();
                    lstNodes.Add(nd);
                    lvlNodesMap.Add(level, lstNodes);
                }
                
            }
            // Push current vertex to stack which stores result
            stack.Push(v);
            return level;
        }


        public List<string> GetChildren(string nodeID)
        {
            GraphStepNode ndV = null;

            ndV = lstGraphNodes.Where(m => m.nodeID == nodeID).FirstOrDefault<GraphStepNode>();
            if (ndV.children != null)
                return ndV.children;
            else
                return new List<string>();
        }

        public List<string> GetParents(string nodeID)
        {
            GraphStepNode ndV = null;

            ndV = lstGraphNodes.Where(m => m.nodeID == nodeID).FirstOrDefault<GraphStepNode>();
            if (ndV.parents != null)
                return ndV.parents;
            else
                return new List<string>();
        }

        public GraphStepNode GetNodeFromID(string nodeID)
        {
            GraphStepNode node = lstGraphNodes.Where(m => m.nodeID == nodeID).FirstOrDefault<GraphStepNode>();
            return node;
        }

        #endregion
    }
}

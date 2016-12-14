using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Engine.Parser;

namespace Engine
{
    class ProcessModel
    {
        public NodeList lstSteps = new NodeList();
        Dictionary<int, NodeList> lvlNodesMap = new Dictionary<int, NodeList>();

        public void RunModel()
        {
            LoadSteps();
            initializeProcess();
            topologicalSort();
            ComponentRunner c = new ComponentRunner();
            c.ProcessGraph(lvlNodesMap);
        }

        public void LoadSteps()
        {
            IStep stp = null;
            for(int i=0;i<10;i++)
            {
                stp = new FileToTable();
                stp.Name = "Step_" + i;
                stp.ID = i.ToString();
                stp.Type = "FileToTable";
                stp.nodeData = i;
                stp.isProcessed = false;
                stp.currentLevel = -1;
                stp.Children = new NodeList();
                stp.Parents = new NodeList();

                lstSteps.Add(stp);
            }
        }

        public void initializeProcess()
        {
            addEdgeByReference(lstSteps[5], lstSteps[2]);
            addEdgeByReference(lstSteps[5], lstSteps[4]);
            addEdgeByReference(lstSteps[2], lstSteps[0]);
            addEdgeByReference(lstSteps[4], lstSteps[0]);
            addEdgeByReference(lstSteps[4], lstSteps[1]);
            addEdgeByReference(lstSteps[2], lstSteps[3]);
            addEdgeByReference(lstSteps[3], lstSteps[1]);

            addEdgeByReference(lstSteps[5], lstSteps[7]);
            addEdgeByReference(lstSteps[0], lstSteps[6]);
            addEdgeByReference(lstSteps[5], lstSteps[9]);
            addEdgeByReference(lstSteps[6], lstSteps[8]);
            addEdgeByReference(lstSteps[8], lstSteps[9]);
        }

        public void addEdgeByReference(IStep v, IStep w)
        {
            v.Children.Add(w);
            w.Parents.Add(v);
        }

        public Dictionary<int, NodeList> topologicalSort()
        {
            //Dictionary<int, NodeList> dictLvlNodesMap = new Dictionary<int, NodeList>();
            Stack stack = new Stack();
            Stack stackLevel = new Stack();
            int level = 0;
            //  Mark all the vertices as not visited
            bool[] visited = new bool[10];
            int[] arrLevel = new int[10];
            for (int i = 0; (i < 10); i++)
            {
                visited[i] = false;
                arrLevel[i] = -1;
            }          
            {
                IStep nd = lstSteps.Where(m => m.nodeData == 5).FirstOrDefault<IStep>();
                //nd.IsProcessed = true;
                topologicalSortUtil(5, visited, stack, stackLevel, level, arrLevel);

                level = 0;
            }
            
            //  Print contents of stack
            object j = stack.Pop();
            object k = null;

            if (stackLevel.Count > 0)
                k = stackLevel.Pop();

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Final order of traversal:");
            while (j != null)
            {
                System.Console.WriteLine((j.ToString() + " : " + arrLevel[(int)j]));
                if (stack.Count > 0)
                    j = stack.Pop();
                else
                    j = null;
                if (stackLevel.Count > 0)
                    k = stackLevel.Pop();
                else
                    k = null;
            }

            Console.WriteLine("Printing the Level Dictionary:");
            foreach (KeyValuePair<int, NodeList> o in lvlNodesMap.OrderBy(m=>m.Key))
            {
                Console.Write(o.Key + ": ");
                foreach (IStep n in o.Value)
                    Console.Write("  " + n.nodeData + "  ");
                Console.WriteLine();
            }

            return lvlNodesMap;
        }

        //  A recursive function used by topologicalSort
        public int topologicalSortUtil(int v, bool[] visited,
                            Stack stack, Stack stackLevel, int level, int[] arrLevel)
        {
            // Mark the current node as visited.

            int i;
            NodeList lstNodes = new NodeList();
            bool isExists = false;
            //arrLevel[v] = level;
            // Recur for all the vertices adjacent to this
            // vertex
            level += 1;
            int leveli = 0;
            bool isParentProcessed = true;
            foreach (var it in GetNeighbours(v))
            {
                //  if (!visited[it.Value] && arrLevel[it.Value] < level)
                //foreach (Node n in it.Parents)
                //    if (!n.IsProcessed)
                //        isParentProcessed = false;

                IStep tempNode = GetParents(it.nodeData.Value).Where(m => m.isProcessed == false).ToList().FirstOrDefault();

                if (tempNode == null)
                {
                    visited[v] = true;
                    leveli = topologicalSortUtil(Convert.ToInt32(it.nodeData), visited, stack, stackLevel, level, arrLevel);
                    //it.IsProcessed = true;
                }
                else
                    leveli = topologicalSortUtil(Convert.ToInt32(it.nodeData), visited, stack, stackLevel, level, arrLevel);
            }
            //level += 1;
            if (arrLevel[v] < level)
            {
                arrLevel[v] = level;
                IStep nd = lstSteps.Where(m => m.nodeData == v).FirstOrDefault<IStep>();
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
                    lstNodes = new NodeList();
                    isExists = lvlNodesMap.TryGetValue(level, out lstNodes);
                    if (lstNodes != null && !lstNodes.Contains(nd))
                        lstNodes.Add(nd);

                    lvlNodesMap.Remove(level);
                    lvlNodesMap.Add(level, lstNodes);
                }
                else
                {
                    lstNodes = new NodeList();
                    lstNodes.Add(nd);
                    lvlNodesMap.Add(level, lstNodes);
                }

                // stackLevel.Push(level);
            }

            // Push current vertex to stack which stores result
            stack.Push(v);
            return level;
        }

        public NodeList GetNeighbours(int nodeValue)
        {
            IStep ndV = null;

            ndV = lstSteps.Where(m => m.nodeData == nodeValue).FirstOrDefault<IStep>();
            if (ndV.Children != null)
                return ndV.Children;
            else
                return new NodeList();
        }

        public NodeList GetParents(int nodeValue)
        {
            IStep ndV = null;

            ndV = lstSteps.Where(m => m.nodeData == nodeValue).FirstOrDefault<IStep>();
            if (ndV.Parents != null)
                return ndV.Parents;
            else
                return new NodeList();
        }

        //----------------------
    }
}

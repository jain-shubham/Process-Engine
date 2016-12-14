using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Parser
{
    interface IStep
    {
        string ID { get; set; }
        string Name { get; set; }
        string Type { get; set; }
        List<Object> Attributes { get; set; }
        List<Object> InputData { get; set; }
        List<Object> OutputData { get; set; }
        void setInputData(WorkSpaceTableVersion table);

        //Added By shubham
        int? nodeData { get; set; }
        bool isProcessed { get; set; }
        int currentLevel { get; set; }
        NodeList Children { get; set; }
        NodeList Parents { get; set; }

        void ExecuteNode();
    }

    class FileToTable : IStep
    {
        int num = 100;
        public string ID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public List<Object> Attributes { get; set; }
        public List<Object> InputData { get; set; }
        public List<Object> OutputData { get; set; }
        //public void setInputData(WorkSpaceTable table);

        //Added By shubham
        public int? nodeData { get; set; }
        public bool isProcessed { get; set; }
        public int currentLevel { get; set; }
        public NodeList Children { get; set; }
        public NodeList Parents { get; set; }

        #region Factory Methods

        public async void ExecuteNode()
        {
            Console.WriteLine("Execution Started : "+this.nodeData);
            int randm = GetRandomNumber();
            Console.WriteLine(this.nodeData + ":" + randm + " --> ");
            await Task.Delay(randm);


            this.isProcessed = true;
            
            Console.WriteLine("Execution Completed : " + this.nodeData);
            Console.WriteLine();
            ComponentRunner.ExecutionCompleted(this);
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public int GetRandomNumber()
        {
            Random rnd = new Random();
            int randm = rnd.Next(2000, 10000) + num;
            num += 300;
            return randm;
        }

		public void setInputData(WorkSpaceTableVersion table)
        {
            this.InputData = new List<object>();
            InputData.Add(table);
        }

        #endregion
    }

	class TableToFile : IStep
    {
        int num = 100;
        public string ID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public List<Object> Attributes { get; set; }
        public List<Object> InputData { get; set; }
        public List<Object> OutputData { get; set; }
        //public void setInputData(IWorkSpaceFile file)
        //{
        //this.InputData = file;
        //}

        //Added By shubham
        public int? nodeData { get; set; }
        public bool isProcessed { get; set; }
        public int currentLevel { get; set; }
        public NodeList Children { get; set; }
        public NodeList Parents { get; set; }

        #region Factory Methods

        public async void ExecuteNode()
        {
            Console.WriteLine("Execution Started : " + this.nodeData);
            int randm = GetRandomNumber();
            Console.WriteLine(this.nodeData + ":" + randm + " --> ");
            await Task.Delay(randm);


            this.isProcessed = true;

            Console.WriteLine("Execution Completed : " + this.nodeData);
            Console.WriteLine();
            ComponentRunner.ExecutionCompleted(this);
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public int GetRandomNumber()
        {
            Random rnd = new Random();
            int randm = rnd.Next(2000, 10000) + num;
            num += 300;
            return randm;
        }

        public void setInputData(WorkSpaceTableVersion table)
        {
            this.InputData = new List<object>();
            InputData.Add(table);
        }

        #endregion

    }
}

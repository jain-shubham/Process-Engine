using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Parser
{
    interface IWorkSpaceFile
    {
        string Name { get; set; }
        string FileType { get; set; }
        string RowDelimeter { get; set; }
        string ColumnDelimeter { get; set; }
        string Path { get; set; }
    }

    class CSV : IWorkSpaceFile
    {
        public string Name { get; set; }
        public string FileType { get; set; }
        public string RowDelimeter { get; set; }
        public string ColumnDelimeter { get; set; }
        public string Path { get; set; }
    }

    class Excel : IWorkSpaceFile
    {
        public string Name { get; set; }
        public string FileType { get; set; }
        public string RowDelimeter { get; set; }
        public string ColumnDelimeter { get; set; }
        public string Path { get; set; }
    }
}

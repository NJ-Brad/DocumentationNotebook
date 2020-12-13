using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentationNotebook
{
    public class NotebookIndexNode
    {
        public string ID { get; set; } = Guid.NewGuid().ToString();
        public NotebookIndexNodeType NodeType { get; set; } = NotebookIndexNodeType.Unknown;
        public string Url { get; set; } // can be relative or absolute
        public List<NotebookIndexNode> Nodes { get; set; } = new List<NotebookIndexNode>();
        public bool ReadOnly { get; set; }
        public string ShortName { get; set; }
        public string LongName { get; set; }
        public string Description { get; set; }
        public List<string> SeeAlso { get; set; }
    }
}

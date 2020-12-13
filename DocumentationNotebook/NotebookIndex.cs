using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DocumentationNotebook
{

    public class NotebookIndex
    {
        public List<NotebookIndexNode> Nodes { get; set; } = new List<NotebookIndexNode>();

        public void GenerateTestData()
        {
            NotebookIndexNode node = Nodes.AddNode(new NotebookIndexNode { ShortName = "Group 1", LongName = "Group Long 1", Description="This is a group of nodes", NodeType = NotebookIndexNodeType.Branch });
            node.Nodes.AddNode(new NotebookIndexNode { ShortName = "Short 1", LongName = "Long 1", NodeType = NotebookIndexNodeType.Markdown, Url = "http://www.cnn.com" });
            node.Nodes.AddNode(new NotebookIndexNode { ShortName = "Short 2", LongName = "Long 2", NodeType = NotebookIndexNodeType.Markdown, ReadOnly = true, Url = "http://www.google.com" }); ;
            node.Nodes.AddNode(new NotebookIndexNode { ShortName = "Short 3", LongName = "Long 3", NodeType = NotebookIndexNodeType.Link, Url = "http://www.google.com" }); ;
        }

        // https://docs.microsoft.com/en-us/dotnet/standard/serialization/system-text-json-how-to?pivots=dotnet-5-0

        public string GetFormattedString()
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
            };
            string jsonString = JsonSerializer.Serialize(Nodes, options);

            return jsonString;
        }

        public void ShowOnTree(TreeView tv)
        {
            foreach (NotebookIndexNode child in Nodes)
            {
                AddNodeToTree(tv.Nodes, child);
            }
        }

        private void AddNodeToTree(TreeNodeCollection collection, NotebookIndexNode node)
        {
            TreeNode newNode = new TreeNode { Text = node.ShortName, ToolTipText = node.LongName, Tag = node };
            collection.Add(newNode);
            foreach (NotebookIndexNode child in node.Nodes)
            {
                AddNodeToTree(newNode.Nodes, child);
            }
        }

        // file is saved in a file with the extension .DNB - "Document Note Book"

    }

    internal static class NodeHelper
    {
        internal static NotebookIndexNode AddNode(this List<NotebookIndexNode> collection, NotebookIndexNode newNode)
        {
            collection.Add(newNode);
            return newNode;
        }
    }
}

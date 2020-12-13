using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DocumentationNotebook
{
    public partial class NotebookForm : Form
    {
        public NotebookForm()
        {
            InitializeComponent();
        }
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);


            treeView1.ContextMenuStrip = new ContextMenuStrip { ShowImageMargin = false };

            ToolStripMenuItem tsmi = new ToolStripMenuItem { Name = "contextMenuCut", Text = "Cut" };
            tsmi.Click += (s, e) => { Cut(); };
            treeView1.ContextMenuStrip.Items.Add(tsmi);

            tsmi = new ToolStripMenuItem { Name = "contextMenuCopy", Text = "Copy" };
            tsmi.Click += (s, e) => { Copy(); };
            treeView1.ContextMenuStrip.Items.Add(tsmi);

            tsmi = new ToolStripMenuItem { Name = "contextMenuPaste", Text = "Paste" };
            tsmi.Click += (s, e) => { Paste(); };
            treeView1.ContextMenuStrip.Items.Add(tsmi);

            ToolStripSeparator tss = new ToolStripSeparator();
            treeView1.ContextMenuStrip.Items.Add(tss);

            tsmi = new ToolStripMenuItem { Name = "contextMenuMoveUp", Text = "Move Up" };
            tsmi.Click += (s, e) => { MoveUp(); };
            treeView1.ContextMenuStrip.Items.Add(tsmi);

            tsmi = new ToolStripMenuItem { Name = "contextMenuMoveDown", Text = "Move Down" };
            tsmi.Click += (s, e) => { MoveDown(); };
            treeView1.ContextMenuStrip.Items.Add(tsmi);

            tss = new ToolStripSeparator();
            treeView1.ContextMenuStrip.Items.Add(tss);

            tsmi = new ToolStripMenuItem { Name = "contextMenuAdd", Text = "Add" };
            treeView1.ContextMenuStrip.Items.Add(tsmi);

            NotebookIndex ni = new NotebookIndex();
            ni.GenerateTestData();

            ni.ShowOnTree(treeView1);
        }

        private void EnableCCP(TreeNode node)
        {
            GetMenuItem("contextMenuAdd").Enabled = IsBranch(node);

            GetMenuItem("contextMenuCut").Enabled = true;
            GetMenuItem("contextMenuCopy").Enabled = true;

            //pasteToolStripButton.Enabled = ((clipboardNode != null) && ((clipboardNode.Tag as Item).Command == "Rel"));


            //            // Document
            //            if (IsNodeInCorrectSection(treeView1.SelectedNode, treeView1.Nodes[0]))
            //            {
            ////                AddDropDownButton.Enabled = false;
            //                //cutToolStripButton.Enabled = false;
            //                //copyToolStripButton.Enabled = false;
            //                //pasteToolStripButton.Enabled = false;

            //                GetMenuItem("contextMenuAdd").Enabled = false;

            //                GetMenuItem("contextMenuCut").Enabled = false;
            //                GetMenuItem("contextMenuCopy").Enabled = false;
            //                GetMenuItem("contextMenuPaste").Enabled = false;
            //            }
            //            else if (IsNodeInCorrectSection(treeView1.SelectedNode, treeView1.Nodes[1]))
            //            {
            //                //AddDropDownButton.Enabled = true;
            //                GetMenuItem("contextMenuAdd").Enabled = true;

            //                if (treeView1.SelectedNode == treeView1.Nodes[1])
            //                {
            //                    //cutToolStripButton.Enabled = false;
            //                    //copyToolStripButton.Enabled = false;
            //                    GetMenuItem("contextMenuCut").Enabled = false;
            //                    GetMenuItem("contextMenuCopy").Enabled = false;
            //                }
            //                else
            //                {
            //                    //cutToolStripButton.Enabled = true;
            //                    //copyToolStripButton.Enabled = true;
            //                    GetMenuItem("contextMenuCut").Enabled = true;
            //                    GetMenuItem("contextMenuCopy").Enabled = true;
            //                }
            //                //pasteToolStripButton.Enabled = ((clipboardNode != null) && ((clipboardNode.Tag as Item).Command != "Rel"));
            //                //GetMenuItem("contextMenuPaste").Enabled = ((clipboardNode != null) && ((clipboardNode.Tag as NotebookIndexNode).Command != "Rel"));
            //            }
            //            else if (IsNodeInCorrectSection(treeView1.SelectedNode, treeView1.Nodes[2]))
            //            {
            //                if (treeView1.SelectedNode == treeView1.Nodes[2])
            //                {
            //                    //AddDropDownButton.Enabled = true;       // no heirarchy - must be on the Relationships node
            //                    GetMenuItem("contextMenuAdd").Enabled = true;

            //                    //cutToolStripButton.Enabled = false;
            //                    //copyToolStripButton.Enabled = false;
            //                    GetMenuItem("contextMenuCut").Enabled = true;
            //                    GetMenuItem("contextMenuCopy").Enabled = true;
            //                }
            //                else
            //                {
            //                    //AddDropDownButton.Enabled = false;      // no heirarchy - must be on the Relationships node
            //                    GetMenuItem("contextMenuAdd").Enabled = false;

            //                    //cutToolStripButton.Enabled = true;
            //                    //copyToolStripButton.Enabled = true;
            //                    GetMenuItem("contextMenuCut").Enabled = true;
            //                    GetMenuItem("contextMenuCopy").Enabled = true;
            //                }
            //pasteToolStripButton.Enabled = ((clipboardNode != null) && ((clipboardNode.Tag as Item).Command == "Rel"));
            //            }
        }

        private ToolStripMenuItem GetMenuItem(string name)
        {
            ToolStripMenuItem rtnVal = null;

            foreach (ToolStripItem tsmi in treeView1.ContextMenuStrip.Items)
            {
                if (tsmi.Name == name)
                {
                    rtnVal = (ToolStripMenuItem)tsmi;
                    break;
                }
            }

            return rtnVal;
        }


        private bool IsNodeInCorrectSection(TreeNode node, TreeNode sectionNode, bool parentAllowed = true)
        {
            bool rtnVal = false;

            if (node != null)
            {
                if (node == sectionNode)
                {
                    rtnVal = true;
                }
                else if (parentAllowed && (node.Parent != null))
                {
                    rtnVal = IsNodeInCorrectSection(node.Parent, sectionNode);
                }
            }

            return rtnVal;
        }


        private void EnableUD(TreeNode node)
        {
            // Document
            if (IsNodeInCorrectSection(node, treeView1.Nodes[0]))
            {
                //moveDownButton.Enabled = false;
                //moveUpButton.Enabled = false;
                GetMenuItem("contextMenuMoveUp").Enabled = false;
                GetMenuItem("contextMenuMoveDown").Enabled = false;
            }
            else if (IsNodeInCorrectSection(node, treeView1.Nodes[1]))
            {
                if (treeView1.SelectedNode == treeView1.Nodes[1])
                {
                    //moveDownButton.Enabled = false;
                    //moveUpButton.Enabled = false;
                    GetMenuItem("contextMenuMoveUp").Enabled = false;
                    GetMenuItem("contextMenuMoveDown").Enabled = false;
                }
                else
                {
                    //moveDownButton.Enabled = false;
                    //moveUpButton.Enabled = false;
                    GetMenuItem("contextMenuMoveUp").Enabled = false;
                    GetMenuItem("contextMenuMoveDown").Enabled = false;

                    TreeNode parentNode = treeView1.SelectedNode.Parent;
                    if (parentNode != null)
                    {
                        int numNodes = parentNode.Nodes.Count;

                        int nodeIndex = GetIndex(node);

                        // it has to be found
                        if (nodeIndex != -1)
                        {
                            if (nodeIndex > 0)
                            {
                                //moveUpButton.Enabled = true;
                                GetMenuItem("contextMenuMoveUp").Enabled = true;
                            }

                            if (nodeIndex < (numNodes - 1))
                            {
                                //moveDownButton.Enabled = true;
                                GetMenuItem("contextMenuMoveDown").Enabled = true;
                            }
                        }
                    }
                }
            }
            else if (IsNodeInCorrectSection(node, treeView1.Nodes[2]))
            {
                //moveDownButton.Enabled = false;
                //moveUpButton.Enabled = false;
                GetMenuItem("contextMenuMoveUp").Enabled = false;
                GetMenuItem("contextMenuMoveDown").Enabled = false;
            }
        }


        private void Cut()
        {
            Copy();
            TreeNode selectedNode = treeView1.SelectedNode;
            selectedNode.Parent.Nodes.Remove(selectedNode);
//            DocumentChanged();
        }

        TreeNode clipboardNode = null;

        private void Copy()
        {
            TreeNode selectedNode = treeView1.SelectedNode;
            clipboardNode = new TreeNode(selectedNode.Text);
            clipboardNode.Tag = selectedNode.Tag;

            IterateTreeNodes(selectedNode, clipboardNode);
        }

        private void Paste()
        {
            TreeNode selectedNode = treeView1.SelectedNode;

            TreeNode newNode = new TreeNode(clipboardNode.Text);
            newNode.Tag = CopyFromExisting(clipboardNode.Tag as NotebookIndexNode);
            treeView1.SelectedNode.Nodes.Add(newNode);

            treeView1.SelectedNode = newNode;

            IterateTreeNodes(clipboardNode, newNode, true);
            //DocumentChanged();
        }

        private NotebookIndexNode CopyFromExisting(NotebookIndexNode existing)
        {
            NotebookIndexNode rtnVal = new NotebookIndexNode();
            if (existing != null)
            {
                //rtnVal.Command = existing.Command;
                //rtnVal.IsDatabase = existing.IsDatabase;
                //rtnVal.IsExternal = existing.IsExternal;

                //rtnVal.Parameters.Add(GetNewName(existing.Command));
                //// need to fix this value later, to reduce confusion
                //rtnVal.Parameters.Add(existing.Parameters[1]);

                //if (existing.Parameters.Count > 2)
                //{
                //    rtnVal.Parameters.Add(existing.Parameters[2]);
                //}

                //if (existing.Parameters.Count > 3)
                //{
                //    rtnVal.Parameters.Add(existing.Parameters[3]);
                //}
            }

            return rtnVal;
        }
        private string GetNewName(string commandType)
        {
            BuildAliasMap(treeView1.Nodes[1]);

            int counter = 1;
            string counterString;
            string nameCandidate;

            do
            {
                counterString = counter.ToString().PadLeft(3, '0');
                nameCandidate = $"{commandType}_{counterString}";
                counter++;
            } while (itemAliases.ContainsKey(nameCandidate));

            return nameCandidate;
        }

        private void BuildAliasMap(TreeNode parentNode, bool firstNode = true)
        {
            if (firstNode)
            {
                itemAliases.Clear();
            }
            foreach (TreeNode node in parentNode.Nodes)
            {
                NotebookIndexNode item = node.Tag as NotebookIndexNode;
                if (item != null)
                {
                    //itemAliases.Add(item.Parameters[0], item.Parameters[1].Trim('\"'));
                    if (node.Nodes.Count > 0)
                    {
                        BuildAliasMap(node, false);
                    }
                }
            }
        }

        Dictionary<string, string> itemAliases = new Dictionary<string, string>();


        private void MoveUp()
        {
            int nodeIndex = GetIndex(treeView1.SelectedNode);

            // it has to be found
            if (nodeIndex != -1)
            {
                Cut();

                TreeNode newNode = new TreeNode(clipboardNode.Text);
                newNode.Tag = clipboardNode.Tag;
                treeView1.SelectedNode.Parent.Nodes.Insert((nodeIndex - 1), newNode);

                IterateTreeNodes(clipboardNode, newNode);

                treeView1.SelectedNode = newNode;
            }
            //DocumentChanged();
        }

        private void MoveDown()
        {
            int nodeIndex = GetIndex(treeView1.SelectedNode);

            // it has to be found
            if (nodeIndex != -1)
            {
                Cut();

                TreeNode newNode = new TreeNode(clipboardNode.Text);
                newNode.Tag = clipboardNode.Tag;
                treeView1.SelectedNode.Parent.Nodes.Insert((nodeIndex + 1), newNode);

                IterateTreeNodes(clipboardNode, newNode);

                treeView1.SelectedNode = newNode;
            }
            //DocumentChanged();
        }

        private int GetIndex(TreeNode node)
        {
            int nodeIndex = -1;

            TreeNode parentNode = node.Parent;

            if (parentNode != null)
            {

                int counter = 0;
                foreach (TreeNode collectionNode in parentNode.Nodes)
                {
                    if (collectionNode == node)
                    {
                        nodeIndex = counter;
                        break;
                    }
                    counter++;
                }
            }
            return nodeIndex;
        }

        private void IterateTreeNodes(TreeNode originalNode, TreeNode rootNode, bool createNewItem = false)
        {
            foreach (TreeNode childNode in originalNode.Nodes)
            {
                TreeNode newNode = new TreeNode(childNode.Text);
                if (createNewItem)
                {
                    newNode.Tag = CopyFromExisting(childNode.Tag as NotebookIndexNode);
                }
                else
                {
                    newNode.Tag = childNode.Tag;
                }

                rootNode.Nodes.Add(newNode);
                IterateTreeNodes(childNode, newNode, createNewItem);
            }
        }


        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            previousNode = e.Node;

            EnableCCP(e.Node);
            EnableUD(e.Node);

            //FillAddMenus(AddDropDownButton);
            FillAddMenus(GetMenuItem("contextMenuAdd"));

            NotebookIndexNode selectedNode = e.Node.Tag as NotebookIndexNode;
            if (selectedNode != null)
            {
                pageControl1.ShowNode(selectedNode);
            }
        }

        private bool IsBranch(TreeNode node)
        {
            return (node.Tag != null) &&
                ((node.Tag as NotebookIndexNode) != null) &&
                ((node.Tag as NotebookIndexNode).NodeType == NotebookIndexNodeType.Branch);
        }

        private void FillAddMenus(ToolStripDropDownItem item)
        {
            item.DropDownItems.Clear();

            if (IsBranch(previousNode))
            {
                item.DropDownItems.Add("Branch", null, (s, e) => { AddItem(NotebookIndexNodeType.Branch); });
                item.DropDownItems.Add("Link", null, (s, e) => { AddItem(NotebookIndexNodeType.Link); });
                item.DropDownItems.Add("Markdown", null, (s, e) => { AddItem(NotebookIndexNodeType.Markdown); });
                item.DropDownItems.Add("C4", null, (s, e) => { AddItem(NotebookIndexNodeType.C4); });
                item.DropDownItems.Add("UML", null, (s, e) => { AddItem(NotebookIndexNodeType.UML); });
                item.DropDownItems.Add("ADR", null, (s, e) => { AddItem(NotebookIndexNodeType.ADR); });
            }

            // model node
            //if (IsNodeInCorrectSection(treeView1.SelectedNode, treeView1.Nodes[1]))
            //{
            //switch (doc.DocumentType)
            //{
            //    case "Context":
            //        item.DropDownItems.Add("Person", null, (s, e) => { AddItem("Person"); });
            //        item.DropDownItems.Add("System", null, (s, e) => { AddItem("System"); });
            //        item.DropDownItems.Add("Enterprise Boundary", null, (s, e) => { AddItem("Enterprise_Boundary"); });
            //        break;
            //    case "Container":
            //        item.DropDownItems.Add("Container", null, (s, e) => { AddItem("Container"); });
            //        item.DropDownItems.Add("Container Boundary", null, (s, e) => { AddItem("Container_Boundary"); });
            //        item.DropDownItems.Add("System Boundary", null, (s, e) => { AddItem("System_Boundary"); });
            //        break;
            //    case "Component":
            //        item.DropDownItems.Add("Container Boundary", null, (s, e) => { AddItem("Container_Boundary"); });
            //        item.DropDownItems.Add("Component", null, (s, e) => { AddItem("Component"); });
            //        break;
            //    case "Dynamic":     // saving this for later
            //        break;
            //    case "Deployment":
            //        item.DropDownItems.Add("Node", null, (s, e) => { AddItem("Node"); });
            //        item.DropDownItems.Add("Container", null, (s, e) => { AddItem("Container"); });
            //        break;
            //}
            //}

            // relationships node
            //else if (IsNodeInCorrectSection(treeView1.SelectedNode, treeView1.Nodes[2], false))
            //{
            //switch (doc.DocumentType)
            //{
            //    case "Context":
            //    case "Deployment":
            //    case "Container":
            //    case "Component":
            //        item.DropDownItems.Add("Relationship", null, (s, e) => { AddItem("Relationship"); });
            //        break;
            //    case "Dynamic":     // saving this for later
            //        break;
            //}
            //}
            else
            {
                item.DropDownItems.Add("No options available for this node").Enabled = false; ;
            }
        }

        TreeNode previousNode = null;


        private void AddItem(NotebookIndexNodeType itemType)
        {
            if (previousNode != null)
            {
                NotebookIndexNode item = new NotebookIndexNode() { NodeType = itemType };
                //item.Parameters.Add(GetNewName(itemType));
                //item.Parameters.Add($"New {DisplayNames.GetDisplayName(itemType)}");

                TreeNode treeNode = new TreeNode();
                treeNode.Text = $"New {itemType.ToString()}";
                treeNode.Tag = item;
                previousNode.Nodes.Add(treeNode);

                treeView1.SelectedNode = treeNode;
            }
        }


        private void treeView1_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {

        }
    }
}

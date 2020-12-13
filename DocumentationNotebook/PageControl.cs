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
    public partial class PageControl : UserControl
    {
        public PageControl()
        {
            InitializeComponent();
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
        }

        public void ShowNode(NotebookIndexNode node)
        {
            viewerControl1.Visible = false;
            editorControl1.Visible = false;
            viewerControl2.Visible = false;
            c4EditorControl1.Visible = false;

            switch (node.NodeType)
            {
                case NotebookIndexNodeType.Markdown:
                case NotebookIndexNodeType.ADR:
                    if (node.ReadOnly)
                    {
                        viewerControl1.Location = new Point(0, 0);
                        viewerControl1.Dock = DockStyle.Fill;
                        viewerControl1.Visible = true;
                        viewerControl1.LoadFile(@"C:\Autoany\test.md");
                    }
                    else
                    {
                        editorControl1.Location = new Point(0, 0);
                        editorControl1.Dock = DockStyle.Fill;
                        editorControl1.Visible = true;
                        editorControl1.LoadFile(@"C:\Autoany\test.md");
                    }
                    break;
                case NotebookIndexNodeType.Link:
                    viewerControl2.Location = new Point(0, 0);
                    viewerControl2.Dock = DockStyle.Fill;
                    viewerControl2.Visible = true;
                    viewerControl2.ShowLink("http://www.cnn.com");
                    break;
                case NotebookIndexNodeType.C4:
                    c4EditorControl1.Location = new Point(0, 0);
                    c4EditorControl1.Dock = DockStyle.Fill;
                    c4EditorControl1.Visible = true;
                    break;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;


namespace Laba6_OOP
{
    class CustomTreeView : TreeView, IObserver, ISubject
    {
        private List<IObserver> observers = new List<IObserver>();
        public int selectedNode;
        protected Form1 currentForm;

        public CustomTreeView(Form1 form)
        {
            currentForm = form;
        }

        public void paintBranch(TreeNode root, Color color)
        {
            root.ForeColor = color;
            foreach (TreeNode node in root.Nodes)
            {
                paintBranch(node, color);
            }
        }

        protected void processNode(TreeNode node, Shape shape)
        {
            node.Text = shape.getID().ToString() + "  x: " + shape.getX().ToString() + "  y: " + shape.getY().ToString() + "  lastCommand: " + shape.getLastCommand();
            if (shape.getMarked() == true)
            {
                node.ForeColor = Color.Red;
                node.Checked = true;
            }
            else
            {
                node.ForeColor = Color.Black;
            }

            if (shape is CGroup)
            {
                Container subset = (shape as CGroup).getShapes();
                for (ContainerIterator it = subset.Begin(); it != subset.End(); ++it)
                {
                    TreeNode newNode = new TreeNode();
                    processNode(newNode, it.getNode().key);
                    node.Nodes.Add(newNode);
                }
            }
        }

        public void onSubjectChanged(ISubject subject)
        {
            if (subject is Container)
            {
                this.Nodes.Clear();

                for (ContainerIterator it = (subject as Container).Begin(); it != (subject as Container).End(); ++it)
                {
                    TreeNode newNode = new TreeNode();
                    processNode(newNode, it.getNode().key);
                    this.Nodes.Add(newNode);
                }
                return;
            }
        }

        public void addObserver(IObserver observer)
        {
            observers.Add(observer);
        }

        public void removeObserver(IObserver observer)
        {
            observers.Remove(observer);
        }

        public void notifyEveryone()
        {
            for (int i = 0; i < observers.Count(); ++i)
            {
                observers[i].onSubjectChanged(this);
            }
            currentForm.Invalidate();
        }
    }
}

using Newtonsoft.Json;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace finalproject
{
    public partial class Form1 : Form
    {
        private Node rootNode;
        private string fileName = "filesystem.dsfs";

        public Form1()
        {
            InitializeComponent();
            InitializeFileSystem();
            PopulateTreeView();
        }

        private void InitializeFileSystem()
        {
            rootNode = new Node("C: ", NodeType.Partition);

            if (File.Exists(fileName))
            {
                rootNode = LoadFromFile(fileName);
                RebuildParentChildRelationships(rootNode);
            }
        }

        private void PopulateTreeView()
        {
            treeView1.Nodes.Clear();
            TreeNode rootTreeNode = new TreeNode(rootNode.Name);
            rootTreeNode.Tag = rootNode;
            treeView1.Nodes.Add(rootTreeNode);
            PopulateTreeView(rootNode, rootTreeNode);
            treeView1.ExpandAll();
        }

        private void PopulateTreeView(Node node, TreeNode treeNode)
        {
            foreach (var child in node.Children)
            {
                TreeNode childTreeNode = new TreeNode(child.Name);
                childTreeNode.Tag = child;
                treeNode.Nodes.Add(childTreeNode);
                PopulateTreeView(child, childTreeNode);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveToFile(rootNode, fileName);
            MessageBox.Show("File system saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {
                Node selectedNode = (Node)treeView1.SelectedNode.Tag;
                string nodeName = txtName.Text.Trim();

                if (!string.IsNullOrEmpty(nodeName))
                {
                    if (rbPartition.Checked)
                    {
                        selectedNode.CreatePartition(nodeName);
                    }
                    else if (rbFolder.Checked)
                    {
                        selectedNode.CreateFolder(nodeName);
                    }
                    else if (rbFile.Checked)
                    {
                        selectedNode.AddFile(nodeName);
                    }

                    PopulateTreeView();
                }
                else
                {
                    MessageBox.Show("Please enter a name for the node.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a node in the tree view.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {
                Node selectedNode = (Node)treeView1.SelectedNode.Tag;
                selectedNode.Parent.Delete(selectedNode);
                PopulateTreeView();
            }
            else
            {
                MessageBox.Show("Please select a node in the tree view.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Node clipboard;

        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {
                Node selectedNode = (Node)treeView1.SelectedNode.Tag;
                clipboard = selectedNode.Copy();
            }
            else
            {
                MessageBox.Show("Please select a node in the tree view.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPaste_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null && clipboard != null)
            {
                Node selectedNode = (Node)treeView1.SelectedNode.Tag;
                selectedNode.Paste(clipboard);
                PopulateTreeView();
            }
            else
            {
                MessageBox.Show("Please select a node in the tree view and copy a node first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCut_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {
                Node selectedNode = (Node)treeView1.SelectedNode.Tag;
                clipboard = selectedNode.Copy();
                selectedNode.Parent.Delete(selectedNode);
                PopulateTreeView();
            }
            else
            {
                MessageBox.Show("Please select a node in the tree view.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnRename_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null)  // Make sure a node is selected
            {
                treeView1.LabelEdit = true;  // Allow the user to edit the label of the selected node
                treeView1.SelectedNode.BeginEdit();  // Begin the editing
            }
            else
            {
                MessageBox.Show("Please select a node to rename.");
            }
        }



        static void SaveToFile(Node rootNode, string fileName)
        {
            string jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(rootNode, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(fileName, jsonString);
        }

        static Node LoadFromFile(string fileName)
        {
            string jsonString = File.ReadAllText(fileName);
            return JsonConvert.DeserializeObject<Node>(jsonString);
        }
        public static void RebuildParentChildRelationships(Node node)
        {
            foreach (Node child in node.Children)
            {
                child.Parent = node;
                RebuildParentChildRelationships(child);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
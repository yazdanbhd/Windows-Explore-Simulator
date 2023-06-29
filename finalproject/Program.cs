using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Xml;
using Newtonsoft.Json;
using System.Windows.Forms;

namespace finalproject

{
    public class Node
    {
        public string Name { get; set; }
        public NodeType Type { get; set; }

        [Newtonsoft.Json.JsonIgnore]
        public Node Parent { get; set; }

        public List<Node> Children { get; set; }

        public Node(string name, NodeType type)
        {
            Name = name;
            Type = type;
            Children = new List<Node>();
        }

        public Node CreatePartition(string name)
        {
            if (Type != NodeType.Partition)
            {
                Node partition = new Node(name, NodeType.Partition);
                partition.Parent = this;
                Children.Add(partition);
                return partition;
            }
            return null;
        }

        public Node CreateFolder(string name)
        {
            if (Type != NodeType.File)
            {
                Node folder = new Node(name, NodeType.Folder);
                folder.Parent = this;
                Children.Add(folder);
                return folder;
            }
            return null;
        }


        public Node AddFile(string name)
        {
            if (Type != NodeType.File)
            {
                Node file = new Node(name, NodeType.File);
                file.Parent = this;
                Children.Add(file);
                return file;
            }
            return null;
        }

        public void Delete(Node node)
        {
            if (node.Parent != null)
            {
                node.Parent.Children.Remove(node);
            }
        }

        public Node Copy()
        {
            Node copy = new Node(Name, Type);
            foreach (var child in Children)
            {
                copy.Children.Add(child.Copy());
            }
            return copy;
        }

        public void Paste(Node node)
        {
            if (Type != NodeType.File)
            {
                Node copy = node.Copy();
                copy.Parent = this;
                Children.Add(copy);
            }
        }

        public void Cut(Node node)
        {
            Delete(node);
            Paste(node);
        }
        public void Rename(string newName)
        {
            Name = newName;
        }

    }

    public enum NodeType
    {
        Partition,
        Folder,
        File
    }
    class Program
    {
        static void Main()
        {
            // Create a root node
            Node rootNode = new Node("This Pc: ", NodeType.Partition);
            // Load the file system from a .dsfs file if it exists
            string fileName = "filesystem.dsfs";
            if (File.Exists(fileName))
            {
                rootNode = LoadFromFile(fileName);
            }

            Node partition1 = rootNode.CreatePartition("C");
            if (partition1 != null)
            {
                Node folder1 = partition1.CreateFolder("Documents");
                if (folder1 != null)
                {
                    Node file1 = folder1.AddFile("example.txt");
                }
            }
            // Save the file system to a .dsfs file
            SaveToFile(rootNode, fileName);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
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
    }
    


}
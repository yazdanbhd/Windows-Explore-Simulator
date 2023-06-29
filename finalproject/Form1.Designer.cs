using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace finalproject
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            treeView1 = new TreeView();
            txtName = new TextBox();
            btnAdd = new Button();
            btnDelete = new Button();
            btnSave = new Button();
            btnRename = new Button();
            rbPartition = new RadioButton();
            rbFolder = new RadioButton();
            rbFile = new RadioButton();
            btnCopy = new Button();
            btnPaste = new Button();
            btnCut = new Button();
            SuspendLayout();
            // 
            // treeView1
            // 
            treeView1.Location = new Point(14, 14);
            treeView1.Margin = new Padding(4, 3, 4, 3);
            treeView1.Name = "treeView1";
            treeView1.Size = new Size(311, 491);
            treeView1.TabIndex = 0;
            // 
            // txtName
            // 
            txtName.Location = new Point(332, 14);
            txtName.Margin = new Padding(4, 3, 4, 3);
            txtName.Name = "txtName";
            txtName.Size = new Size(233, 23);
            txtName.TabIndex = 1;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(332, 77);
            btnAdd.Margin = new Padding(4, 3, 4, 3);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(88, 27);
            btnAdd.TabIndex = 2;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(332, 111);
            btnDelete.Margin = new Padding(4, 3, 4, 3);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(88, 27);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(332, 479);
            btnSave.Margin = new Padding(4, 3, 4, 3);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(88, 27);
            btnSave.TabIndex = 4;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnRename
            // 
            btnRename.Location = new Point(332, 245);
            btnRename.Margin = new Padding(4, 3, 4, 3);
            btnRename.Name = "btnRename";
            btnRename.Size = new Size(88, 27);
            btnRename.TabIndex = 11;
            btnRename.Text = "Rename";
            btnRename.UseVisualStyleBackColor = true;
            btnRename.Click += btnRename_Click;
            // 
            // rbPartition
            // 
            rbPartition.AutoSize = true;
            rbPartition.Location = new Point(332, 44);
            rbPartition.Margin = new Padding(4, 3, 4, 3);
            rbPartition.Name = "rbPartition";
            rbPartition.Size = new Size(70, 19);
            rbPartition.TabIndex = 5;
            rbPartition.TabStop = true;
            rbPartition.Text = "Partition";
            rbPartition.UseVisualStyleBackColor = true;
            // 
            // rbFolder
            // 
            rbFolder.AutoSize = true;
            rbFolder.Location = new Point(411, 44);
            rbFolder.Margin = new Padding(4, 3, 4, 3);
            rbFolder.Name = "rbFolder";
            rbFolder.Size = new Size(58, 19);
            rbFolder.TabIndex = 6;
            rbFolder.TabStop = true;
            rbFolder.Text = "Folder";
            rbFolder.UseVisualStyleBackColor = true;
            // 
            // rbFile
            // 
            rbFile.AutoSize = true;
            rbFile.Location = new Point(481, 44);
            rbFile.Margin = new Padding(4, 3, 4, 3);
            rbFile.Name = "rbFile";
            rbFile.Size = new Size(43, 19);
            rbFile.TabIndex = 7;
            rbFile.TabStop = true;
            rbFile.Text = "File";
            rbFile.UseVisualStyleBackColor = true;
            // 
            // btnCopy
            // 
            btnCopy.Location = new Point(332, 144);
            btnCopy.Margin = new Padding(4, 3, 4, 3);
            btnCopy.Name = "btnCopy";
            btnCopy.Size = new Size(88, 27);
            btnCopy.TabIndex = 8;
            btnCopy.Text = "Copy";
            btnCopy.UseVisualStyleBackColor = true;
            btnCopy.Click += btnCopy_Click;
            // 
            // btnPaste
            // 
            btnPaste.Location = new Point(332, 178);
            btnPaste.Margin = new Padding(4, 3, 4, 3);
            btnPaste.Name = "btnPaste";
            btnPaste.Size = new Size(88, 27);
            btnPaste.TabIndex = 9;
            btnPaste.Text = "Paste";
            btnPaste.UseVisualStyleBackColor = true;
            btnPaste.Click += btnPaste_Click;
            // 
            // btnCut
            // 
            btnCut.Location = new Point(332, 211);
            btnCut.Margin = new Padding(4, 3, 4, 3);
            btnCut.Name = "btnCut";
            btnCut.Size = new Size(88, 27);
            btnCut.TabIndex = 10;
            btnCut.Text = "Cut";
            btnCut.UseVisualStyleBackColor = true;
            btnCut.Click += btnCut_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(580, 519);
            Controls.Add(rbFile);
            Controls.Add(rbFolder);
            Controls.Add(rbPartition);
            Controls.Add(btnSave);
            Controls.Add(btnDelete);
            Controls.Add(btnAdd);
            Controls.Add(btnCopy);
            Controls.Add(btnPaste);
            Controls.Add(btnCut);
            Controls.Add(btnRename);
            Controls.Add(txtName);
            Controls.Add(treeView1);
            Margin = new Padding(4, 3, 4, 3);
            Name = "Form1";
            Text = "File System App";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private TreeView treeView1;
        private TextBox txtName;
        private Button btnAdd;
        private Button btnDelete;
        private Button btnSave;
        private RadioButton rbPartition;
        private RadioButton rbFolder;
        private RadioButton rbFile;
        private Button btnCopy;
        private Button btnPaste;
        private Button btnCut;
        private Button btnRename;
    }

}
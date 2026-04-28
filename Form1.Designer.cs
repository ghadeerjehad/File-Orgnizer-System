namespace SWE_HW2
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSelectFolder = new System.Windows.Forms.Button();
            this.btnTree = new System.Windows.Forms.Button();
            this.btnBar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.treeFolders = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // btnSelectFolder
            // 
            this.btnSelectFolder.Location = new System.Drawing.Point(62, 380);
            this.btnSelectFolder.Name = "btnSelectFolder";
            this.btnSelectFolder.Size = new System.Drawing.Size(91, 23);
            this.btnSelectFolder.TabIndex = 0;
            this.btnSelectFolder.Text = "Browse";
            this.btnSelectFolder.UseVisualStyleBackColor = true;
            this.btnSelectFolder.Click += new System.EventHandler(this.btnSelectFolder_Click);
            // 
            // btnTree
            // 
            this.btnTree.Location = new System.Drawing.Point(182, 51);
            this.btnTree.Name = "btnTree";
            this.btnTree.Size = new System.Drawing.Size(75, 23);
            this.btnTree.TabIndex = 1;
            this.btnTree.Text = "Tree";
            this.btnTree.UseVisualStyleBackColor = true;
            this.btnTree.Click += new System.EventHandler(this.btnTree_Click);
            // 
            // btnBar
            // 
            this.btnBar.Location = new System.Drawing.Point(285, 51);
            this.btnBar.Name = "btnBar";
            this.btnBar.Size = new System.Drawing.Size(75, 23);
            this.btnBar.TabIndex = 2;
            this.btnBar.Text = "Bar Chart";
            this.btnBar.UseVisualStyleBackColor = true;
            this.btnBar.Click += new System.EventHandler(this.btnBar_Click);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Location = new System.Drawing.Point(159, 80);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(513, 323);
            this.panel1.TabIndex = 3;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // treeFolders
            // 
            this.treeFolders.Location = new System.Drawing.Point(12, 80);
            this.treeFolders.Name = "treeFolders";
            this.treeFolders.Size = new System.Drawing.Size(141, 294);
            this.treeFolders.TabIndex = 0;
            this.treeFolders.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeFolders_AfterSelect);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.treeFolders);
            this.Controls.Add(this.btnBar);
            this.Controls.Add(this.btnTree);
            this.Controls.Add(this.btnSelectFolder);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSelectFolder;
        private System.Windows.Forms.Button btnTree;
        private System.Windows.Forms.Button btnBar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TreeView treeFolders;
    }
}


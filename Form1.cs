using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace SWE_HW2
{
    public partial class Form1 : Form
    {
        private Folder rootFolder;                    // top folder (Composite)
        private FileSystemClasses currentNode;
        private VisualizationStrategy strategy;
        public Form1()
        {
            InitializeComponent();
            strategy = new TreeVisualization();       // default visualization
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            if (currentNode == null || strategy == null) return;

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.Clear(panel1.BackColor);

            // apply scroll offset + margin
            var scroll = panel1.AutoScrollPosition;
            e.Graphics.TranslateTransform(scroll.X + 20, scroll.Y + 20);

            int height = strategy.Visualize(currentNode, e.Graphics, 0, 0);

            // tell panel how big the virtual area is
            panel1.AutoScrollMinSize = new Size(0, height + 40);
        }

        private void btnSelectFolder_Click(object sender, EventArgs e)
        {
            using(var dlg = new FolderBrowserDialog())
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    string path = dlg.SelectedPath;

                    // build composite structure
                    rootFolder = BuildFolder(new DirectoryInfo(path));

                    // calculate sizes for all folders/files
                    rootFolder.CalculateSize();
                    FillTreeView();
                    currentNode = rootFolder;

                    // redraw
                    panel1.Invalidate();
                }
            }
        }
        private Folder BuildFolder(DirectoryInfo dir)
        {
            var folder = new Folder(dir.Name);

            // files
            foreach (var fi in dir.GetFiles())
            {
                var f = new File(fi.Name, fi.Length, fi.Extension); // your File class
                folder.Add(f);
            }

            // subfolders
            foreach (var subDir in dir.GetDirectories())
            {
                try
                {
                    var subFolder = BuildFolder(subDir);
                    folder.Add(subFolder);
                }
                catch (UnauthorizedAccessException)
                {
                    // skip folders we can't access
                }
            }

            return folder;
        }

        private void btnBar_Click(object sender, EventArgs e)
        {
            strategy = new BarChartVisualization();
            panel1.Invalidate();
        }

        private void btnTree_Click(object sender, EventArgs e)
        {
            strategy = new TreeVisualization();
            panel1.Invalidate();
        }

        private void treeFolders_AfterSelect(object sender, TreeViewEventArgs e)
        {
            currentNode = e.Node.Tag as FileSystemClasses;
            panel1.Invalidate();
        }
        private void FillTreeView()
        {
            treeFolders.BeginUpdate();
            treeFolders.Nodes.Clear();

            var rootNode = CreateNode(rootFolder);
            treeFolders.Nodes.Add(rootNode);
            treeFolders.ExpandAll();

            treeFolders.SelectedNode = rootNode;
            treeFolders.EndUpdate();
        }

        private TreeNode CreateNode(FileSystemClasses item)
        {
            var node = new TreeNode(item.Name);
            node.Tag = item;

            if (item is Folder folder)
            {
                foreach (var child in folder.Children)
                {
                    node.Nodes.Add(CreateNode(child));
                }
            }

            return node;
        }

    }
}

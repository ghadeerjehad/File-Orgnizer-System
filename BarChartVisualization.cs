using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace SWE_HW2
{
    internal class BarChartVisualization : VisualizationStrategy
    {

        private const int BarHeight = 24;
        private const int VerticalSpacing = 8;
        private const int MaxBarWidth = 420;

        public override int Visualize(FileSystemClasses root, Graphics g, int x, int y)
        {
            long maxSize = root.Size == 0 ? 1 : root.Size;
            return DrawBar(root, g, x, y, maxSize, 0);
        }

        // returns next free Y
        private int DrawBar(FileSystemClasses node, Graphics g, int x, int y, long maxSize, int depth)
        {
            float ratio = node.Size / (float)maxSize;
            int width = (int)(ratio * MaxBarWidth);

            int barX = x + depth * 25;

            var rect = new Rectangle(barX, y, width, BarHeight);

            Brush brush = (node is Folder) ? Brushes.SteelBlue : Brushes.Orange;
            g.FillRectangle(brush, rect);
            g.DrawRectangle(Pens.Black, rect);

            string label = $"{FormatSize(node.Size)} {node.Name}";
            g.DrawString(label,
                         SystemFonts.DefaultFont, Brushes.Black,
                         rect.X + 4, rect.Y + 4);

            int nextY = y + BarHeight + VerticalSpacing;

            if (node is Folder folder)
            {
                foreach (var child in folder.Children.OrderByDescending(c => c.Size))
                {
                    nextY = DrawBar(child, g, x, nextY, maxSize, depth);
                }
            }

            return nextY;
        }

        private string FormatSize(long bytes)
        {
            double mb = bytes / (1024.0 * 1024.0);
            return $"({mb:0.0} MB)";
        }
    }
}

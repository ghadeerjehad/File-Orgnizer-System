using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWE_HW2
{
    internal class Folder : FileSystemClasses
    {
        private List<FileSystemClasses> _children = new List<FileSystemClasses>();
        public IReadOnlyList<FileSystemClasses> Children => _children.AsReadOnly();
        //Constructor
        public Folder(String name) : base(name) { }
        public override void Add(FileSystemClasses c)
        {
            _children.Add(c);
        }
        public override void Remove(FileSystemClasses c)
        {
            _children.Remove(c);
        }
        public override void display(int depth)
        {
            Console.WriteLine(new String('_', depth) + name);
            // Recursevly display child nodes
            foreach (FileSystemClasses c in _children)
            {
                c.display(depth + 2);
            }
        }
        public override long CalculateSize()
        {
            long total = 0;
            foreach (var child in _children)
                total += child.CalculateSize();

            size = total;
            return size;
        }
    }

}
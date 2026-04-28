using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWE_HW2
{
    internal class File : FileSystemClasses
    {
        private string extension;
        //Constructor
        public File(String name, long size, string extension) : base(name) {
            this.size = size;
            this.extension = extension;
        }

        public override void Add(FileSystemClasses c)
        {
            Console.WriteLine("cannot add to a file");
        }
        public override void Remove(FileSystemClasses c)
        {
            Console.WriteLine("cannot remove from a file");
        }
        public override void display(int depth)
        {
            Console.WriteLine(new String('_', depth) + name);
        }
        public override long CalculateSize()
        {
            return size;            // file size already known
        }
    }
}

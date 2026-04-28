using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWE_HW2
{
    internal abstract class FileSystemClasses
    {
        protected string name;
        protected long size;

        public string Name => name;
        public long Size => size;

        //Constructor
        public FileSystemClasses(string name)
        {
            this.name = name;
        }

        public abstract void Add(FileSystemClasses c);
        public abstract void Remove(FileSystemClasses c);
        public abstract void display(int depth);
        public abstract long CalculateSize();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrakerModelLibrary
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Department_Head { get; set; }

        public Department(string name, int department_Head)
        {
            Name = name;
            Department_Head = department_Head;
        }
        public override bool Equals(object? obj)
        {
            return this.Name.Equals((obj as Department).Name);
        }
        public override string ToString()
        {
            return Id + " " + Name + " " + Department_Head;
        }
    }
}

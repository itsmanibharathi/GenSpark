using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace basic.moduls
{
    internal class TryGetSet
    {
        public string name1;
        private string _name;
        public string name2
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        public string name3
        {
            get => _name;
            set => _name = value;
        }
        public string name4 { get; set; }

    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingModelLib
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Phone { get; set; } = String.Empty;
        public int Age { get; set; }

        public bool Equals(Customer? other)
        {
            return this.Id.Equals(other.Id);
        }
    }
}

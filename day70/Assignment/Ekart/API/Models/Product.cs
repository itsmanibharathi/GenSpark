﻿using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string imageUrl { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}

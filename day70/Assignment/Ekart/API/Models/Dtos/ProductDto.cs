﻿namespace API.Models.Dtos
{
    public class ProductDto
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public IFormFile? UploadImage { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace DataBaseLayer.Models
{
    public class ProductImage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Size { get; set; }
        public string Type { get; set; }
        public string Path { get; set; }
        public int productId { get; set; }
        public Product product { get; set; }

    }
}

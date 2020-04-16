using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataBaseLayer.Models
{
   public class Product
    {
        public int Id { get; set; }
        [Column(TypeName = "VARCHAR(250)")]
          
        public String ArabicName { get; set; }
        [Column(TypeName = "VARCHAR(250)")]
          
        public String FrenchName { get; set; }
        [Column(TypeName = "VARCHAR(250)")]
          
        public String EnglishName { get; set; }

          
        public String ArabicDesc { get; set; }
          
        public String FrenchDesc { get; set; }
          
        public String EnglishDesc { get; set; }
        public int Quantity { get; set; }

        public float Price { get; set; }
        public float Disaccunt { get; set; }
        [Column(TypeName = "VARCHAR(250)")]
          
        public string InsertUser { get; set; }
        public DateTime? InsertDate { get; set; }
        [Column(TypeName = "VARCHAR(250)")]
          
        public string UpdateUser { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool IsDelete { get; set; }
        [Column(TypeName = "VARCHAR(250)")]
          
        public String IPAdress { get; set; }
        [Column(TypeName = "VARCHAR(250)")]
          
        public string ProductImageLink { get; set; }
        [Column(TypeName = "VARCHAR(250)")]
          
        public string ProductImageName { get; set; }
       [ForeignKey("categoryId")]
        public  virtual Category category { get; set; }
       public int categoryId { get; set; }
        public ICollection<ProductImage> ProductImages { get; set; }


    }
}

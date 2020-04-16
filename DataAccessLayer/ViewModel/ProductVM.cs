using DataBaseLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.ViewModel
{
    public class ProductVM
    {
        public int Id { get; set; }

        public String ArabicName { get; set; }

        public String FrenchName { get; set; }

        public String EnglishName { get; set; }
        public int Quantity { get; set; }

        public float Price { get; set; }
        public float Disaccunt { get; set; }

        public string InsertUser { get; set; }
        public DateTime? InsertDate { get; set; }

        public string UpdateUser { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool IsDelete { get; set; }

        public String IPAdress { get; set; }
        //public string ProductImageLink { get; set; }

        //public string ProductImageName { get; set; }
        public int CategoryId { get; set; }
        public Category category { get; set; }
        public List<IFormFile> File { get; set; }
        public List<SelectListItem> Categories { get; set; }

    }

}

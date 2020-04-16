using DataBaseLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.ViewModel
{
    public class CategoryVM
    {
        public int Id { get; set; }
       
        public String ArabicName { get; set; }
    
        public String FrenchName { get; set; }
      
        public String EnglishName { get; set; }
    

        public string InsertUser { get; set; }
        public DateTime? InsertDate { get; set; }
     
        public string UpdateUser { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool IsDelete { get; set; }
      
        public String IPAdress { get; set; }
        public ICollection<Product> Products { get; set; }

    }
}

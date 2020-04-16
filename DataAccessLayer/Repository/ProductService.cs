using DataAccessLayer.IRepository;
using DataBaseLayer.Data;
using DataBaseLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace DataAccessLayer.Repository
{
    public class ProductService :Repository<Product>,IProductService
    {
        public ProductService(DataContext dataContext) : base(dataContext)
        {

        }

        public IQueryable<Product> GetPage(string filter, int initalPage, int pageSize, out int totalRecord, out int recordsFilter)
        {
            var data = GetQueryable(p => p.IsDelete == false);
            totalRecord = GetQueryable(p => p.IsDelete == false).Count();
           
          
            if (!string.IsNullOrEmpty(filter))
            {

                data = data.Where(x => 
                x.Price.ToString().Contains(filter.ToLower()) ||
                x.EnglishName.ToLower().Contains(filter.ToLower()) ||
                x.ArabicName.ToLower().Contains(filter.ToLower()) ||
                x.FrenchName.ToLower().Contains(filter.ToLower()) 
                );
            }
           
            recordsFilter = data.Count();
            data = data.OrderByDescending(x => x.InsertDate).Skip(initalPage ).Take(pageSize);
            return data;
             
        }
    }
}

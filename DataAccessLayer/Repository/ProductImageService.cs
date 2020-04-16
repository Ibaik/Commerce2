using DataAccessLayer.IRepository;
using DataBaseLayer.Data;
using DataBaseLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Repository
{
   public class ProductImageService : Repository<ProductImage>, IProductImageService
    {
        public ProductImageService(DataContext dataContext):base(dataContext)
        {
         
        }
    }
}

using DataAccessLayer.IRepository;
using DataBaseLayer.Data;
using DataBaseLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Repository
{
   public class CategoryService : Repository<Category>, ICategoryService
    {
        public CategoryService(DataContext dataContext):base(dataContext)
        {
         
        }
    }
}

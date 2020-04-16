using DataAccessLayer.ViewModel;
using DataBaseLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer.IRepository
{
   public interface IProductService:IRepository<Product>
    {
        
        IQueryable<Product> GetPage(string filter, int initalPage, int pageSize,
                                    out int totalRecord,
                                    out int recordsFilter);

    }
}

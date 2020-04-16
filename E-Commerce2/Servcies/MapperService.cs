using AutoMapper;
using DataAccessLayer.ViewModel;
using DataBaseLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce2.Servcies
{
    public class MapperService: Profile
    {
        public MapperService()
        {
            CreateMap<Category, CategoryVM>().ReverseMap();
            CreateMap<Product, ProductVM>().ReverseMap();
            CreateMap<ProductImage, ProductImageVM>().ReverseMap();

        }
    }
  }


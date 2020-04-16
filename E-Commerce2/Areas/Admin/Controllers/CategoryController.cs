using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DataAccessLayer.IRepository;
using DataAccessLayer.Repository;
using DataAccessLayer.ViewModel;
using DataBaseLayer.Models;
using E_Commerce2.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce2.Areas.Admin.Controllers
{
    [Area("Admin")]
   // [Route("Admin/Category")]
    public class CategoryController : BaseController
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(IHttpContextAccessor accessor, ICategoryService categoryService, IMapper mapper) : base(accessor)
        {
            this._categoryService = categoryService;
            _mapper = mapper;
        }

        public IActionResult Categories()
        {
            return View();
        }

        public async Task<IActionResult> _Add()
        {
          //  _categoryService.AddAndLogAsync()

            return PartialView("_Add");
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task <JsonResult> AddCategories(CategoryVM model)
        {

           var result= await _categoryService.AddAsync(_mapper.Map<Category>(model));

            return Json(result);
        }
    }
}
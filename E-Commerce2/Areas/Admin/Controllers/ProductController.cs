using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using DataAccessLayer.IRepository;
using DataAccessLayer.ViewModel;
using DataBaseLayer.Models;
using E_Commerce2.Controllers;
using E_Commerce2.Enum;
using E_Commerce2.Utilities;
using GazaEmgCore2.Common;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using static System.Net.Mime.MediaTypeNames;

namespace E_Commerce2.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : BaseController
    {
        private readonly IProductService productService;
        private readonly IMapper mapper;
        private readonly IHostingEnvironment hosting;
        private readonly IProductImageService productImageService;
        private readonly ICategoryService categoryService;
       

        public ProductController(
                                 IHttpContextAccessor accessor,
                                 IProductService productService,
                                 IMapper mapper,
                                 IHostingEnvironment hosting,
                                 IProductImageService productImageService
                                ,ICategoryService categoryService
                               ) :base(accessor)
        {
            this.productService = productService;
            this.mapper = mapper;
            this.hosting = hosting;
            this.productImageService = productImageService;
            this.categoryService = categoryService;
           // this.logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }
      
        public IActionResult Products()
        {
            return View();
        }
        /*
          [HttpGet]
        public   IActionResult GetPersonsAjax(DataTablesParam param)
        {
            int totalNo = 0, recordFilter = 0;
            var QuauntiedPesonList = _IQuarantinedPersonRepository.GetPaginated(param.sSearch, param.iDisplayStart,
            param.iDisplayLength, out totalNo, out recordFilter);
            return Json(new 
            {
                data = QuauntiedPesonList,
                eEcho = param.sEcho,
                iTotalDisplayRecords = recordFilter,
                iTotalRecords = totalNo
            }); 
        }

             */
             [HttpPost]
             public IActionResult GetProduct(DataTablesParam param)
        {
            int totalNo = 0, recordFilter = 0;
           var productList= productService.GetPage(
                                   param.sSearch,
                                   param.iDisplayStart, 
                                   param.iDisplayLength,
                                   out totalNo, 
                                   out recordFilter
                                   );
            return Json(new
            {
                data = productList,
                eEcho = param.sEcho,
                iTotalDisplayRecords = recordFilter,
                iTotalRecords = totalNo
            });
        }
        public async Task<IActionResult> _AddProduct()
        {
            //var cat=  getAllCategories();
            var categoryList = new ProductVM
            {
                Categories = categoryService.GetAllQuerable().Select(x => new SelectListItem { Text = x.EnglishName, Value = x.Id.ToString() }).ToList()
            };
            //var modal = new ProductVM
            //{
            //    Categories = categoryService.GetAllQuerable().ToList()
            //};
            return PartialView("_AddProduct", categoryList);
        }
        public async Task<IActionResult> AddProduct()
        {
            var categoryList = new ProductVM
            {
                Categories = categoryService.GetAllQuerable().Select(x => new SelectListItem { Text = x.EnglishName, Value = x.Id.ToString() }).ToList()
            };
            
            return View(categoryList);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> AddProducts(ProductVM model)
        {
            string upload= string.Empty;
            string fileName = string.Empty;
            string type = string.Empty;
            //long size = 0;
            string fullPath = string.Empty;
           

           
            var vmodel = new Product
            {
                ArabicName = model.ArabicName,
                EnglishName = model.EnglishName,
                FrenchName = model.FrenchName,
                Price = model.Price,
                Quantity = model.Quantity,
                Disaccunt = model.Disaccunt,
                InsertUser = model.InsertUser,
                IPAdress = model.IPAdress,
                //ProductImageLink = upload,
                //ProductImageName = fileName,
                InsertDate = DateTime.Now,
                category=categoryService.Find(model.CategoryId)                  
            };
        
            var result = await productService.AddAsync(vmodel);

            if (model.File != null && model.File.Count > 0)
            {
                foreach (IFormFile item in model.File)
                {
                    type = item.ContentType;
                    // size=item.Length;
                    upload = Path.Combine(hosting.WebRootPath, "ProductImage");
                    fileName = Guid.NewGuid().ToString() + "_" + item.FileName;
                    fullPath = Path.Combine(upload, fileName);
                    item.CopyTo(new FileStream(fullPath, FileMode.Create));
                    var productImage = new ProductImage
                    {
                        Name = fileName,
                        Type = type,
                        // Size=Convert.ToInt32(size),
                        Path = fullPath,
                        productId = vmodel.Id

                    };
                    await productImageService.AddAsync(productImage);

                }

            }

            return Json(new
            {
                status = JsonStatus.Success,
                link = "جيد",
                color = NotificationColor.success.ToString().ToLower(),
                msg = "تم الحفظ نجاح"
            });
        }
        public async Task<IActionResult> Details(int id)
        {
            var result = await productService.FindAsync(id);
            //var result = await productImageService.GetAsync(x=>x.Id==id);
            //IQueryable result =  productImageService.GetQueryable(x => x.Id == id).AsQueryable();

            return View(result);
        }

        public ActionResult Edit(int id)
        {
            var obj = productService.Find(id);
         //   var authorId = obj.Author == null ? obj.Author.Id = 0 : obj.Author.Id;
            var model = new ProductVM
            {
                ArabicName = obj.ArabicName,
                EnglishName = obj.EnglishName,
                FrenchName = obj.FrenchName,
                Price = obj.Price,
                Quantity = obj.Quantity,
                Disaccunt = obj.Disaccunt,
                UpdateUser = obj.UpdateUser,
                IPAdress = obj.IPAdress,
                //ProductImageLink = obj.ProductImageLink,
                //ProductImageName = obj.ProductImageName,
                UpdateDate=DateTime.Now
            };
            return View(model);
        }

        // POST: BookController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> Edit(ProductVM productvm)
        {
            try
            {
                // Edit image
                string upload = string.Empty;
                string fileName = string.Empty;
                //////////
                //if (productvm.File != null)
                //{
                //    upload = Path.Combine(hosting.WebRootPath, "ProductImage");
                //    fileName = productvm.File.FileName;
                //    string fullPath = Path.Combine(upload, fileName);

                //    // delete old image
                //    string oldFileName = productService.Find(productvm.Id).ProductImageLink;
                //    string fullOldPath = Path.Combine(upload, oldFileName);
                //    if (fullPath != fullOldPath)
                //    {
                //        System.IO.File.Delete(fullOldPath);
                //        //save new image
                //        productvm.File.CopyTo(new FileStream(fullPath, FileMode.Create));
                //    }


                //}

                //   var obj = bookRepository.Find(id);
             //   var authors = autherRepository.Find(bookvm.AuthorID);
                Product model = new Product
                {
                    ArabicName = productvm.ArabicName,
                    EnglishName = productvm.EnglishName,
                    FrenchName = productvm.FrenchName,
                    Price = productvm.Price,
                    Disaccunt = productvm.Disaccunt,
                    InsertUser = productvm.InsertUser,
                    IPAdress = productvm.IPAdress,
                    ProductImageLink = upload,
                    ProductImageName = fileName,
                };
                var result = await productService.UpdateAsync(mapper.Map<Product>(model));
                return Json(result);
            }
            catch 
            {
                return null;
            }
        }
        //public List<Category> fillCategories()
        //{
        //    var categories = categoryService.GetAllQuerable().ToList();
        //    categories.Insert(0, new Category { Id = -1, EnglishName = "-- Please Add Category --" });
        //    return categories;
        //}
        //public ProductVM getAllCategories()
        //{
        //    var model = new ProductVM
        //    {
        //        Categories = fillCategories()
        //    };
        //    return model;
        //}


        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<JsonResult> AddProductss(ProductVM model)
        {
            string upload = string.Empty;
            string fileName = string.Empty;
            if (model.File != null && model.File.Count > 0)
            {
                foreach (IFormFile item in model.File)
                {
                    upload = Path.Combine(hosting.WebRootPath, "upload");
                    fileName = Guid.NewGuid().ToString() + "_" + item.FileName;
                    string fullPath = Path.Combine(upload, fileName);
                    item.CopyTo(new FileStream(fullPath, FileMode.Create));
                }

            }

            var d = categoryService.Find(3);

            var vmodel = new Product
            {
                ArabicName = model.ArabicName,
                EnglishName = model.EnglishName,
                FrenchName = model.FrenchName,
                Price = model.Price,
                Quantity = model.Quantity,
                Disaccunt = model.Disaccunt,
                InsertUser = model.InsertUser,
                IPAdress = model.IPAdress,
                ProductImageLink = upload,
                ProductImageName = fileName,
                InsertDate = DateTime.Now,
                category = categoryService.Find(3)
            };
            // vmodel.category = d;
            var result = await productService.AddAsync(vmodel);
            return Json(result);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task OnPostAsync(List<IFormFile> files)
        {
            foreach (var file in Request.Form.Files)
            {
                //get uploaded file name: true to create temp name, false to get real name
                var fileName = file.TempFileName(false);

                if (file.Length > 0)
                {
                    // optional : server side resize create image with watermark
                    // these steps requires LazZiya.ImageResize package from nuget.org
                    if (fileName.ToLower().EndsWith(".jpg") || fileName.ToLower().EndsWith(".png"))
                    {
                        using (var stream = file.OpenReadStream())
                        {
                            // Create image file from uploaded file stream
                            // Then resize, and add text/image watermarks
                            // And save
                            //using (var img = Image.FromStream(stream))
                            //{
                            //    img.ScaleAndCrop(300, 300, TargetSpot.MiddleRight)
                            //    .AddImageWatermark(@"wwwroot\images\icon.png")
                            //    .AddTextWatermark("http://ziyad.info")
                            //    .SaveAs($"wwwroot\\upload\\{fileName}");
                            //}
                        }
                    }
                    else
                    {
                        // upload and save files to upload folder
                        using (var stream = new FileStream($"wwwroot\\upload\\{fileName}", FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }
                    }
                }
            }
        }

        public JsonResult OnGetListFolderContents()
        {
            var folderPath = $"wwwroot\\upload";

            if (!Directory.Exists(folderPath))
                return new JsonResult("Folder not exists!") { StatusCode = (int)HttpStatusCode.NotFound };

            var folderItems = Directory.GetFiles(folderPath);

            if (folderItems.Length == 0)
                return new JsonResult("Folder is empty!") { StatusCode = (int)HttpStatusCode.NoContent };

            var galleryItems = new List<FileItem>();

            foreach (var file in folderItems)
            {
                var fileInfo = new FileInfo(file);
                galleryItems.Add(new FileItem
                {
                    Name = fileInfo.Name,
                    FilePath = $"https://localhost:44326/upload/{fileInfo.Name}",
                    FileSize = fileInfo.Length
                });
            }

            return new JsonResult(galleryItems) { StatusCode = 200 };
        }

        public JsonResult OnGetDeleteFile(string file)
        {
            var filePath = Path.Combine($"wwwroot\\upload\\{file}");

            try
            {
                System.IO.File.Delete(filePath);
            }
            catch
            {
                return new JsonResult(false) { StatusCode = (int)HttpStatusCode.InternalServerError };
            }

            return new JsonResult(true) { StatusCode = (int)HttpStatusCode.OK };
        }
    }
}

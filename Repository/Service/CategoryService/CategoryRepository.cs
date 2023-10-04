using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Context;
using DataLayer.DTO.Category;
using DataLayer.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Repository.Interface.CategoryInteface;

namespace Repository.Service.CategoryService
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DibaContext _context;
        private readonly IHostingEnvironment hostingEnvironment;

        public CategoryRepository(DibaContext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            this.hostingEnvironment = hostingEnvironment;
        }

        public void Remove(int id)
        {
            var currentdirctory = hostingEnvironment.WebRootPath;
            var cat = GetCategorybyID(id);
            cat.IsDeleted = true;
            if (cat.ImageAddress != null)
            {
                var oldpath = Path.Combine(currentdirctory, "CategoryImages", cat.ImageAddress);
                File.Delete(oldpath);
            }
            _context.SaveChanges();
          
        }

        public void Edit(ModifyCategoryProductDTO modifyCategoryProductDto, IFormFile file)
        {
            var cat = GetCategorybyID(modifyCategoryProductDto.Id);

            var finalname = cat.ImageAddress;
            if (file != null)
            {

                var filename = Path.GetFileName(file.FileName);
                var FileExtension = Path.GetExtension(filename);
                var uniqfilename = Guid.NewGuid().ToString();
                finalname = uniqfilename + FileExtension;
                var currentdirctory = hostingEnvironment.WebRootPath;

                if (!Directory.Exists(Path.Combine(currentdirctory, "CategoryImages")))
                {
                    Directory.CreateDirectory(Path.Combine(currentdirctory, "CategoryImages"));
                }

                var finalpath = Path.Combine(currentdirctory, "CategoryImages", finalname);
                if (cat.ImageAddress != null)
                {
                    var oldpath = Path.Combine(currentdirctory, "CategoryImages", cat.ImageAddress);
                    File.Delete(oldpath);
                }

                FileStream fileStream = new FileStream(finalpath, FileMode.Create);
                file.CopyTo(fileStream);

            }

            cat.categoryName = modifyCategoryProductDto.categoryName;
            cat.Parentid = modifyCategoryProductDto.Parentid;
            cat.ImageAddress = finalname;
            _context.SaveChanges();
        }

        public CategoryProduct GetCategorybyID(int id)
            {
                return _context.CategoryProducts.Find(id);
            }

            public List<CategoryProduct> GetCategories()
            {
                return _context.CategoryProducts.Where(p=>p.IsDeleted!=true).ToList();
            }

            public void CreateCategory(CreateCategoryProductDTO categoryProduct)
            {
                var finalname = "";
                if (categoryProduct.ImageAddress != null)
                {
                    var filename = Path.GetFileName(categoryProduct.ImageAddress.FileName);
                    var FileExtension = Path.GetExtension(filename);
                    var uniqfilename = Guid.NewGuid().ToString();
                    finalname = uniqfilename + FileExtension;
                    var currentdirctory = hostingEnvironment.WebRootPath;
                    if (!Directory.Exists(Path.Combine(currentdirctory, "CategoryImages")))
                    {
                        Directory.CreateDirectory(Path.Combine(currentdirctory, "CategoryImages"));
                    }

                    var finalpath = Path.Combine(currentdirctory, "CategoryImages", finalname);
                    FileStream fileStream = new FileStream(finalpath, FileMode.Create);
                    categoryProduct.ImageAddress.CopyTo(fileStream);
                }

                CategoryProduct product = new CategoryProduct()
                {
                    ImageAddress = finalname,
                    Parentid = categoryProduct.Parentid,
                    categoryName = categoryProduct.categoryName,
                };
                _context.CategoryProducts.Add(product);
                _context.SaveChanges();
            }
        }
    }

    
    

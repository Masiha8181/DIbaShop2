using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Context;
using DataLayer.DTO.Product;
using DataLayer.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Repository.Interface.ProductInterface;

namespace Repository.Service.ProductService
{
    public class ProductRepository : IProductRepository
    {
        private readonly DibaContext _context;
        private readonly IHostingEnvironment hostingEnvironment;

        public ProductRepository(DibaContext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            this.hostingEnvironment = hostingEnvironment;
        }

        public List<Product> getProductsWithPageIDAndFilter(int pageID,string Search,string Order,string Stock,int Category)
        {
            IQueryable <Product> Query = _context.Products.Where(p=>p.IsDeleted!=true);
            if (!string.IsNullOrEmpty(Search))
            {
                Query = Query.Where(p => p.ProductName.Contains(Search) );
            }

            if (!string.IsNullOrEmpty(Order)&&Order!="Date")
            {
                switch (Order)
                {
                    case "Date":
                        Query = Query.OrderBy(q => q.CreateDate);
                        break;

                    case "Date-Desc":
                        Query = Query.OrderByDescending(q => q.CreateDate);
                        break;
                    case "SellCount":
                        Query = Query.OrderBy(q => q.SellCount);
                        break;
                    case "Desc":
                        Query = Query.OrderBy(q => q.ProductName);
                        break;
                    case "Asc":
                        Query = Query.OrderByDescending(q => q.ProductName);
                        break;
                    case "Low":
                        Query = Query.OrderBy(q => q.Price);
                        break;
                    case "High":
                        Query = Query.OrderByDescending(q => q.Price);
                        break;

                }
            }

            if (!string.IsNullOrEmpty(Stock)&&Stock!="All")
            {
                switch (Stock)
                {
                
                     
                       
                    case "InStock":
                        Query = Query.Where(p => p.IsInStock == true);
                        break;
                    case "OutStock":
                        Query = Query.Where(p => p.IsInStock == false);
                        break;
                }
            }

            if (Category!=0)
            {
                Query = Query.Where(p => p.CategoryProductid == Category);
            }
            var skip = (pageID-1) * 10;
            Query = Query.Skip(skip).Take(10).Include(p => p.CategoryProduct).Include(p=>p.SubProducts);
            var res = Query.ToList();
            return res;
        }

        public Product getProductbyID(int productID)
        {
            return _context.Products.Find(productID);
        }

        public int getProductsWithPageIDAndFilterCOUNT(int pageID, string Search, string Order, string Stock, int Category)
        {
            IQueryable<Product> Query = _context.Products;
            if (!string.IsNullOrEmpty(Search))
            {
                Query = Query.Where(p => p.ProductName.Contains(Search));
            }

            if (!string.IsNullOrEmpty(Order) && Order != "Date")
            {
                switch (Order)
                {
                    case "Date":
                        Query = Query.OrderBy(q => q.CreateDate);
                        break;

                    case "Date-Desc":
                        Query = Query.OrderByDescending(q => q.CreateDate);
                        break;
                    case "SellCount":
                        Query = Query.OrderBy(q => q.SellCount);
                        break;
                    case "Desc":
                        Query = Query.OrderBy(q => q.ProductName);
                        break;
                    case "Asc":
                        Query = Query.OrderByDescending(q => q.ProductName);
                        break;

                }
            }

            if (!string.IsNullOrEmpty(Stock) && Stock != "All")
            {
                switch (Stock)
                {



                    case "InStock":
                        Query = Query.Where(p => p.IsInStock == true);
                        break;
                    case "OutStock":
                        Query = Query.Where(p => p.IsInStock == false);
                        break;
                }
            }

            if (Category != 0)
            {
                Query = Query.Where(p => p.CategoryProductid == Category);
            }
           
            var res = Query.Where(p=>p.IsDeleted!=true).ToList().Count;
            return res;
        }

        public List<Product> GetProducts()
        {
            return _context.Products.Include(p=>p.CategoryProduct).ToList();
        }

        public bool Create(CreateProductDTO createProductDto)
        {

            var finalname = "";
            if (createProductDto.MainProductImage != null)
            {
                var filename = Path.GetFileName(createProductDto.MainProductImage.FileName);
                var FileExtension = Path.GetExtension(filename);
                var uniqfilename = Guid.NewGuid().ToString();
                finalname = uniqfilename + FileExtension;
                var currentdirctory = hostingEnvironment.WebRootPath;
                if (!Directory.Exists(Path.Combine(currentdirctory, "MainProductImages")))
                {
                    Directory.CreateDirectory(Path.Combine(currentdirctory, "MainProductImages"));
                }

                var finalpath = Path.Combine(currentdirctory, "MainProductImages", finalname);
                FileStream fileStream = new FileStream(finalpath, FileMode.Create);
                createProductDto.MainProductImage.CopyTo(fileStream);

                Product product = new Product()
                {
                    CategoryProductid = createProductDto.CategoryProductid,
                    CreateDate = DateTime.Now,
                    IsDeleted = false,
                    IsInStock = createProductDto.IsInStock,
                    ProductDescription = createProductDto.ProductDescription,
                    ProductName = createProductDto.ProductName,
                    SellCount = 0,
                    ShortProductDescription = createProductDto.ShortProductDescription,
                    MainProductImage = finalname,
                    Price = createProductDto.Price
                    
                };
                _context.Products.Add(product);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Edit(ModifyProductDTO modifyProductDto,IFormFile file)
        {
           var product= getProductbyID(modifyProductDto.id);

           var finalname = product.MainProductImage;
           if (file != null)
           {

               var filename = Path.GetFileName(file.FileName);
               var FileExtension = Path.GetExtension(filename);
               var uniqfilename = Guid.NewGuid().ToString();
               finalname = uniqfilename + FileExtension;
               var currentdirctory = hostingEnvironment.WebRootPath;

               if (!Directory.Exists(Path.Combine(currentdirctory, "MainProductImages")))
               {
                   Directory.CreateDirectory(Path.Combine(currentdirctory, "MainProductImages"));
               }

               var finalpath = Path.Combine(currentdirctory, "MainProductImages", finalname);
               if (product.MainProductImage != null)
               {
                   var oldpath = Path.Combine(currentdirctory, "MainProductImages", product.MainProductImage);
                   File.Delete(oldpath);
               }

               FileStream fileStream = new FileStream(finalpath, FileMode.Create);
               file.CopyTo(fileStream);

           }
           product.IsInStock = modifyProductDto.IsInStock;
           product.ProductDescription = modifyProductDto.ProductDescription;
           product.ShortProductDescription=modifyProductDto.ShortProductDescription;
           product.ProductName=modifyProductDto.ProductName;
           product.CategoryProductid=modifyProductDto.CategoryProductid;
           product.MainProductImage = finalname;
           product.Price = modifyProductDto.Price;
           _context.SaveChanges();




        }

        public void Remove(int id)
        {
            var product = getProductbyID(id);
            product.IsDeleted = true;
            _context.SaveChanges();
        }
    }
}

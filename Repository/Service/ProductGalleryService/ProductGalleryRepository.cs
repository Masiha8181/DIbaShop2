using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Context;
using DataLayer.DTO.ProductGallery;
using DataLayer.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Repository.Interface.ProductGalleryInteface;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace Repository.Service.ProductGalleryService
{
    public class ProductGalleryRepository : IProductGalleryRepository
    {
        private readonly DibaContext _context;
        private readonly IHostingEnvironment _environment;

        public ProductGalleryRepository(DibaContext context, IHostingEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        public void Create(CreateProductGalleryDTO createProductGalleryDto)
        {
            var finalname = "";
            if (createProductGalleryDto.ImageAddress != null)
            {
                var filename = Path.GetFileName(createProductGalleryDto.ImageAddress.FileName);
                var FileExtension = Path.GetExtension(filename);
                var uniqfilename = Guid.NewGuid().ToString();
                finalname = uniqfilename + FileExtension;
                var currentdirctory = _environment.WebRootPath;
                if (!Directory.Exists(Path.Combine(currentdirctory, "ProductGallery")))
                {
                    Directory.CreateDirectory(Path.Combine(currentdirctory, "ProductGallery"));
                }

                var finalpath = Path.Combine(currentdirctory, "ProductGallery", finalname);
                FileStream fileStream = new FileStream(finalpath, FileMode.Create);
                createProductGalleryDto.ImageAddress.CopyTo(fileStream);
            }

            ProductImage productImage = new ProductImage()
            {
                Productid = createProductGalleryDto.Productid,
                ImageAddress = finalname
            };
            _context.ProductImages.Add(productImage);
            _context.SaveChanges();
        }

        public ProductImage getGalleryById(int id)
        {
            return _context.ProductImages.Find(id);
        }

        public List<ProductImage> GetList(int id)
        {
            return _context.ProductImages.Where(p => p.Productid == id).ToList();
        }

        public void Remove(int id)
        {
            var gallery = getGalleryById(id);
            var currentdirctory = _environment.WebRootPath;
           
         
            if (gallery.ImageAddress != null)
            {
                var oldpath = Path.Combine(currentdirctory, "ProductGallery", gallery.ImageAddress);
                File.Delete(oldpath);
            }

            _context.ProductImages.Remove(gallery);
            _context.SaveChanges();
        }
    }
}

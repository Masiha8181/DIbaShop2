using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Context;
using Microsoft.AspNetCore.Hosting;
using Repository.Interface.CategoryInteface;
using Repository.Interface.ColorInterface;
using Repository.Interface.IUnitOfWork;
using Repository.Interface.ProductFeature;
using Repository.Interface.ProductGalleryInteface;
using Repository.Interface.ProductInterface;
using Repository.Interface.SizeInterface;
using Repository.Interface.SliderInterface;
using Repository.Interface.SubProductInterface;
using Repository.Interface.UserInterface;
using Repository.Service.CategoryService;
using Repository.Service.ColorService;
using Repository.Service.ProductFeatureService;
using Repository.Service.ProductGalleryService;
using Repository.Service.ProductService;
using Repository.Service.SizeService;
using Repository.Service.SliderService;
using Repository.Service.SubProductService;
using Repository.Service.UserService;

namespace Repository.Service.UnitOfWorkService
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DibaContext _context;
        private readonly IHostingEnvironment _hostingEnvironment;
        public  ISubProductRepository SubProductRepository { get; set; }
        public IUserRepository UserRepository { get; set; }
        public ICategoryRepository CategoryRepository { get; set; }
        public IProductRepository ProductRepository { get; set; }
        public IProductFeatureRepository ProductFeatureRepository { get; set; }
        public IProductGalleryRepository ProductGalleryRepository { get; set; }
        public ISizeRepository SizeRepository { get; set; }
        public IColorRepository ColorRepository { get; set; }
        public ISliderRepository  SliderRepository { get; set; }

        public UnitOfWork(DibaContext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            UserRepository = new UserRepository(context);
            CategoryRepository = new CategoryRepository(context, hostingEnvironment);
            ProductRepository = new ProductRepository(context, hostingEnvironment);
            ProductFeatureRepository = new ProductFeatureRepository(context);
            ProductGalleryRepository = new ProductGalleryRepository(context,hostingEnvironment);
            SizeRepository = new SizeRepository(context);
            ColorRepository = new ColorRepository(context);
            SubProductRepository = new SubProductRepository(context);
            SliderRepository = new SliderRepository(context, hostingEnvironment);
        }
        public void Dispose()
        {
            _context.Dispose();
        }


    }
}

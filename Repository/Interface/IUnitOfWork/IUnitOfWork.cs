using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Interface.CategoryInteface;
using Repository.Interface.ColorInterface;
using Repository.Interface.ProductFeature;
using Repository.Interface.ProductGalleryInteface;
using Repository.Interface.ProductInterface;
using Repository.Interface.SizeInterface;
using Repository.Interface.SliderInterface;
using Repository.Interface.SubProductInterface;
using Repository.Interface.UserInterface;

namespace Repository.Interface.IUnitOfWork
{
    public interface IUnitOfWork:IDisposable
    {
        public IUserRepository UserRepository { get; }
        public ICategoryRepository CategoryRepository { get; set; }
        public IProductRepository ProductRepository { get; set; }
        public IProductFeatureRepository ProductFeatureRepository { get; set; }
        public IProductGalleryRepository ProductGalleryRepository { get; set; }
        public ISizeRepository SizeRepository { get; set; }
        public IColorRepository ColorRepository { get; set; }
        public ISubProductRepository SubProductRepository { get; set; }
        public ISliderRepository SliderRepository { get; set; }

    }
}

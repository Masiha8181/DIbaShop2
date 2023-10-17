using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Context;
using DataLayer.DTO.ProductFeature;
using DataLayer.Entities;
using Repository.Interface.ProductFeature;

namespace Repository.Service.ProductFeatureService
{
    public class ProductFeatureRepository:IProductFeatureRepository
    {
        private  readonly  DibaContext _context;

        public ProductFeatureRepository(DibaContext context)
        {
            _context = context;
        }
        public void Add(CreateProductFeatureDTO createProductFeatureDto)
        {
            var feature = new ProductInfo()
            {
                ProductInfoTitle = createProductFeatureDto.ProductInfoTitle,
                ProductInfoValue = createProductFeatureDto.ProductInfoValue,
                Productid = createProductFeatureDto.Productid
                
            };
            _context.ProductInfo.Add(feature);
            _context.SaveChanges();
        }

        public List<ProductInfo> getList(int id)
        {
            return _context.ProductInfo.Where(p=>p.Productid==id).ToList();
        }

        public void Edit(ModifyProductFeatureDTO modifyProductFeatureDto)
        {
            var feature = GetProductInfo(modifyProductFeatureDto.id);
                feature.ProductInfoTitle=modifyProductFeatureDto.ProductInfoTitle;
                feature.ProductInfoValue=modifyProductFeatureDto.ProductInfoValue;
                _context.SaveChanges();


        }

        public ProductInfo GetProductInfo(int id)
        {
            return _context.ProductInfo.Find(id);
        }

        public void Delete(int id)
        {
            var feature = GetProductInfo(id);
            _context.ProductInfo.Remove(feature);
            _context.SaveChanges();
        }
    }
}

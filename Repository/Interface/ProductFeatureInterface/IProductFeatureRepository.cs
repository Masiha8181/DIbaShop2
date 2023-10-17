using DataLayer.DTO.ProductFeature;
using DataLayer.Entities;

namespace Repository.Interface.ProductFeature;

public interface IProductFeatureRepository
{
    void Add(CreateProductFeatureDTO createProductFeatureDto);
    List<ProductInfo> getList(int id);
    void Edit(ModifyProductFeatureDTO modifyProductFeatureDto);
    ProductInfo GetProductInfo(int id);
    void Delete(int id);
}
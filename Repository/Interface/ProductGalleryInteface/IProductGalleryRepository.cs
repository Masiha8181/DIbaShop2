using DataLayer.DTO.ProductGallery;
using DataLayer.Entities;

namespace Repository.Interface.ProductGalleryInteface;

public interface IProductGalleryRepository
{
    void Create(CreateProductGalleryDTO createProductGalleryDto);
    ProductImage getGalleryById(int id);
    List<ProductImage> GetList(int id);
    void Remove(int id);
}
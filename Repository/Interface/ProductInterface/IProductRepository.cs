using DataLayer.DTO.Product;
using DataLayer.Entities;
using Microsoft.AspNetCore.Http;

namespace Repository.Interface.ProductInterface;

public interface IProductRepository
{
    Product getProductbyID(int productID);
    int getProductsWithPageIDAndFilterCOUNT(int pageID, string Search, string Order, string Stock, int category);
    List<Product> getProductsWithPageIDAndFilter(int pageID,string Search,string Order,string Stock,int category);
    List<Product> GetProducts();
    bool Create(CreateProductDTO createProductDto);
    void Edit(ModifyProductDTO modifyProductDto,IFormFile FIle);
    void Remove(int id);

}
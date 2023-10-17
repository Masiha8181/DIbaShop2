using DataLayer.DTO.SubProduct;
using DataLayer.Entities;

namespace Repository.Interface.SubProductInterface;

public interface ISubProductRepository
{
    void add(CreateSubProductDTO subProductDTO);
    void remove(int id);
    SubProduct getSubProduct (int id);
    List<SubProduct> getSubProducts();
    List<SubProduct> getProductsbyParentid(int id);
    void edit(EditSubProductDTO subProductDTO);
    void increaseCount(int id);
    void decreaseCount(int id);
    bool isExist(CreateSubProductDTO createSubProductDto);
    bool isExist(EditSubProductDTO editSubProductDto);
    Product GetProductWithSubProductID(int id);
}
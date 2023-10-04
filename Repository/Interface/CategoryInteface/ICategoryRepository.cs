using DataLayer.DTO.Category;
using DataLayer.Entities;
using Microsoft.AspNetCore.Http;

namespace Repository.Interface.CategoryInteface;

public interface ICategoryRepository
{
    void Remove(int id);
    void Edit(ModifyCategoryProductDTO modifyCategoryProductDto,IFormFile file);
    CategoryProduct GetCategorybyID(int id);
    List<CategoryProduct> GetCategories();
    void CreateCategory(CreateCategoryProductDTO categoryProduct);
}
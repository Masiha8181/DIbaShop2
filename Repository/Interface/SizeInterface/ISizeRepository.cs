using DataLayer.DTO.Size;
using DataLayer.Entities;

namespace Repository.Interface.SizeInterface;

public interface ISizeRepository
{
    void Add(CreateSizeDto size);
    bool IsExist(CreateSizeDto size);
    List<Size> GetList();
    Size Get(int id);
    void Remove(int id);
}
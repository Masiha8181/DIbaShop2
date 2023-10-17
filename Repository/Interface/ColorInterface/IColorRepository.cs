using DataLayer.DTO.Color;
using DataLayer.Entities;

namespace Repository.Interface.ColorInterface;

public interface IColorRepository
{
    void add(CreateColorDTO createColorDto);
    void remove(int id);
    Color getColor(int id);
    List<Color> geColorslist();
    void Edit(EditColorDTO editColorDto);
    bool isExist(CreateColorDTO createColorDto);
    bool isExist(EditColorDTO editColorDto);
    EditColorDTO EditView(int id);
}
using DataLayer.DTO.Slider;
using DataLayer.Entities;
using Microsoft.AspNetCore.Http;

namespace Repository.Interface.SliderInterface;

public interface ISliderRepository
{
List<Slider> GetSliderList();
Slider GetSlider(int index);
void Add(CreateSliderDTO slider);
void Remove(int id);
void Update(EditSliderDTO editSliderDto , IFormFile file);
List<Slider> GetActiveSliders();
}
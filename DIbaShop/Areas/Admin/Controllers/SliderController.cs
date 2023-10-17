using AutoMapper;
using DataLayer.DTO.Slider;
using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Repository.Interface.IUnitOfWork;

namespace DIbaShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SliderController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            var res = _unitOfWork.SliderRepository.GetSliderList();
            return View(res);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create( CreateSliderDTO createSliderDto)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.SliderRepository.Add(createSliderDto);
              return  RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int id)
        {
            var slider = _unitOfWork.SliderRepository.GetSlider(id);
            var res = _mapper.Map<Slider, EditSliderDTO>(slider);
            return View(res);
        }
        [HttpPost]
        public IActionResult Edit(EditSliderDTO editSliderDto,IFormFile File)
        {
          
                _unitOfWork.SliderRepository.Update(editSliderDto,File);
                return RedirectToAction("Index");
             
       
        }

        public IActionResult Remove(int id)
        {
            _unitOfWork.SliderRepository.Remove(id);
            return Ok();
        }
    }
}

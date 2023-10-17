using DataLayer.DTO.Color;
using Microsoft.AspNetCore.Mvc;
using Repository.Interface.IUnitOfWork;

namespace DIbaShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ColorController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ColorController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var res = _unitOfWork.ColorRepository.geColorslist();
            return View(res);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateColorDTO createColorDto)
        {
            if (ModelState.IsValid)
            {
                var IsExist = _unitOfWork.ColorRepository.isExist(createColorDto);
                if (!IsExist)
                {
                    _unitOfWork.ColorRepository.add(createColorDto);
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("ColorValue","این رنگ از قبل ثبت شده است");
                }
            }
            return View();
        }

        public IActionResult Edit(int id)
        {

            return View(_unitOfWork.ColorRepository.EditView(id));
        }
        [HttpPost]
        public IActionResult Edit(EditColorDTO editColorDto)
        {
            if (ModelState.IsValid)
            {
                var IsExist = _unitOfWork.ColorRepository.isExist(editColorDto);
                if (!IsExist)
                {
                    _unitOfWork.ColorRepository.Edit(editColorDto);
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("ColorValue", "این رنگ از قبل ثبت شده است");
                }
            }

            return View(editColorDto);
        }

        public IActionResult Remove(int id)
        {
            _unitOfWork.ColorRepository.remove(id);
           return RedirectToAction("Index");
        }
    }
}

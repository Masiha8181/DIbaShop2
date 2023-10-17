using DataLayer.DTO.Size;
using Microsoft.AspNetCore.Mvc;
using Repository.Interface.IUnitOfWork;

namespace DIbaShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SizeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public SizeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var res = _unitOfWork.SizeRepository.GetList();
            return View(res);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateSizeDto createSizeDto)
        {
            if (ModelState.IsValid)
            {
                var IsntExist = _unitOfWork.SizeRepository.IsExist(createSizeDto);
                if (IsntExist)
                {
                    _unitOfWork.SizeRepository.Add(createSizeDto);
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("SizeValue","این سایز از قبل موجود است");
                }
             
                
            }
            return View();
        }

        public IActionResult Remove(int id)
        {
            _unitOfWork.SizeRepository.Remove(id);
            return RedirectToAction("Index");
        }

    }
}

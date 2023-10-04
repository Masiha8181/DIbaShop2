using AutoMapper;
using DataLayer.DTO.Category;
using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Repository.Interface.IUnitOfWork;

namespace DIbaShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            var category = _unitOfWork.CategoryRepository.GetCategories();
            
            return View(category);
        }

        public IActionResult Create()
        {
          var categoryList=  _unitOfWork.CategoryRepository.GetCategories();
          ViewBag.Category = categoryList;
            return View();
        }
        [HttpPost]

        public IActionResult Create(CreateCategoryProductDTO categoryProductDto)
        {

            var categoryList2 = _unitOfWork.CategoryRepository.GetCategories();

            if (ModelState.IsValid)
            {
            _unitOfWork.CategoryRepository.CreateCategory(categoryProductDto);
            return RedirectToAction("Index");
            }
            ViewBag.Category = categoryList2;
            return View();
        }

        public IActionResult Modify(int id)
        {
            var categoryList2 = _unitOfWork.CategoryRepository.GetCategories();
            ViewBag.Category = categoryList2;
            var cat = _unitOfWork.CategoryRepository.GetCategorybyID(id);
            var res = _mapper.Map<CategoryProduct, ModifyCategoryProductDTO>(cat);
            return View(res);
        }
        [HttpPost]
        public IActionResult Modify(ModifyCategoryProductDTO categoryProductDto,IFormFile file)
        {
            _unitOfWork.CategoryRepository.Edit(categoryProductDto,file);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Remove(int id)
        {
            _unitOfWork.CategoryRepository.Remove(id);
            return RedirectToAction("Index");
        }
    }
}

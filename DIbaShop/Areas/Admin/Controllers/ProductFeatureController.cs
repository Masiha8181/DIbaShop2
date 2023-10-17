using AutoMapper;
using DataLayer.DTO.ProductFeature;
using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Repository.Interface.IUnitOfWork;

namespace DIbaShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductFeatureController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductFeatureController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public IActionResult Index(int id)
        {
            ViewBag.Id = id;
            var product = _unitOfWork.ProductRepository.getProductbyID(id);
            ViewBag.Product = product;
            var res = _unitOfWork.ProductFeatureRepository.getList(id);
            return View(res);
        }

        public IActionResult Create(int id)
        {
            ViewBag.Id = id;
            var product = _unitOfWork.ProductRepository.getProductbyID(id);
            ViewBag.Product = product;
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateProductFeatureDTO createProductFeatureDto)
        {
            ViewBag.Id = createProductFeatureDto.Productid;
            var product = _unitOfWork.ProductRepository.getProductbyID(createProductFeatureDto.Productid);
            ViewBag.Product = product;
            if (ModelState.IsValid)
            {
                _unitOfWork.ProductFeatureRepository.Add(createProductFeatureDto);
                return RedirectToAction("Index",new {id=createProductFeatureDto.Productid});
            }

            return View();
        }

        public IActionResult Edit(int id)
        {
            var productfeature = _unitOfWork.ProductFeatureRepository.GetProductInfo(id);
            var res = _mapper.Map<ProductInfo, ModifyProductFeatureDTO>(productfeature);
            return View(res);
        }

        [HttpPost]
        public IActionResult Edit(ModifyProductFeatureDTO modifyProductFeatureDto)
        {
           
            if (ModelState.IsValid)
            {
                _unitOfWork.ProductFeatureRepository.Edit(modifyProductFeatureDto);
                return RedirectToAction("Index", new { id = modifyProductFeatureDto.Productid });

            }
            else
            {
                var productfeature = _unitOfWork.ProductFeatureRepository.GetProductInfo(modifyProductFeatureDto.id);
                var res = _mapper.Map<ProductInfo, ModifyProductFeatureDTO>(productfeature);
                return View(res);
            }

            return RedirectToAction("Index", new { id = modifyProductFeatureDto.Productid });
        }

        public IActionResult Remove(int id)
        {
            _unitOfWork.ProductFeatureRepository.Delete(id);
            return Ok();
        }
    }
}

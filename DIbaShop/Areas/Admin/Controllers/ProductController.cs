using AutoMapper;
using DataLayer.DTO.Product;
using Microsoft.AspNetCore.Mvc;
using Repository.Interface.IUnitOfWork;
using System.Drawing.Printing;
using DataLayer.Entities;

namespace DIbaShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IActionResult Index( int pageid=1,string Search="", string Order ="Date",string Stock="All",int Category=0)
        {
            var Categories = _unitOfWork.CategoryRepository.GetCategories();
            ViewBag.Category = Categories;
            ViewBag.Stock = Stock;
            ViewBag.Categoryselect= Category;
            ViewBag.Order= Order;
            ViewBag.Search= Search;
           

            var res = _unitOfWork.ProductRepository.getProductsWithPageIDAndFilter(pageid,Search,Order,Stock,Category);
            var countproducts = _unitOfWork.ProductRepository.getProductsWithPageIDAndFilterCOUNT(pageid, Search, Order, Stock, Category);
            ViewBag.pageid = pageid;
            ViewBag.maxpage = (int)Math.Ceiling(countproducts/ (double)10);
            return View(res);
        }


        public IActionResult Create()
        {
            ViewBag.Category = _unitOfWork.CategoryRepository.GetCategories();
            return View();
        }
        [HttpPost]
        public IActionResult Create( CreateProductDTO createProductDto)
        {
            ViewBag.Category = _unitOfWork.CategoryRepository.GetCategories();
            if (ModelState.IsValid)
            {
                var res = _unitOfWork.ProductRepository.Create(createProductDto);
                return RedirectToAction("Index");
            }
           
            return View();
        }
        [HttpGet]

        public IActionResult Edit(int id)
        {
            ViewBag.Category = _unitOfWork.CategoryRepository.GetCategories();
            var product = _unitOfWork.ProductRepository.getProductbyID(id);
            var res = _mapper.Map<Product, ModifyProductDTO>(product);
                return View(res);
        }
        [HttpPost]

        public IActionResult Edit( ModifyProductDTO modifyProductDto ,IFormFile File)
        {
            ViewBag.Category = _unitOfWork.CategoryRepository.GetCategories();
            _unitOfWork.ProductRepository.Edit(modifyProductDto,File);
            return RedirectToAction("Index");
        }

        public IActionResult Remove(int id)
        {
            _unitOfWork.ProductRepository.Remove(id);
            return Ok();
        }
    }
}

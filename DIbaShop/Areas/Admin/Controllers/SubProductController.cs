using AutoMapper;
using DataLayer.DTO.Product;
using DataLayer.DTO.ProductFeature;
using DataLayer.DTO.SubProduct;
using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Repository.Interface.IUnitOfWork;

namespace DIbaShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SubProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SubProductController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

       
        public IActionResult Index(int id)
        {
            ViewBag.Product = _unitOfWork.ProductRepository.getProductbyID(id);
            var list = _unitOfWork.SubProductRepository.getProductsbyParentid(id);
            var res = _mapper.Map<List<SubProduct>, List<ShowSubproductDTO>>(list);
            return View(res);
        }

        public IActionResult Create(int id)
        {
            ViewBag.Color = _unitOfWork.ColorRepository.geColorslist();
            ViewBag.Size = _unitOfWork.SizeRepository.GetList();
            ViewBag.Product = _unitOfWork.ProductRepository.getProductbyID(id);
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateSubProductDTO createSubProductDto  )
        {
            ViewBag.Color = _unitOfWork.ColorRepository.geColorslist();
            ViewBag.Size = _unitOfWork.SizeRepository.GetList();
            ViewBag.Product = _unitOfWork.ProductRepository.getProductbyID(createSubProductDto.Productid);
            if (ModelState.IsValid)
            {
                var isExist = _unitOfWork.SubProductRepository.isExist(createSubProductDto);
                if (isExist)
                {
                    _unitOfWork.SubProductRepository.add(createSubProductDto);
                    return RedirectToAction("Index", new { id = createSubProductDto.Productid });
                }
                else
                {
                    ModelState.AddModelError("Colorid","این مدل با چنین سایز و رنگی از قبل موجود است");
                }
            }
            return View();
        }

        public IActionResult Increase(int id)
        {
            var subpro = _unitOfWork.SubProductRepository.getSubProduct(id);
            if (subpro != null)
            {
                _unitOfWork.SubProductRepository.increaseCount(id);
            }

            return RedirectToAction("Index", new { id =subpro.Productid  });
        }
        public IActionResult decrease(int id)
        {
            var subpro = _unitOfWork.SubProductRepository.getSubProduct(id);
            if (subpro != null)
            {
                _unitOfWork.SubProductRepository.decreaseCount(id);
            }

            return RedirectToAction("Index", new { id = subpro.Productid });
        }

        public IActionResult Edit(int id)
        {

            ViewBag.Color = _unitOfWork.ColorRepository.geColorslist();
            ViewBag.Size = _unitOfWork.SizeRepository.GetList();
            ViewBag.Product = _unitOfWork.SubProductRepository.GetProductWithSubProductID(id);
            var pro = _unitOfWork.SubProductRepository.getSubProduct(id);
            var res = _mapper.Map<SubProduct, EditSubProductDTO>(pro);
            return View(res);
        }

        [HttpPost]
        public IActionResult Edit(EditSubProductDTO editSubProductDto)
        {

            ViewBag.Color = _unitOfWork.ColorRepository.geColorslist();
            ViewBag.Size = _unitOfWork.SizeRepository.GetList();
            ViewBag.Product = _unitOfWork.SubProductRepository.GetProductWithSubProductID(editSubProductDto.id);
            if (ModelState.IsValid)
            {
                var isExist = _unitOfWork.SubProductRepository.isExist(editSubProductDto);
                if (isExist)
                {
                    _unitOfWork.SubProductRepository.edit(editSubProductDto);
                    return RedirectToAction("Index", new { id = editSubProductDto.Productid });
                }
                else
                {
                    ModelState.AddModelError("Colorid", "این مدل با چنین سایز و رنگی از قبل موجود است");
                }
            }

            return View(editSubProductDto);
        }

        public IActionResult Remove(int id)
        {
            var subpro=_unitOfWork.SubProductRepository.getSubProduct(id);
            _unitOfWork.SubProductRepository.remove(id);
            return RedirectToAction("Index", new { id = subpro.Productid });
        }

        public IActionResult Discount(int id)
        {
            var subProduct = _unitOfWork.SubProductRepository.getSubProduct(id);
            CreateDiscountDTO createDiscountDto = new CreateDiscountDTO()
            {
                SubProduct = subProduct
            };
            return View(createDiscountDto);
        }

        [HttpPost]
        public IActionResult Discount(CreateDiscountDTO createDiscountDto, int hidden)

        {
            ModelState.Remove("SubProduct");
            var subproduc = _unitOfWork.SubProductRepository.getSubProduct(hidden);
            createDiscountDto.SubProduct = subproduc;
            if (ModelState.IsValid)
            {
                //TODO INSERT TO DB 
                return RedirectToAction("Index", new { id = subproduc.Productid });
            }
           
            
            return View(createDiscountDto);
        }
    }
}

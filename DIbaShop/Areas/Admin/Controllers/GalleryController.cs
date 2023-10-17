using AutoMapper;
using DataLayer.DTO.ProductGallery;
using Microsoft.AspNetCore.Mvc;
using Repository.Interface.IUnitOfWork;

namespace DIbaShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GalleryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GalleryController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public IActionResult Index(int id)
        {
            ViewBag.id = id;
            ViewBag.product = _unitOfWork.ProductRepository.getProductbyID(id);
            var res = _unitOfWork.ProductGalleryRepository.GetList(id);
            return View(res);
        }

        public IActionResult Create(int id)
        {
            ViewBag.id = id;
            ViewBag.product = _unitOfWork.ProductRepository.getProductbyID(id);
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateProductGalleryDTO createProductGalleryDto)
        {
            ViewBag.id = createProductGalleryDto.Productid;
            ViewBag.product = _unitOfWork.ProductRepository.getProductbyID(createProductGalleryDto.Productid);
            if (ModelState.IsValid)
            {
                _unitOfWork.ProductGalleryRepository.Create(createProductGalleryDto);
                return RedirectToAction("Index", new { id = createProductGalleryDto.Productid });
            }

            return View();
        }

        public IActionResult Remove(int id)
        {
            var gallery = _unitOfWork.ProductGalleryRepository.getGalleryById(id);
            var addres = gallery.Productid;
            _unitOfWork.ProductGalleryRepository.Remove(id);
            return RedirectToAction("Index", new { id = addres });
        }
    }
}

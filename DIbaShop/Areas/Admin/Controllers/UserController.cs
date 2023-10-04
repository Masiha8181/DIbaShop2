using AutoMapper;
using DataLayer.DTO.User;
using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Repository.Interface.IUnitOfWork;

namespace DIbaShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private  readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            var userlist = _unitOfWork.UserRepository.GetUsers();
            var res = _mapper.Map<List<User>, List<UserListDTO>>(userlist);
            return View(res);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateUserDTO createUserDto)
        {
            if (ModelState.IsValid)
            {
                if (!_unitOfWork.UserRepository.IsUserExistWithPhoneNumber(createUserDto.PhoneNumber))
                {
                    _unitOfWork.UserRepository.CreateUser(createUserDto);
                    return View();
                }
                else
                {
                    ModelState.AddModelError("PhoneNumber","کاربری با این شماره موبایل از قبل موجود است");
                }
                
              
            }
            return View();
        }

        public IActionResult Edit(int id)
        {
            var user = _unitOfWork.UserRepository.GetUserById(id);
            var res = _mapper.Map<User, EditUserDTO>(user);
            return View(res);
        }
        [HttpPost]
        public IActionResult Edit(EditUserDTO editUser)
        {
            if (ModelState.IsValid)
            {
                
                    _unitOfWork.UserRepository.EditUser(editUser);
                    return RedirectToAction("Index");
                
               
            }
            return View(editUser);
        }

        public IActionResult Remove(int id)
        {
           _unitOfWork.UserRepository.DeleteUser(id);
           return RedirectToAction("Index");

        }
    }
}

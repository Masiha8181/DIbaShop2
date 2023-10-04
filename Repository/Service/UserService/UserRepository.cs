using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCrypt.Net;
using DataLayer.Context;
using DataLayer.DTO.User;
using DataLayer.Entities;
using Repository.Interface.UserInterface;

namespace Repository.Service.UserService
{
    public class UserRepository : IUserRepository
    {
        private readonly DibaContext _context;

        public UserRepository(DibaContext context)
        {
            _context = context;
        }

        public bool IsUserExistWithPhoneNumber(string phoneNumber)
        {
            var Res = _context.Users.Any(p => p.PhoneNumber == phoneNumber);
            return Res;
        }

        public List<User> GetUsers()
        {
            return _context.Users.Where(p=>p.IsDeleted==false).ToList();
        }

        public void CreateUser(CreateUserDTO userDTO)
        {
            Random rand = new Random();

            string passwordHash = BCrypt.Net.BCrypt.HashPassword(userDTO.Password);
            User user = new User()
            {
                FirstName = userDTO.FirstName,
                LastName = userDTO.LastName,
                Email = userDTO.Email,
                Password = passwordHash,
                PhoneNumber = userDTO.PhoneNumber,
                IsAdmin = userDTO.IsAdmin,
                CreateDate = DateTime.Now,
                IsActived = false,
                IsDeleted = false,
                SMSCODE = rand.Next(0,9999),
                SecurityCode = Guid.NewGuid()

                
            };
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public User GetUserById(int id)
        {
            return _context.Users.Find(id);

        }

        public void EditUser(EditUserDTO userDto)
        {
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(userDto.Password);
            var user = GetUserById(userDto.Id);
          
            user.Password = passwordHash;
            user.FirstName = userDto.FirstName;
            user.LastName = userDto.LastName;
            user.Email = userDto.Email;
            user.IsAdmin = userDto.IsAdmin;
            user.IsActived = userDto.IsActive;
            _context.SaveChanges();

        }

        public void DeleteUser(int id)
        {
          var user=  GetUserById(id);
          user.IsDeleted = true;
          _context.SaveChanges();
        }
    }
}

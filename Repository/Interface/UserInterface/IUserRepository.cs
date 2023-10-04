using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.DTO.User;
using DataLayer.Entities;

namespace Repository.Interface.UserInterface
{
    public interface IUserRepository
    {
        bool IsUserExistWithPhoneNumber (string phoneNumber);
        List<User> GetUsers();
        void CreateUser(CreateUserDTO userDTO);
        User GetUserById (int id);

        void EditUser(EditUserDTO userDto);
        void DeleteUser(int id);


    }
}

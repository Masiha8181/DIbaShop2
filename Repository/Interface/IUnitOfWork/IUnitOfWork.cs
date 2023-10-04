using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Interface.CategoryInteface;
using Repository.Interface.UserInterface;

namespace Repository.Interface.IUnitOfWork
{
    public interface IUnitOfWork:IDisposable
    {
        public IUserRepository UserRepository { get; }
        public ICategoryRepository CategoryRepository { get; set; }

    }
}

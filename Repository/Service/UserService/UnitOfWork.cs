using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Context;
using Microsoft.AspNetCore.Hosting;
using Repository.Interface.CategoryInteface;
using Repository.Interface.IUnitOfWork;
using Repository.Interface.UserInterface;
using Repository.Service.CategoryService;

namespace Repository.Service.UserService
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly DibaContext _context;
        private readonly IHostingEnvironment _hostingEnvironment ;
        public IUserRepository UserRepository { get; set; }
        public ICategoryRepository CategoryRepository { get; set; }

        public UnitOfWork(DibaContext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            UserRepository = new UserRepository(context);
            CategoryRepository = new CategoryRepository(context,hostingEnvironment);
        }
        public void Dispose()
        {
          _context.Dispose();
        }

       
    }
}

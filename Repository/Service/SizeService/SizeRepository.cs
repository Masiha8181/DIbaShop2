using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Context;
using DataLayer.DTO.Size;
using DataLayer.Entities;
using Repository.Interface.SizeInterface;

namespace Repository.Service.SizeService
{
    public class SizeRepository:ISizeRepository
    {
        private readonly DibaContext _context;

        public SizeRepository(DibaContext context)
        {
            _context = context;
        }

        public void Add(CreateSizeDto createSizeDto)
        {
            Size size = new Size()
            {
                SizeValue = createSizeDto.SizeValue
            };
            _context.SizeProducts.Add(size);
            _context.SaveChanges();
        }

        public bool IsExist(CreateSizeDto size)
        {
            var isExist=_context.SizeProducts.Any(p=>p.SizeValue==size.SizeValue);
            if (!isExist)
            {
                return true;
            }

            return false;

        }

        public List<Size> GetList()
        {
            return _context.SizeProducts.ToList();
        }

        public Size Get(int id)
        {
            return _context.SizeProducts.Find(id);
        }

        public void Remove(int id)
        {
            var size = Get(id);
            _context.SizeProducts.Remove(size);
            _context.SaveChanges();
        }
    }
}

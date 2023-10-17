using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Context;
using DataLayer.DTO.SubProduct;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Interface.SubProductInterface;

namespace Repository.Service.SubProductService
{
    public class SubProductRepository:ISubProductRepository
    {
        private readonly DibaContext _context;

        public SubProductRepository(DibaContext context)
        {
            _context = context;
        }
        public void add(CreateSubProductDTO subProductDTO)
        {
            SubProduct product = new SubProduct()
            {
                ProductModelName = subProductDTO.ProductModelName,
                Count = subProductDTO.Count,
                CreateDate = DateTime.Now,
                Colorid = subProductDTO.Colorid,
                Sizeid = subProductDTO.Sizeid,
                IsDeleted = false,
                IsInStock = subProductDTO.IsInStock,
                Price = subProductDTO.Price,
                Productid = subProductDTO.Productid
            };
            _context.SubProducts.Add(product);
            _context.SaveChanges();
        }

        public void remove(int id)
        {
            var subpro = getSubProduct(id);
            subpro.IsDeleted = true;
            _context.SaveChanges();
        }

        public SubProduct getSubProduct(int id)
        {
            return _context.SubProducts.Find(id);
        }

        public List<SubProduct> getSubProducts()
        {
            throw new NotImplementedException();
        }

        public List<SubProduct> getProductsbyParentid(int id)
        {
         return _context.SubProducts.Where(p=>p.Productid==id&&p.IsDeleted!=true).Include(p=>p.Color).Include(s=>s.Size).ToList();
        }

        public void edit(EditSubProductDTO subProductDTO)
        {
            var subpro = getSubProduct(subProductDTO.id);
            subpro.Colorid=subProductDTO.Colorid;
            subpro.Sizeid=subProductDTO.Sizeid;
            subpro.Price=subProductDTO.Price;
            subpro.Count=subProductDTO.Count;
            subpro.IsInStock=subProductDTO.IsInStock;
            _context.SaveChanges();
        }

        public void increaseCount(int id)
        {
            var subpro = getSubProduct(id);
            subpro.Count++;
            _context.SaveChanges();
        }

        public void decreaseCount(int id)
        {
            var subpro = getSubProduct(id);
            if (subpro.Count>0)
            {
                subpro.Count--;
                _context.SaveChanges();
            }
         
        }

        public bool isExist(CreateSubProductDTO createSubProductDto)
        {
            var res = _context.SubProducts.Where(p=>p.Productid== createSubProductDto.Productid).Any(p =>
                p.Colorid == createSubProductDto.Colorid && p.Sizeid == createSubProductDto.Sizeid);
            if (!res)
            {
                return true;
            }

            return false;
        }

        public bool isExist(EditSubProductDTO editSubProductDto)
        {
            var res = _context.SubProducts.Where(p => p.Productid == editSubProductDto.Productid&&p.id!= editSubProductDto.id).Any(p =>
                p.Colorid == editSubProductDto.Colorid && p.Sizeid == editSubProductDto.Sizeid);
            if (!res)
            {
                return true;
            }

            return false;
        }

        public Product GetProductWithSubProductID(int id)
        {
            var subpro= getSubProduct(id);
            var pro = _context.Products.Find(subpro.Productid);
            return pro;
        }
    }
}

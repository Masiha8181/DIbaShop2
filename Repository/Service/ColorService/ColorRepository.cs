using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Context;
using DataLayer.DTO.Color;
using DataLayer.Entities;
using Repository.Interface.ColorInterface;

namespace Repository.Service.ColorService
{
    public class ColorRepository : IColorRepository
    {
        private readonly DibaContext _context;

        public ColorRepository(DibaContext context)
        {
            _context = context;
        }

        public void add(CreateColorDTO createColorDto)
        {
            Color color = new Color()
            {
                ColorCode = createColorDto.ColorCode,
                ColorValue = createColorDto.ColorValue
            };
            _context.ColorProducts.Add(color);
            _context.SaveChanges();
        }

        public void remove(int id)
        {
            var color = _context.ColorProducts.Find(id);
            _context.ColorProducts.Remove(color);
            _context.SaveChanges();

        }

        public Color getColor(int id)
        {
            return _context.ColorProducts.Find(id);
        }

        public List<Color> geColorslist()
        {
            return _context.ColorProducts.ToList();
        }

        public void Edit(EditColorDTO editColorDto)
        {
            var color = getColor(editColorDto.id);
            color.ColorCode= editColorDto.ColorCode;
            color.ColorValue= editColorDto.ColorValue;
            _context.SaveChanges();
        }

        public bool isExist(CreateColorDTO? createColorDto)
        {
            var res = _context.ColorProducts.Any(c =>
                c.ColorCode == createColorDto.ColorCode || c.ColorValue == createColorDto.ColorValue);
            return res;
        }
        public bool isExist(EditColorDTO? createColorDto )
        {
            var res = _context.ColorProducts.Any(c =>
                c.ColorCode == createColorDto.ColorCode || c.ColorValue == createColorDto.ColorValue);
            return res;
        }

        public EditColorDTO EditView(int id)
        {
            var color = getColor(id);
            EditColorDTO editColorDto = new EditColorDTO()
            {
                id = id,
                ColorCode = color.ColorCode,
                ColorValue = color.ColorValue,
            };
            return editColorDto;
        }
    }
}
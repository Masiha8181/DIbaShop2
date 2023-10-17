using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Context;
using DataLayer.DTO.Category;
using DataLayer.DTO.ProductGallery;
using DataLayer.DTO.Slider;
using DataLayer.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Repository.Interface.SliderInterface;

namespace Repository.Service.SliderService
{
    public class SliderRepository:ISliderRepository
    {
        private readonly DibaContext _context;
        private readonly IHostingEnvironment hostingEnvironment;

        public SliderRepository(DibaContext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            this.hostingEnvironment = hostingEnvironment;
        }
        public List<Slider> GetSliderList()
        {
            return _context.Slider.ToList();
        }


        public Slider GetSlider(int index)
        {
            var res = _context.Slider.Find(index);
            return res ;
        }

        public void Add(CreateSliderDTO createSliderDto)
        {
            var finalname = "";
            if (createSliderDto.SliderImageAddress != null)
            {
                var filename = Path.GetFileName(createSliderDto.SliderImageAddress.FileName);
                var FileExtension = Path.GetExtension(filename);
                var uniqfilename = Guid.NewGuid().ToString();
                finalname = uniqfilename + FileExtension;
                var currentdirctory = hostingEnvironment.WebRootPath;
                if (!Directory.Exists(Path.Combine(currentdirctory, "SliderImages")))
                {
                    Directory.CreateDirectory(Path.Combine(currentdirctory, "SliderImages"));
                }

                var finalpath = Path.Combine(currentdirctory, "SliderImages", finalname);
                FileStream fileStream = new FileStream(finalpath, FileMode.Create);
                createSliderDto.SliderImageAddress.CopyTo(fileStream);
                Slider slider = new Slider()
                {
                    IsActive = createSliderDto.IsActive,
                    PageAddress = createSliderDto.PageAddress,
                    SliderName = createSliderDto.SliderName,
                    SliderImageAddress = finalname
                };
                _context.Slider.Add(slider);
                _context.SaveChanges();
            }
        }

        public void Remove(int id)
        {
            var slider = GetSlider(id);
            var currentdirctory = hostingEnvironment.WebRootPath;
            var oldpath = Path.Combine(currentdirctory, "SliderImages", slider.SliderImageAddress);
            File.Delete(oldpath);
            _context.Slider.Remove(slider);
            _context.SaveChanges();
        }

      

        public void Update(EditSliderDTO editSliderDto, IFormFile file)
        {
            var slider = GetSlider(editSliderDto.id);

            var finalname = slider.SliderImageAddress;
            if (file != null)
            {

                var filename = Path.GetFileName(file.FileName);
                var FileExtension = Path.GetExtension(filename);
                var uniqfilename = Guid.NewGuid().ToString();
                finalname = uniqfilename + FileExtension;
                var currentdirctory = hostingEnvironment.WebRootPath;

                if (!Directory.Exists(Path.Combine(currentdirctory, "SliderImages")))
                {
                    Directory.CreateDirectory(Path.Combine(currentdirctory, "SliderImages"));
                }

                var finalpath = Path.Combine(currentdirctory, "SliderImages", finalname);
                if (slider.SliderImageAddress != null)
                {
                    var oldpath = Path.Combine(currentdirctory, "SliderImages", slider.SliderImageAddress);
                    File.Delete(oldpath);
                }
                FileStream fileStream = new FileStream(finalpath, FileMode.Create);
                file.CopyTo(fileStream);

               
            }
            slider.IsActive = editSliderDto.IsActive;
            slider.SliderImageAddress = finalname;
            slider.PageAddress = editSliderDto.PageAddress;
            slider.SliderName = editSliderDto.SliderName;
            _context.SaveChanges();
        }

        public List<Slider> GetActiveSliders()
        {
            return _context.Slider.Where(p => p.IsActive == true).ToList();
        }
    }
}

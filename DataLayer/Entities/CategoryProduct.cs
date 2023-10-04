using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class CategoryProduct
    {
        [Key] public int id { get; set; }
        [MaxLength(50)]
        [Required]
        public string categoryName { get; set; }
        public string? ImageAddress { get; set; }
        public bool? IsDeleted { get; set; }
        public int? Parentid { get; set; }
        [ForeignKey("Parentid")]

        public List<CategoryProduct> CategoryProducts { get; set; }
        public List<Product> Products { get; set; }



    }
}

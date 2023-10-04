using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class UserComment
    {
        [Key]
        [Required]
        public int id { get; set; }
        public int Userid { get; set; }
        public int Productid { get; set; }
   
        [Required]
        public string CommentText { get; set; }
        public int? Parentid { get; set; }
        [ForeignKey("Parentid")]
        public List<UserComment> Comments { get; set; }
        public UserComment Comment { get; set; }

    }
}

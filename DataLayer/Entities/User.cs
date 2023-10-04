using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }
        public string? Email { get; set; }
        [Required]
        [MaxLength(100)]
        public string Password { get; set; }
        [Required]
        [MaxLength(100)]
        public string PhoneNumber { get; set; }
        [Required]
        [MaxLength(100)]
        public int? SMSCODE { get; set; }
        [Required]
        [MaxLength(200)]
        public Guid? SecurityCode { get; set; }
        public DateTime CreateDate { get; set; }

        public bool? IsActived { get; set; }
        public bool? IsDeleted { get; set; }
        public bool? IsAdmin { get; set; }
        #region nav
        public List<UserComment> Comments { get; set; }
        public List<Order> Order { get; set; }
     
        public List<Address> Address { get; set; }
        #endregion




    }
}

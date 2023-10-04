using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DTO.User
{
    public class UserListDTO
    {

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

      
        
        public string PhoneNumber { get; set; }
       
        public DateTime CreateDate { get; set; }

        public bool? IsActived { get; set; }
       
      
    }
}

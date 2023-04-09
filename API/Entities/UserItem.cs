using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class UserItem
    {
        public UserItem()
        {
            IsActive = true;
        }
        public int Id { get; set; }
        public int IdPhotoFile {get; set; } 
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }

        [NotMapped]
        public string ConfirmPassword { get; set; }
    }
}

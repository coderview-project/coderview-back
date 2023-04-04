using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class UserData
    {
        public UserData() 
        {
            IsActive = true; 
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }

        [NotMapped]
        public string Password { get; set; }

    }
}


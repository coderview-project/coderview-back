
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class BootcampData
    {

        public BootcampData()
        

            {
            IsActive = true;
             }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }

    }
}
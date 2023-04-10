using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class BootcampItem
    {
        public BootcampItem() 
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

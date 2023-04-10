using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.ILogic
{
    public interface IBootcampLogic
    {
        int PostBootcamp(BootcampItem bootcampItem);
        void UpdateBootcamp(BootcampItem bootcampItem);
        void DeactivatedBootcamp(int id);
        List<BootcampItem> GetAllBootcamp();
    }
}

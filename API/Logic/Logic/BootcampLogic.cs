using Data;
using Entities;
using Logic.ILogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Logic
{
    public class BootcampLogic : IBootcampLogic
    {
        private readonly ServiceContext _serviceContext;
        public BootcampLogic(ServiceContext serviceContext)
        {
            _serviceContext = serviceContext;
        }

    public List<BootcampItem> GetAllBootcamp()
        {
            return _serviceContext.Set<BootcampItem>()
                .Where(u => u.IsActive == true)
                .ToList();
        }

    public int PostBootcamp(BootcampItem bootcampItem)
        {
            _serviceContext.Bootcamp.Add(bootcampItem);
            _serviceContext.SaveChanges();
            return bootcampItem.Id;
        }

       

        public void DeactivatedBootcamp(int id)
        {
            var bootcampToDeactivate = _serviceContext.Set<BootcampItem>()
            .Where(i => i.Id == id).First();

            bootcampToDeactivate.IsActive = false;

            _serviceContext.SaveChanges();
        }

        void IBootcampLogic.UpdateBootcamp(BootcampItem bootcampItem)
        {
            throw new NotImplementedException();
        }
    }


}

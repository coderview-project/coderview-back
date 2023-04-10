using API.IServices;
using Data;
using Entities;
using Logic.ILogic;

namespace API.Services
{
    public class BootcampService : IBootcampService
    {
        private readonly IBootcampLogic _bootcampLogic;
        private readonly ServiceContext _serviceContext;
        public BootcampService(ServiceContext serviceContext, IBootcampLogic bootcampLogic)
        {
            _bootcampLogic= bootcampLogic;
            _serviceContext= serviceContext;
        }

        void IBootcampService.DeactivatedBootcamp(int id)
        {
            _bootcampLogic.DeactivatedBootcamp(id);
        }

        List<BootcampItem> IBootcampService.GetAllBootcamp()
        {
            return _bootcampLogic.GetAllBootcamp();
        }

        int IBootcampService.PostBootcamp(BootcampItem bootcampItem)
        {
            _serviceContext.Bootcamp.Add(bootcampItem);
            _serviceContext.SaveChanges();
            return bootcampItem.Id;
        }

        void IBootcampService.UpdateBootcamp(BootcampItem bootcampItem)
        {
              _bootcampLogic.UpdateBootcamp(bootcampItem);
        }
    }
}

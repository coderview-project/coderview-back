using Entities;

namespace API.IServices
{
    public interface IBootcampService
    {
        int PostBootcamp(BootcampItem bootcampItem);

        void UpdateBootcamp(BootcampItem bootcampItem);
        void DeactivatedBootcamp(int id);
        List<BootcampItem> GetAllBootcamp();
    }
}

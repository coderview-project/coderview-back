using Entities;

namespace API.IServices
{
    public interface IUserService
    {
            int PostUser(UserItem userItem);
            void UpdateUser(UserItem userItem);
            void DeactivateUser(int id);
            List<UserItem> GetAllUsers();  
    }
}

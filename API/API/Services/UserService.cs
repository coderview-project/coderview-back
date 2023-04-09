using API.IServices;
using Data;
using Entities;
using Logic.ILogic;

namespace API.Services
{
    public class UserService : IUserService
    {
        private readonly IUserLogic _userLogic;
        private readonly ServiceContext _serviceContext;
        public UserService(ServiceContext serviceContext, IUserLogic userLogic)
        {
            _userLogic = userLogic;
            _serviceContext = serviceContext;
            
        }

        public List<UserItem> GetAllUsers()
        {
            return _userLogic.GetAllUsers();
        }

        int IUserService.PostUser(UserItem userItem)
        {
            _userLogic.PostUser(userItem);
            return userItem.Id;
        }

        public void UpdateUser(UserItem userItem)
        {
            _userLogic.UpdateUser(userItem);
        }

        void IUserService.DeactivateUser(int id)
        {
            _userLogic.DeactivateUser(id);
        }
    }
}


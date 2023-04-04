
using API.IServices;
using API.Models;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class UserController : ControllerBase
    {
        
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost(Name = "PostUser")]
        public int PostUser([FromBody] NewUserRequestModel newUserRequestModel)
        {

            var userItem = new UserItem();
            userItem.Name = newUserRequestModel.UserData.Name;
            userItem.Email = newUserRequestModel.UserData.Email;
            userItem.Password = newUserRequestModel.UserData.Password;
            userItem.IsActive = newUserRequestModel.UserData.IsActive;
            return _userService.PostUser(userItem);
        }

        [HttpGet(Name = "GetAllUsers")]
        public List<UserItem> GetAllUsers()
        {
            return _userService.GetAllUsers();
        }

        [HttpPatch(Name = "ModifyUser")]
        public void Patch([FromBody] UserItem userItem)
        {
            _userService.UpdateUser(userItem);
        }

        [HttpDelete(Name = "DeactivateUser")]
        public void DeactivateUser([FromQuery] int id)
        {
            _userService.DeactivateUser(id);
        }


    }
}
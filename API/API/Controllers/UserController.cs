
using API.IServices;
using API.Models;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class UserController : ControllerBase
    {
        
        private readonly IUserService _userService;
        private readonly IFileService _fileService;
        public UserController(IUserService userService, IFileService fileService)
        {
            _userService = userService;
            _fileService = fileService; 
        }

        [HttpPost(Name = "PostUser")]
        public int PostUser([FromBody] NewUserRequestModel newUserRequestModel)
        {

            var userItem = new UserItem();
            userItem.Name = newUserRequestModel.UserData.Name;
            userItem.LastName = newUserRequestModel.UserData.LastName;
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
        public void Patch([FromBody] PatchUserRequestModel patchUserRequestModel)
        {
            try
            {
                var fileItem = new FileItem();

                fileItem.Id = 0;
                fileItem.Name = patchUserRequestModel.FileData.FileName;
                fileItem.InsertDate = DateTime.Now;
                fileItem.UpdateDate = DateTime.Now;
                fileItem.Content = Convert.FromBase64String(patchUserRequestModel.FileData.Base64FileContent);

                var fileId = _fileService.PostFile(fileItem);

                var userItem = new UserItem();
                userItem.Name = patchUserRequestModel.UserData.Name;
                userItem.LastName = patchUserRequestModel.UserData.LastName;
                userItem.Email = patchUserRequestModel.UserData.Email;
                userItem.Password = patchUserRequestModel.UserData.Password;
                userItem.IsActive = patchUserRequestModel.UserData.IsActive;
                userItem.IdPhotoFile = fileId;
                _userService.UpdateUser(userItem);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpDelete(Name = "DeactivateUser")]
        public void DeactivateUser([FromQuery] int id)
        {
            _userService.DeactivateUser(id);
        }


    }
}
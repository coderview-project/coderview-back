
using API.IServices;
using API.Models;
using Data;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

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
        public int PostUser(UserItem userItem)
        {
           
            if(userItem.Password == userItem.ConfirmPassword)
            {
                userItem.Password = ConvertToSha256(userItem.Password);
                userItem.ConfirmPassword = ConvertToSha256(userItem.ConfirmPassword);
            }
            return _userService.PostUser(userItem);
        }

        public static string ConvertToSha256(string text)
        {
            StringBuilder Sb = new StringBuilder();
            using (SHA256 hash = SHA256Managed.Create())
            {
                Encoding enc = Encoding.UTF8;
                byte[] result = hash.ComputeHash(enc.GetBytes(text));
                foreach (byte b in result)
                {
                    Sb.Append(b.ToString("x2"));
                }
                return Sb.ToString();
            }
        }

        [HttpPost(Name = "Login")]
        public ActionResult Login(UserItem userItem)
        {
            userItem.Password = ConvertToSha256(userItem.Password);
            

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
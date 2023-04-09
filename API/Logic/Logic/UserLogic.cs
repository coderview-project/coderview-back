using Data;
using Entities;
using Logic.ILogic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Logic
{
    public class UserLogic : IUserLogic
    {
        private readonly ServiceContext _serviceContext;
        
        public UserLogic(ServiceContext serviceContext)
        {
            _serviceContext = serviceContext;
            
        }

        public List<UserItem> GetAllUsers()
        {
            return _serviceContext.Set<UserItem>()
                .Where(u => u.IsActive == true)
                .ToList();
        }

        public int PostUser(UserItem userItem)
        {
              
            if (!_serviceContext.Users.Any(u => u.Email == u.Email))
            {
                _serviceContext.Users.Add(userItem);
                _serviceContext.SaveChanges();
            }
            return userItem.Id;
        }
        
        public void UpdateUser(UserItem userItem)
        {
            throw new NotImplementedException();
        }
        public void DeactivateUser(int id)
        {
            var userToDeactivate = _serviceContext.Set<UserItem>()
           .Where(i => i.Id == id).First();

            userToDeactivate.IsActive = false;

            _serviceContext.SaveChanges();
        }
    }
}


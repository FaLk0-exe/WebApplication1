using System;
using System.Collections.Generic;
using Pharm.DLL.Interfaces;
using Pharm.DAL.entity;

namespace Pharm.DLL.Services
{
    public class UserService
    {
        private IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void UserValidate(User user)
        {
            if (user is null)
            {
                throw new ArgumentNullException(nameof(user), "User cannot be null");
            }

            var currentDate = DateTime.Now;
            var age = currentDate.Year - user.BirthDate.Year;
            if (user.BirthDate > currentDate.AddYears(-age))
            {
                age--;
            }
            if (age < 18)
            {
                throw new ArgumentException("User must be at least 18 years old", nameof(user.BirthDate));
            }

          /*  if (_userRepository.GetUserByName(user.Name) != null)
            {
                throw new ArgumentException("User with this name already exists", nameof(user.Name));
            }*/

            if (user.Password.Length < 8 || user.Password.Length > 20)
            {
                throw new ArgumentException("Password must be between 8 and 20 characters long", nameof(user.Password));
            }
        }

        public void CreateUser(User user)
        {
            try
            {
                UserValidate(user);
            }
            catch
            {
                throw;
            }

            _userRepository.CreateUser(user);
        }

        public void UpdateUser(User user)
        {
            try
            {
                UserValidate(user);
            }
            catch
            {
                throw;
            }

            _userRepository.UpdateUser(user);
        }

        public void DeleteUser(long id)
        {
            _userRepository.DeleteUser(id);
        }
    }
}

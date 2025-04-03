using AutoMapper;
using DAL.Models;
using DAL.Repositories;
using Service.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDto> GetUserByUsernameAsync(string username)
        {
            var user = await _userRepository.GetUserByUsernameAsync(username);
            return _mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> RegisterUserAsync(string username, string email, string password)
        {
            // Hash the password (example using BCrypt)
            var passwordHash = BCrypt.Net.BCrypt.HashPassword(password);

            var user = new User
            {
                Username = username,
                Email = email,
                PasswordHash = passwordHash
            };

            var createdUser = await _userRepository.RegisterUserAsync(user);
            return _mapper.Map<UserDto>(createdUser);
        }

        public bool VerifyPassword(UserDto user, string password)
        {
            return BCrypt.Net.BCrypt.Verify(password, user.PasswordHash);
        }
    }

}

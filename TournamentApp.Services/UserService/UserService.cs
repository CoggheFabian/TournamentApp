using System;
using System.Linq;
using TournamentApp.Model;
using TournamentApp.Repositories.Implementation;
using TournamentApp.Repositories.Interfaces;
using TournamentApp.Services.Dtos;
using TournamentApp.Services.Token;

namespace TournamentApp.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public CreatedUserDto Register(UserRegisterDto userRegisterDto)
        {
            var user = _userRepository.Add(new User()
            {
                Name = userRegisterDto.Username,
                Password = BCrypt.Net.BCrypt.HashPassword(userRegisterDto.Password),
                Email = userRegisterDto.Email
            }).First().Entity;

            _userRepository.Save();

            return new CreatedUserDto()
            {
                Email = userRegisterDto.Email,
                Token = TokenService.CreateToken(user),
                Username = userRegisterDto.Username,
                UserId = user.Id,
            };
        }

        public bool GetUserByEmail(string email)
        {
            var count = _userRepository.GetUsersByEmail(email).Count();
            return count >= 0;
        }

        public void Login()
        {
            throw new System.NotImplementedException();
        }
    }

}
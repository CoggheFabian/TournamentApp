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
                Password = userRegisterDto.Password, //Todo encrypt this
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

        public void Login()
        {
            throw new System.NotImplementedException();
        }
    }

}
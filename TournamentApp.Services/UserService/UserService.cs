using System;
using System.Linq;
using TournamentApp.Model;
using TournamentApp.Repositories.Implementation;
using TournamentApp.Services.Dtos;
using TournamentApp.Services.Token;

namespace TournamentApp.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly UserRepository _userRepository;
        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Object Register(UserRegisterDto userRegisterDto)
        {
            var user = _userRepository.Add(new User()
            {
                Name = userRegisterDto.Username,
                Password = userRegisterDto.Password, //Todo encrypt this
                Email = userRegisterDto.Email
            }).First().Entity;

            _userRepository.Save();
            user.Password = "";

            return new
            {
                user = user,
                token = TokenService.CreateToken(user)
            };

        }

        public void Login()
        {
            throw new System.NotImplementedException();
        }
    }

}
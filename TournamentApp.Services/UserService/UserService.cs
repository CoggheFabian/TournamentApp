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

            //Todo make this a CreatedUserDto or somthing instead of a object type
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
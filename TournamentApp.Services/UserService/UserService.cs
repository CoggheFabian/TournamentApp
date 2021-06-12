using System;
using System.Linq;
using TournamentApp.Model;
using TournamentApp.Repositories.Interfaces;
using TournamentApp.Services.Token;
using TournamentApp.Shared.Dtos;

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
            }).First();

            _userRepository.Save();

            return new CreatedUserDto()
            {
                Email = userRegisterDto.Email,
                Token = TokenService.CreateToken(user),
                Username = userRegisterDto.Username,
                UserId = user.Id,
            };
        }

        public bool CheckIfEmailIsAlreadyRegistered(string email)
        {
            var count = _userRepository.GetUsersByEmail(email).Count();
            return count == 0;
        }

        public GetUserDto GetUserByEmail(string email)
        {
            var userFromRepo = _userRepository.GetUsersByEmail(email).First();
            if (userFromRepo != null)
            {
                return new GetUserDto
                {
                    Email = email,
                    Username = userFromRepo.Name
                };
            }
            return null;

        }


        public LoggedInUserDto Login(UserLoginDto userLoginDto)
        {
            User user;
            try { user = _userRepository.GetUsersByEmail(userLoginDto.Email).First(); }
            catch (InvalidOperationException e) { return null; }

            var res = BCrypt.Net.BCrypt.Verify(userLoginDto.Password, user.Password);
            if (BCrypt.Net.BCrypt.Verify(userLoginDto.Password, user.Password)) //Need to check on this
            {
                return new LoggedInUserDto {Email = user.Email, Token = TokenService.CreateToken(user), Username = user.Name};
            }

            return null;
        }

        public User FindUserById(int id)
        {
            return _userRepository.Get(id).First();
        }
    }

}
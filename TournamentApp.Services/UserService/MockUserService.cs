using System;
using System.Linq;
using TournamentApp.Model;
using TournamentApp.Repositories.Implementation.UserRepo;
using TournamentApp.Services.Dtos;
using TournamentApp.Services.Token;

namespace TournamentApp.Services.UserService
{
    public class MockUserService : IUserService
    {
        private readonly MockUserRepository _mockUserRepository;

        public MockUserService(MockUserRepository mockUserRepository)
        {
            _mockUserRepository = mockUserRepository;
        }

        public CreatedUserDto Register(UserRegisterDto userRegisterDto)
        {
            var user = _mockUserRepository.Add(new User()
            {
                Name = userRegisterDto.Username,
                Password = BCrypt.Net.BCrypt.HashPassword(userRegisterDto.Password),
                Email = userRegisterDto.Email
            }).First().Entity;

            _mockUserRepository.Save();

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
            var count = _mockUserRepository.GetUsersByEmail(email).Count();
            return count >= 0;
        }

        public GetUserDto GetUsersByEmail(string email)
        {
            var userFromRepo = _mockUserRepository.GetUsersByEmail(email).First();
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
            try { user = _mockUserRepository.GetUsersByEmail(userLoginDto.Email).First(); }
            catch (InvalidOperationException e) { return null; }

            var res = BCrypt.Net.BCrypt.Verify(userLoginDto.Password, user.Password);
            if (BCrypt.Net.BCrypt.Verify(userLoginDto.Password, user.Password)) //Need to check on this
            {
                return new LoggedInUserDto {Email = user.Email, Token = TokenService.CreateToken(user), Username = user.Name};
            }

            return null;
        }
    }
}
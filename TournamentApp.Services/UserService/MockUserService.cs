using System;
using System.Collections.Generic;
using System.Linq;
using TournamentApp.Model;
using TournamentApp.Repositories.Implementation.UserRepo;
using TournamentApp.Services.Token;
using TournamentApp.Shared.Dtos;

namespace TournamentApp.Services.UserService
{
    public class MockUserService : IUserService
    {
        private readonly MockUserRepository _mockUserRepository;

        public MockUserService()
        {
            _mockUserRepository = new MockUserRepository();
        }

        public CreatedUserDto Register(UserRegisterDto userRegisterDto)
        {
            var user = _mockUserRepository.Add(new User()
            {
                Name = userRegisterDto.Username.ToLower(),
                Password = BCrypt.Net.BCrypt.HashPassword(userRegisterDto.Password),
                Email = userRegisterDto.Email.ToLower()
            }).First();

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
            return count == 0;
        }

        public GetUserDto GetUserByEmail(string email)
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
            try
            {
                user = _mockUserRepository.GetUsersByEmail(userLoginDto.Email).First();
            }
            catch (InvalidOperationException e)
            {
                return null;
            }

            if (BCrypt.Net.BCrypt.Verify(userLoginDto.Password, user.Password)) //Need to check on this
            {
                return new LoggedInUserDto
                    {Email = user.Email, Token = TokenService.CreateToken(user), Username = user.Name};
            }

            return null;
        }

        public User FindUserById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PlayerInTournamentDto> GetPlayersForTournament(List<PlayerInTournamentDto> playerInTournamentDtos)
        {
            var playerIds = GetPlayersIdsFromDto(playerInTournamentDtos);
            var players = _mockUserRepository.GetPlayersForTournament(playerIds).ToList();
            foreach (var player in players) { yield return new PlayerInTournamentDto {Id = player.Id, UserName = player.Name}; }
        }

        private List<int> GetPlayersIdsFromDto(List<PlayerInTournamentDto> playerInTournamentDtos)
        {
            return playerInTournamentDtos.Select(s => s.Id).ToList();
        }

        public List<User> GetUsers()
        {
            return _mockUserRepository.GetAll().ToList();
        }
    }
}
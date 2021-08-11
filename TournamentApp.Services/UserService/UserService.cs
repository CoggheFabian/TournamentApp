using System;
using System.Collections.Generic;
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
            var user = _userRepository.Add(new User {Name = userRegisterDto.Username.ToLower(), Password = BCrypt.Net.BCrypt.HashPassword(userRegisterDto.Password), Email = userRegisterDto.Email.ToLower()})
                .First();
            _userRepository.Save();
            return new CreatedUserDto {Email = userRegisterDto.Email, Token = TokenService.CreateToken(user), Username = userRegisterDto.Username, UserId = user.Id,};
        }

        public bool CheckIfEmailIsAlreadyRegistered(string email)
        {
            var count = _userRepository.GetUsersByEmail(email).Count();
            return count == 0;
        }

        public GetUserDto GetUserByEmail(string email)
        {
            var userFromRepo = _userRepository.GetUsersByEmail(email).First();
            return userFromRepo != null ? new GetUserDto {Email = email, Username = userFromRepo.Name, Id = userFromRepo.Id} : null;
        }


        public LoggedInUserDto Login(UserLoginDto userLoginDto)
        {
            User user;
            try { user = _userRepository.GetUsersByEmail(userLoginDto.Email).First(); }
            catch (InvalidOperationException e) { return null; }
            return BCrypt.Net.BCrypt.Verify(userLoginDto.Password, user.Password) ? new LoggedInUserDto {Email = user.Email, Token = TokenService.CreateToken(user), Username = user.Name} : null;
        }

        public GetUserDto FindUserById(int id)
        {
            var user = _userRepository.Get(id).First();
            return new GetUserDto {Email = user.Email, Id = user.Id, Username = user.Name};
        }

        public IEnumerable<PlayerInQuizDto> GetPlayersForQuiz(List<PlayerInQuizDto> playerInTournamentDtos)
        {
            var playerIds = GetPlayersIdsFromDto(playerInTournamentDtos);
            var players = _userRepository.GetPlayersForQuiz(playerIds).ToList();
            foreach (var player in players) { yield return new PlayerInQuizDto {Id = player.Id, UserName = player.Name}; }
        }

        public List<GetUserDto> GetAllUsers()
        {
            var users = _userRepository.GetAll();
            var usersDto = new List<GetUserDto>();
            foreach (var user in users) { usersDto.Add(new GetUserDto {Email = user.Email, Id = user.Id, Username = user.Name}); }
            return usersDto;
        }

        public Dictionary<string, int> GetLeaderBord()
        {
            return _userRepository.GetLeaderBord().ToDictionary(leaderboard => leaderboard.Name, leaderboard => leaderboard.Score );
        }


        private List<int> GetPlayersIdsFromDto(List<PlayerInQuizDto> playerInTournamentDtos)
        {
            return playerInTournamentDtos.Select(s => s.Id).ToList();
        }


    }

}
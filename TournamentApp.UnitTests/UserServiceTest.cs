using System;
using System.Linq;
using TournamentApp.Repositories.Implementation.UserRepo;
using TournamentApp.Services.Dtos;
using TournamentApp.Services.UserService;
using Xunit;

namespace TournamentApp.UnitTests
{
    public class UserServiceTest
    {
        private MockUserService _mockUserService;


        [Fact]
        public void TestRegisterUserAdded()
        {
            _mockUserService =  new MockUserService();
            var usersBeforeAdd = _mockUserService.GetUsers();
            _mockUserService.Register(new UserRegisterDto()
            {
                Email = "test@test.com",
                Password = "Password",
                Username = "Username"
            });

            var usersAfterAdded = _mockUserService.GetUsers();
            Assert.True(usersBeforeAdd.Count +1 == usersAfterAdded.Count);
        }

        [Fact]
        public void TestIfEmailIsAlreadyRegisteredNoDuplicatedTrue()
        {
            _mockUserService =  new MockUserService();
            _mockUserService.Register(new UserRegisterDto()
            {
                Email = "test@test.com",
                Password = "Password",
                Username = "Username"
            });

           var checkIfEmailIsAlreadyRegistred = _mockUserService.CheckIfEmailIsAlreadyRegistered("test@test.com");
            Assert.False(checkIfEmailIsAlreadyRegistred);
        }


        [Fact]
        public void TestIfEmailIsAlreadyRegisteredNoDuplicatedFalse()
        {
            _mockUserService =  new MockUserService();

            _mockUserService.Register(new UserRegisterDto()
            {
                Email = "test456@test.com",
                Password = "Password",
                Username = "Username"
            });

            _mockUserService.Register(new UserRegisterDto()
            {
                Email = "test456456@test.com",
                Password = "Password",
                Username = "Username"
            });

            var checkIfEmailIsAlreadyRegistred = _mockUserService.CheckIfEmailIsAlreadyRegistered("test@test.com");
            Assert.True(checkIfEmailIsAlreadyRegistred);
        }

        [Fact]
        public void TestLoginWithNotExistingEmail()
        {
            _mockUserService =  new MockUserService();

           var loggedInUserNull =  _mockUserService.Login(new UserLoginDto
            {
                Email = "NonExistingEmail@NonExisting.com",
                Password = "lksdjflks"
            });

            Assert.Null(loggedInUserNull);
        }



    }
}
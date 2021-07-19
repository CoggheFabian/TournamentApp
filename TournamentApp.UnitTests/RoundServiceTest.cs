using System;
using TournamentApp.Services.RoundService;
using TournamentApp.Services.TournamentService;
using TournamentApp.Services.UserService;
using TournamentApp.Shared.Dtos;
using Xunit;

namespace TournamentApp.UnitTests
{
    public class RoundServiceTest
    {
        private MockRoundService _mockRoundService;

        [Fact]
        public void TestGetTournamentWithSubRoundsWithExistingTournamentId()
        {
            _mockRoundService =  new MockRoundService();
            var usersBeforeAdd = _mockRoundService.GetAllRoundFromATournament(1);
            Assert.True(usersBeforeAdd.Count > 0);
        }

        [Fact]
        public void TestGetTournamentWithSubRoundsWithNonExistingTournamentId()
        {
            _mockRoundService =  new MockRoundService();
            var usersBeforeAdd = _mockRoundService.GetAllRoundFromATournament(5);
            Assert.True(usersBeforeAdd.Count == 0);
        }

        [Fact]
        public void TestGetTournamentWithSubRoundsWithNotPossibleTournamentId()
        {
            _mockRoundService =  new MockRoundService();
            var usersBeforeAdd = _mockRoundService.GetAllRoundFromATournament(-900);
            Assert.True(usersBeforeAdd.Count == 0);
        }
    }
}
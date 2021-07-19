using System;
using System.Collections.Generic;
using System.Linq;
using TournamentApp.Services.TournamentRoundService;
using TournamentApp.Shared.Dtos;
using Xunit;

namespace TournamentApp.UnitTests
{
    public class TournamentRoundServiceTest
    {
        private ITournamentRoundService _tournamentRoundService;

        [Fact]
        public void TestAddedTournamentWithEverthingGood()
        {
            _tournamentRoundService = new MockTournamentRoundService();

            CreatedTournamentDto createdTournament =  _tournamentRoundService.CreateTournamentWithMainRounds(new CreateQuizDto
            {
                Name = "Boe",
                Players = new List<PlayerInQuizDto>
                {
                    new PlayerInQuizDto
                    {
                        Id = 1,
                        UserName = "fabian"
                    },
                    new PlayerInQuizDto
                    {
                        Id = 2,
                        UserName = "thijs"
                    },
                    new PlayerInQuizDto
                    {
                        Id = 3,
                        UserName = "pauline"
                    }
                },
                TournamentDate = DateTime.Now
            });

            Assert.True(createdTournament.Matches.Count() == 3);
            Assert.NotNull(createdTournament.MainRoundForTournament);
        }

        [Fact]
        public void TestAddedTournamentWithUnknownPlayer()
        {
            _tournamentRoundService = new MockTournamentRoundService();

            CreatedTournamentDto createdTournament =  _tournamentRoundService.CreateTournamentWithMainRounds(new CreateQuizDto
            {
                Name = "Boe",
                Players = new List<PlayerInQuizDto>
                {
                    new PlayerInQuizDto
                    {
                        Id = 1,
                        UserName = "fabian"
                    },
                    new PlayerInQuizDto
                    {
                        Id = 2,
                        UserName = "thijs"
                    },
                    new PlayerInQuizDto
                    {
                        Id = 4,
                        UserName = "joey"
                    }
                },
                TournamentDate = DateTime.Now
            });

            Assert.True(createdTournament.Matches.Count() == 1);
            Assert.NotNull(createdTournament.MainRoundForTournament);
        }

        [Fact]
        public void TestAddedTournamentWith1KnowPlayer()
        {
            _tournamentRoundService = new MockTournamentRoundService();

            var act = new Func<CreatedTournamentDto>(() => _tournamentRoundService.CreateTournamentWithMainRounds(
                new CreateQuizDto
                {
                    Name = "Boe",
                    Players = new List<PlayerInQuizDto>
                    {
                        new PlayerInQuizDto
                        {
                            Id = 1,
                            UserName = "fabian"
                        }
                    },
                    TournamentDate = DateTime.Now
                }));

        }


        [Fact]
        public void TestAddedTournamentWith1UnknowPlayer()
        {
            _tournamentRoundService = new MockTournamentRoundService();

            var act = new Func<CreatedTournamentDto>(() => _tournamentRoundService.CreateTournamentWithMainRounds(
                new CreateQuizDto
                {
                    Name = "Boe",
                    Players = new List<PlayerInQuizDto>
                    {
                        new PlayerInQuizDto
                        {
                            Id = 1,
                            UserName = "joey"
                        }
                    },
                    TournamentDate = DateTime.Now
                }));

            Assert.Throws<ArgumentOutOfRangeException>(act);
        }
    }
}
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

            CreatedTournamentDto createdTournament =  _tournamentRoundService.CreateTournamentWithMainRounds(new CreateTournamentDto
            {
                Name = "Boe",
                Players = new List<PlayerInTournamentDto>
                {
                    new PlayerInTournamentDto
                    {
                        Id = 1,
                        UserName = "fabian"
                    },
                    new PlayerInTournamentDto
                    {
                        Id = 2,
                        UserName = "thijs"
                    },
                    new PlayerInTournamentDto
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

            CreatedTournamentDto createdTournament =  _tournamentRoundService.CreateTournamentWithMainRounds(new CreateTournamentDto
            {
                Name = "Boe",
                Players = new List<PlayerInTournamentDto>
                {
                    new PlayerInTournamentDto
                    {
                        Id = 1,
                        UserName = "fabian"
                    },
                    new PlayerInTournamentDto
                    {
                        Id = 2,
                        UserName = "thijs"
                    },
                    new PlayerInTournamentDto
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
                new CreateTournamentDto
                {
                    Name = "Boe",
                    Players = new List<PlayerInTournamentDto>
                    {
                        new PlayerInTournamentDto
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
                new CreateTournamentDto
                {
                    Name = "Boe",
                    Players = new List<PlayerInTournamentDto>
                    {
                        new PlayerInTournamentDto
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